using NoNameAppDataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace NoNameRestService
{
    public class DatabaseManager
    {
        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString;
            }
        }

        public static UserData CheckLogin(UserData receivedUserData)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_SelectUserDataByUserNameAndPassword", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = receivedUserData.UserName;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = receivedUserData.Password;

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    return null;
                }

                return new UserData
                {
                    Id = Convert.ToInt32(reader["UserDataId"]),
                    UserName = (string)reader["UserName"],
                    Password = (string)reader["Password"],
                    FullName = (string)reader["FullName"],
                    userType = new UserType
                    {
                        Id = Convert.ToInt32(reader["UserTypeId"]),
                        Name = (string)reader["Name"]
                    }
                };
            }
        }

        public static MainData GetMainData()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_SelectCategories", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = command.ExecuteReader();
                List<Category> categories = new List<Category>();

                while (reader.Read())
                {
                    Category c = new Category
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = (string)reader["Name"]
                    };

                    categories.Add(c);
                }

                command = new SqlCommand("SP_SelectProducts", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                reader.Close();
                reader = command.ExecuteReader();
                List<Product> products = new List<Product>();

                while (reader.Read())
                {
                    Product p = new Product
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = (string)reader["Name"],
                        AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]),
                        Price = (float)(double)reader["Price"],
                        CategoryId = Convert.ToInt32(reader["CategoryId"])
                    };

                    products.Add(p);
                }

                return new MainData
                {
                    Categories = categories,
                    Products = products
                };
            }
        }

        public static List<Bill> GetBills()
        {
            List<Bill> bills = new List<Bill>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_SelectBills", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Bill b = new Bill
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Number = (string)reader["Number"],
                        Statuses = new List<BillStatus>(),
                        Contents = new List<BillContent>()
                    };

                    bills.Add(b);
                }

                reader.Close();

                command = new SqlCommand("SP_SelectBillStatuses", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BillStatus status = new BillStatus
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = (string)reader["Name"],
                        StatusTimestamp = ((DateTime)reader["StatusTimestamp"]).ToString(),
                        BillId = Convert.ToInt32(reader["BillId"])
                    };

                    Bill correspondingBill = bills.SingleOrDefault(b => b.Id == status.BillId);

                    if (correspondingBill != null)
                    {
                        correspondingBill.Statuses.Add(status);
                    }
                }

                reader.Close();

                command = new SqlCommand("SP_SelectBillContents", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BillContent content = new BillContent
                    {
                        Id = Convert.ToInt32(reader["ContentId"]),
                        ProductPrice = (float)(double)reader["ProductPrice"],
                        ProductQuantity = Convert.ToInt32(reader["ProductQuantity"]),
                        BillId = Convert.ToInt32(reader["BillId"]),
                        CorrespondingProduct = new Product
                        {
                            Id = Convert.ToInt32(reader["ProductId"]),
                            Name = (string)reader["Name"],
                            AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]),
                            Price = (float)(double)reader["Price"],
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        }
                    };

                    Bill correspondingBill = bills.SingleOrDefault(b => b.Id == content.BillId);

                    if (correspondingBill != null)
                    {
                        correspondingBill.Contents.Add(content);
                    }
                }
            }

            return bills;
        }

        public static bool CreateBill(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_InsertBill", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("@Year", SqlDbType.Int).Value = DateTime.Now.Year;
                command.Parameters.Add("@Month", SqlDbType.Int).Value = DateTime.Now.Month;
                command.Parameters.Add("@Day", SqlDbType.Int).Value = DateTime.Now.Day;

                int billId = Convert.ToInt32(command.ExecuteScalar());

                command = new SqlCommand("SP_InsertBillStatus", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = "CREATED";
                command.Parameters.Add("@BillId", SqlDbType.Int).Value = billId;

                if (command.ExecuteNonQuery() < 1)
                {
                    return false;
                }

                foreach (BillContent content in bill.Contents)
                {
                    command = new SqlCommand("SP_InsertBillContent", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.Add("@ProductPrice", SqlDbType.Float).Value = content.ProductPrice;
                    command.Parameters.Add("@ProductQuantity", SqlDbType.Int).Value = content.ProductQuantity;
                    command.Parameters.Add("@ProductId", SqlDbType.Int).Value = content.CorrespondingProduct.Id;
                    command.Parameters.Add("@BillId", SqlDbType.Int).Value = billId;

                    if (command.ExecuteNonQuery() < 1)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public static bool UpdateBill(Bill bill)
        {
            BillStatus lastAddedStatusNotPresentInDB = bill
                .Statuses
                .Where(s => s.Id == null)
                .FirstOrDefault();

            if (lastAddedStatusNotPresentInDB == null)
            {
                return true;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_InsertBillStatus", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = lastAddedStatusNotPresentInDB.Name;
                command.Parameters.Add("@BillId", SqlDbType.VarChar).Value = bill.Id;

                int numberOfAffectedRows = command.ExecuteNonQuery();
                return numberOfAffectedRows > 0;
            }
        }

        public static bool DeleteBill(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_DeleteBill", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                int numberOfAffectedRows = command.ExecuteNonQuery();
                return numberOfAffectedRows > 0;
            }
        }

        public static bool CreateCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_InsertCategory", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = category.Name;

                int numberOfAffectedRows = command.ExecuteNonQuery();
                return numberOfAffectedRows > 0;
            }
        }

        public static bool UpdateCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_UpdateCategory", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("@Id", SqlDbType.Int).Value = category.Id;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = category.Name;

                int numberOfAffectedRows = command.ExecuteNonQuery();
                return numberOfAffectedRows > 0;
            }
        }

        public static bool DeleteCategory(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_DeleteCategory", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                int numberOfAffectedRows = command.ExecuteNonQuery();
                return numberOfAffectedRows > 0;
            }
        }

        public static bool CreateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_InsertProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = product.Name;
                command.Parameters.Add("@AvailableQuantity", SqlDbType.Int).Value = product.AvailableQuantity;
                command.Parameters.Add("@Price", SqlDbType.Float).Value = product.Price;
                command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = product.CategoryId;

                int numberOfAffectedRows = command.ExecuteNonQuery();
                return numberOfAffectedRows > 0;
            }
        }

        public static bool UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_UpdateProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("@Id", SqlDbType.Int).Value = product.Id;
                command.Parameters.Add("@AvailableQuantity", SqlDbType.Int).Value = product.AvailableQuantity;
                command.Parameters.Add("@Price", SqlDbType.Float).Value = product.Price;
                command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = product.CategoryId;

                int numberOfAffectedRows = command.ExecuteNonQuery();
                return numberOfAffectedRows > 0;
            }
        }

        public static bool DeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_DeleteProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };


                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                int numberOfAffectedRows = command.ExecuteNonQuery();

                return numberOfAffectedRows > 0;
            }
        }

        public static List<BillReport> GetBillReports()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_SelectBillReports", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = command.ExecuteReader();
                List<BillReport> reports = new List<BillReport>();

                while (reader.Read())
                {
                    BillReport br = new BillReport
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Year = Convert.ToInt32(reader["Year"]),
                        Month = Convert.ToInt32(reader["Month"]),
                        Day = Convert.ToInt32(reader["Day"]),
                        FileDataId = Convert.ToInt32(reader["FileDataId"]),
                    };

                    reports.Add(br);
                }

                return reports;
            }
        }

        public static List<SupplyReport> GetSupplyReports()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_SelectSupplyReports", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = command.ExecuteReader();
                List<SupplyReport> reports = new List<SupplyReport>();

                while (reader.Read())
                {
                    SupplyReport sr = new SupplyReport
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Year = Convert.ToInt32(reader["Year"]),
                        Month = Convert.ToInt32(reader["Month"]),
                        Day = Convert.ToInt32(reader["Day"]),
                        FileDataId = Convert.ToInt32(reader["FileDataId"]),
                    };

                    reports.Add(sr);
                }

                return reports;
            }
        }

        public static FileData GetFileData(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_SelectFileDataById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };


                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    return null;
                }

                return new FileData
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = (string)reader["Name"],
                    FileTimestamp = ((DateTime)reader["FileTimestamp"]).ToString(),
                    ContentType = (string)reader["ContentType"],
                    Data = (string)reader["Data"]
                };
            }
        }
    }
}