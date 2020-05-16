using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace NoNameApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const string KEY_CATEGORIES = "Categories";
        private const string KEY_PRODUCTS_IN_CATEGORY = "ProductsInCategory";
        private const string KEY_PRODUCTS_IN_ORDER = "ProductsInOrder";
        private const int MAX_NUMBER_OF_CELLS_IN_ROW = 3;
        
        private List<Category> categories = new List<Category>();
        private List<Product> productsInCategory = new List<Product>();
        private List<Product> productsInOrder = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Samo kad prvi puta otvorimo stranicu (GET request), zelimo dohvatiti sve kategorije.
                categories.AddRange(DataManager.Instance.GetCategories());
                Session[KEY_CATEGORIES] = categories;
            }
            else
            {
                categories.AddRange((List<Category>)Session[KEY_CATEGORIES]);
            }

            CheckSessionState();
            ShowCategories(categories);
            ShowProductsInCategory(productsInCategory);
            ShowProductsInOrder(productsInOrder);
        }

        private void CheckSessionState()
        {
            if (Session[KEY_PRODUCTS_IN_CATEGORY] == null)
            {
                Session[KEY_PRODUCTS_IN_CATEGORY] = productsInCategory;
            }
            else
            {
                productsInCategory.AddRange((List<Product>)Session[KEY_PRODUCTS_IN_CATEGORY]);
            }

            if (Session[KEY_PRODUCTS_IN_ORDER] == null)
            {
                Session[KEY_PRODUCTS_IN_ORDER] = productsInOrder;
            }
            else
            {
                productsInOrder.AddRange((List<Product>)Session[KEY_PRODUCTS_IN_ORDER]);
            }
        }

        private void ShowCategories(List<Category> categories)
        {
            TableCategories.Rows.Clear();

            if (categories.Count == 0)
            {
                // Ako nema kategorija, gotovi smo.
                return;
            }

            int numberOfCellsInCurrentRow = 0;

            foreach (Category c in categories)
            {
                // Svaka kategorija ide u jednu celiju tablice.
                TableCell cell = new TableCell();

                // Kreiramo gumb na kojem ce pisati ime kategorije.
                Button button = new Button { Text = c.Name };

                // Registriramo metodu koja ce pozvati nakon sto kliknemo na gumb.
                button.Click += new EventHandler(OnCategoryButtonClicked);

                // Dodajmo gumb u celiju.
                cell.Controls.Add(button);

                if (numberOfCellsInCurrentRow == 0 || numberOfCellsInCurrentRow == MAX_NUMBER_OF_CELLS_IN_ROW)
                {
                    // Ako nema nijednog retka u tablici ili su sve celije u trenutnom retku popunjene,
                    // kreiramo novi redak, u njega dodajemo kreiranu celiju, a redak dodajemo u tablicu.
                    TableRow row = new TableRow();
                    row.Controls.Add(cell);
                    TableCategories.Rows.Add(row);

                    // Oznacimo da je novi redak zapocet.
                    numberOfCellsInCurrentRow = 1;
                }
                else
                {
                    // Inace, u retku koji se trenutno puni jos ima mjesta pa dodamo celiju u njega.
                    TableRow currentRow = TableCategories.Rows[TableCategories.Rows.Count - 1];
                    currentRow.Controls.Add(cell);

                    // Povecamo broj celija koje se nalaze u trenutnom retku.
                    ++numberOfCellsInCurrentRow;
                }
            }
        }

        private void OnCategoryButtonClicked(object sender, EventArgs e)
        {
            string categoryName = ((Button)sender).Text;
            List<Product> products = DataManager.Instance.GetProducts(categoryName);
            Session[KEY_PRODUCTS_IN_CATEGORY] = products;
            ShowProductsInCategory(products);
        }

        private void ShowProductsInCategory(List<Product> products)
        {
            TableProducts.Rows.Clear();

            if (products.Count == 0)
            {
                // Ako nema proizvoda, gotovi smo.
                return;
            }

            // Zelimo popuniti tablicu s proizvodima.
            // Prvo moramo napraviti redak koji sadrzi nazive stupaca.
            TableHeaderRow headerRow = new TableHeaderRow();
            string[] headerCellNames = { "Naziv", "Količina", "Akcije" };

            for (int i = 0; i < headerCellNames.Length; ++i)
            {
                TableHeaderCell headerCell = new TableHeaderCell
                {
                    Text = headerCellNames[i]
                };

                headerRow.Cells.Add(headerCell);
            }

            TableProducts.Rows.Add(headerRow);

            // Nakon toga prolazimo kroz listu proizvoda i svaki proizvod dodajemo kao redak tablice.
            foreach (Product p in products)
            {
                TableRow row = new TableRow();
                row.Controls.Add(new TableCell { Text = p.Name });
                row.Controls.Add(new TableCell { Text = p.Quantity.ToString() });

                Button button = new Button
                {
                    // Ovo postavljanje ID-a je kljucno - bez toga gumb ne radi dobro.
                    ID = string.Format("Button_{0}", p.Name),
                    Text = "Dodaj"
                };

                button.Click += new EventHandler(OnProductButtonClicked);

                TableCell actionCell = new TableCell();
                actionCell.Controls.Add(button);
                row.Controls.Add(actionCell);

                TableProducts.Rows.Add(row);
            }
        }

        private void OnProductButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string productName = ((TableRow)button.Parent.Parent).Cells[0].Text;

            TakeProduct(productName);
            AddToOrder(productName);
        }

        private void TakeProduct(string productName)
        {
            // Uzmi proizvod sa skladista, dohvati azuriranu listu proizvoda i prikazi je.
            List<Product> products = DataManager.Instance.TakeProduct(productName);
            Session[KEY_PRODUCTS_IN_CATEGORY] = products;
            ShowProductsInCategory(products);
        }

        private void ReturnProduct(string productName)
        {
            List<Product> products = DataManager.Instance.ReturnProduct(productName);
            Session[KEY_PRODUCTS_IN_CATEGORY] = products;
            ShowProductsInCategory(products);
        }

        private void AddToOrder(string productName)
        {
            Product product = productsInOrder.FirstOrDefault(p => p.Name.Equals(productName));

            if (product == null)
            {
                productsInOrder.Add(new Product(productName, 1));
            }
            else
            {
                ++product.Quantity;
            }

            Session[KEY_PRODUCTS_IN_ORDER] = productsInOrder;
            ShowProductsInOrder(productsInOrder);
        }

        private void RemoveFromOrder(string productName)
        {
            int index = productsInOrder.FindIndex(p => p.Name.Equals(productName));
            Product product = productsInOrder[index];

            if (--product.Quantity == 0)
            {
                productsInOrder.RemoveAt(index);
            }

            Session[KEY_PRODUCTS_IN_ORDER] = productsInOrder;
            ShowProductsInOrder(productsInOrder);
        }

        private void ShowProductsInOrder(List<Product> products)
        {
            TableOrder.Rows.Clear();

            if (products.Count == 0)
            {
                return;
            }

            TableHeaderRow headerRow = new TableHeaderRow();
            string[] headerCellNames = { "Naziv", "Količina", "Akcije" };

            for (int i = 0; i < headerCellNames.Length; ++i)
            {
                TableHeaderCell headerCell = new TableHeaderCell
                {
                    Text = headerCellNames[i]
                };

                headerRow.Cells.Add(headerCell);
            }

            TableOrder.Rows.Add(headerRow);

            foreach (Product p in products)
            {
                TableRow row = new TableRow();
                row.Controls.Add(new TableCell { Text = p.Name });
                row.Controls.Add(new TableCell { Text = p.Quantity.ToString() });

                Button buttonPlus = new Button
                {
                    ID = string.Format("ButtonPlus_{0}", p.Name),
                    Text = "+"
                };

                buttonPlus.Click += new EventHandler(OnButtonPlusClicked);

                Button buttonMinus = new Button
                {
                    ID = string.Format("ButtonMinus_{0}", p.Name),
                    Text = "-"
                };

                buttonMinus.Click += new EventHandler(OnButtonMinusClicked);

                TableCell actionCell = new TableCell();
                actionCell.Controls.Add(buttonPlus);
                actionCell.Controls.Add(buttonMinus);
                row.Controls.Add(actionCell);

                TableOrder.Rows.Add(row);
            }
        }

        private void OnButtonPlusClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string productName = ((TableRow)button.Parent.Parent).Cells[0].Text;

            TakeProduct(productName);
            AddToOrder(productName);
        }

        private void OnButtonMinusClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string productName = ((TableRow)button.Parent.Parent).Cells[0].Text;

            ReturnProduct(productName);
            RemoveFromOrder(productName);
        }

        protected void ButtonFinishOrder_Click(object sender, EventArgs e)
        {
            DataManager.Instance.FinishOrder(productsInOrder);
            productsInOrder.Clear();
            Session[KEY_PRODUCTS_IN_ORDER] = productsInOrder;
            ShowProductsInOrder(productsInOrder);
        }
    }
}