using NoNameAppDataModel;
using System.Collections.Generic;

namespace NoNameWebApp.Business
{
    public class DummyData
    {
        public static UserType userTypeAdmin = new UserType { Id = 1, Name = "Admin" };
        public static UserType userTypeWaiter = new UserType { Id = 2, Name = "Waiter" };

        public static Product product1 = new Product { Id = 1, Name = "Kava", AvailableQuantity = 10, Price = 8, CategoryId = 1 };
        public static Product product2 = new Product { Id = 2, Name = "Cappucino", AvailableQuantity = 10, Price = 12, CategoryId = 1 };
        public static Product product3 = new Product { Id = 3, Name = "Caj", AvailableQuantity = 10, Price = 10, CategoryId = 1 };
        public static Product product4 = new Product { Id = 4, Name = "Ozujsko", AvailableQuantity = 10, Price = 12, CategoryId = 2 };
        public static Product product5 = new Product { Id = 5, Name = "Karlovacko", AvailableQuantity = 10, Price = 14, CategoryId = 2 };
        public static Product product6 = new Product { Id = 6, Name = "Corona", AvailableQuantity = 10, Price = 15, CategoryId = 2 };
        public static Product product7 = new Product { Id = 7, Name = "Jamnica Sensation", AvailableQuantity = 10, Price = 10, CategoryId = 3 };
        public static Product product8 = new Product { Id = 8, Name = "Coca-Cola", AvailableQuantity = 10, Price = 15, CategoryId = 3 };
        public static Product product9 = new Product { Id = 9, Name = "Sprite", AvailableQuantity = 10, Price = 15, CategoryId = 3 };
        public static Product product10 = new Product { Id = 10, Name = "Rakija", AvailableQuantity = 10, Price = 10, CategoryId = 4 };
        public static Product product11 = new Product { Id = 11, Name = "Jack Daniels", AvailableQuantity = 10, Price = 15, CategoryId = 4 };
        public static Product product12 = new Product { Id = 12, Name = "Pago", AvailableQuantity = 10, Price = 12, CategoryId = 5 };
        public static Product product13 = new Product { Id = 13, Name = "Cappy", AvailableQuantity = 10, Price = 13, CategoryId = 5 };

        public static BillContent content1 = new BillContent { Id = 1, ProductPrice = 8, ProductQuantity = 2, CorrespondingProduct = product1, BillId = 1 };
        public static BillContent content2 = new BillContent { Id = 2, ProductPrice = 15, ProductQuantity = 1, CorrespondingProduct = product6, BillId = 1 };
        public static BillContent content3 = new BillContent { Id = 3, ProductPrice = 12, ProductQuantity = 1, CorrespondingProduct = product12, BillId = 2 };
        public static BillContent content4 = new BillContent { Id = 4, ProductPrice = 15, ProductQuantity = 1, CorrespondingProduct = product8, BillId = 2 };
        public static BillContent content5 = new BillContent { Id = 5, ProductPrice = 10, ProductQuantity = 1, CorrespondingProduct = product7, BillId = 2 };
        public static BillContent content6 = new BillContent { Id = 6, ProductPrice = 10, ProductQuantity = 1, CorrespondingProduct = product10, BillId = 3 };
        public static BillContent content7 = new BillContent { Id = 7, ProductPrice = 12, ProductQuantity = 1, CorrespondingProduct = product2, BillId = 4 };
        public static BillContent content8 = new BillContent { Id = 8, ProductPrice = 10, ProductQuantity = 2, CorrespondingProduct = product3, BillId = 4 };

        public static BillStatus status1 = new BillStatus { Id = 1, Name = "CREATED", StatusTimestamp = "2020-06-24 16:27:05", BillId = 1 };
        public static BillStatus status2 = new BillStatus { Id = 2, Name = "APPROVED", StatusTimestamp = "2020-06-24 16:28:20", BillId = 1 };
        public static BillStatus status3 = new BillStatus { Id = 3, Name = "PAYED", StatusTimestamp = "2020-06-24 17:00:00", BillId = 1 };
        public static BillStatus status4 = new BillStatus { Id = 4, Name = "CREATED", StatusTimestamp = "2020-06-24 15:00:00", BillId = 2 };
        public static BillStatus status5 = new BillStatus { Id = 5, Name = "CREATED", StatusTimestamp = "2020-06-24 16:00:00", BillId = 3 };
        public static BillStatus status6 = new BillStatus { Id = 6, Name = "APPROVED", StatusTimestamp = "2020-06-24 16:01:12", BillId = 3 };
        public static BillStatus status7 = new BillStatus { Id = 7, Name = "CREATED", StatusTimestamp = "2020-06-24 08:15:00", BillId = 4 };
        public static BillStatus status8 = new BillStatus { Id = 8, Name = "REJECTED", StatusTimestamp = "2020-06-24 08:20:00", BillId = 4 };

        public static List<UserType> userTypes = new List<UserType>
        {
            userTypeAdmin,
            userTypeWaiter
        };

        public static List<UserData> userDataList = new List<UserData>
        {
            new UserData { Id = 1, UserName = "milan", Password = "milan", FullName = "Milan Siklic", userType = userTypeAdmin },
            new UserData { Id = 2, UserName = "pero", Password = "pero", FullName = "Pero Peric", userType = userTypeWaiter }
        };

        public static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Topli" },
            new Category { Id = 2, Name = "Pivo" },
            new Category { Id = 3, Name = "Gazirani" },
            new Category { Id = 4, Name = "Zestoka" },
            new Category { Id = 5, Name = "Vocni" }
        };

        public static List<Product> products = new List<Product>
        {
            product1,
            product2,
            product3,
            product4,
            product5,
            product6,
            product7,
            product8,
            product9,
            product10,
            product11,
            product12,
            product13
        };

        public static List<BillContent> billContents = new List<BillContent>
        {
            content1,
            content2,
            content3,
            content4,
            content5,
            content6,
            content7,
            content8
        };

        public static List<BillStatus> billStatuses = new List<BillStatus>
        {
            status1,
            status2,
            status3,
            status4,
            status5,
            status6,
            status7,
            status8
        };

        public static List<Bill> bills = new List<Bill>
        {
            new Bill
            {
                Id = 1,
                Number = "2020-06-24-0001",
                TotalPrice = 31,
                Contents = new List<BillContent> { content1, content2 },
                Statuses = new List<BillStatus> { status1, status2, status3 }
            },
            new Bill
            {
                Id = 2,
                Number = "2020-06-24-0002",
                TotalPrice = 37,
                Contents = new List<BillContent> { content3, content4, content5 },
                Statuses = new List<BillStatus> { status4 }
            },
            new Bill
            {
                Id = 3,
                Number = "2020-06-24-0003",
                TotalPrice = 10,
                Contents = new List<BillContent> { content6 },
                Statuses = new List<BillStatus> { status5, status6 }
            },
            new Bill
            {
                Id = 4,
                Number = "2020-06-24-0004",
                TotalPrice = 32,
                Contents = new List<BillContent> { content7, content8 },
                Statuses = new List<BillStatus> { status7, status8 }
            }
        };

        public static List<FileData> fileDataList = new List<FileData>
        {
            new FileData { Id = 1, Name = "BillReport_A.txt", FileTimestamp = "2020-06-24 12:00:00", ContentType = "text/plain", Data = "Ovo je bill-izvjestaj A." },
            new FileData { Id = 2, Name = "BillReport_B.txt", FileTimestamp = "2020-06-25 00:00:00", ContentType = "text/plain", Data = "Ovo je bill-izvjestaj B." },
            new FileData { Id = 3, Name = "SupplyReport_A.txt", FileTimestamp = "2020-06-23 00:00:00", ContentType = "text/plain", Data = "Ovo je supply-izvjestaj A." },
            new FileData { Id = 4, Name = "SupplyReport_B.txt", FileTimestamp = "2020-06-24 00:00:00", ContentType = "text/plain", Data = "Ovo je supply-izvjestaj B." },
        };

        public static List<BillReport> billReports = new List<BillReport>
        {
            new BillReport { Id = 1, Year = 2020, Month = 6, Day = 24, FileDataId = 1 },
            new BillReport { Id = 2, Year = 2020, Month = 6, Day = 25, FileDataId = 2 }
        };

        public static List<SupplyReport> supplyReports = new List<SupplyReport>
        {
            new SupplyReport { Id = 1, Year = 2020, Month = 6, Day = 23, FileDataId = 3 },
            new SupplyReport { Id = 2, Year = 2020, Month = 6, Day = 24, FileDataId = 4 }
        };
    }
}
