using System.Collections.Generic;
using System.Linq;

namespace NoNameApp
{
    public class DataManager
    {
        private static readonly List<Category> CATEGORIES = new List<Category>
        {
            new Category("Topli"),
            new Category("Pivo"),
            new Category("Gazirani"),
            new Category("Voćni"),
            new Category("Vino"),
            new Category("Žestoka pića")
        };

        private static readonly Dictionary<string, List<Product>> PRODUCT_MAP = new Dictionary<string, List<Product>>
        {
            {
                "Topli", new List<Product>
                {
                    new Product("Kava", 10),
                    new Product("Čaj", 10),
                    new Product("Cappucino", 10)
                }
            },
            {
                "Pivo", new List<Product>
                {
                    new Product("Ožujsko", 10),
                    new Product("Karlovačko", 10)
                }
            },
            {
                "Gazirani", new List<Product>
                {
                    new Product("Coca Cola", 10),
                    new Product("Sprite", 10),
                    new Product("Fanta", 10),
                }
            },
            {
                "Voćni", new List<Product>
                {
                    new Product("Pago", 10),
                    new Product("Cappy", 10)
                }
            },
            {
                "Vino", new List<Product>
                {
                    new Product("Graševina", 10),
                    new Product("Vranac", 10),
                    new Product("Zeleni Silvanac", 10)
                }
            },
            {
                "Žestoka pića", new List<Product>
                {
                    new Product("Rakija", 10),
                    new Product("Jack Daniels", 10)
                }
            }
        };

        private static DataManager instance;

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }

                return instance;
            }
        }

        private DataManager()
        {
        }

        public List<Category> GetCategories()
        {
            // TODO: ovdje treba ici poziv servisa koji ce nam to vratiti u JSON formatu...
            return CATEGORIES;
        }

        public List<Product> GetProducts(string categoryName)
        {
            return PRODUCT_MAP.ContainsKey(categoryName)
                ? PRODUCT_MAP[categoryName].Where(p => p.Quantity > 0).ToList()
                : new List<Product>();
        }

        public List<Product> TakeProduct(string productName)
        {
            foreach (KeyValuePair<string, List<Product>> pair in PRODUCT_MAP)
            {
                List<Product> products = pair.Value;
                int index = products.FindIndex(product => product.Name.Equals(productName));

                if (index != -1)
                {
                    --products[index].Quantity;
                    return products.Where(p => p.Quantity > 0).ToList();
                }
            }

            return new List<Product>();
        }

        public List<Product> ReturnProduct(string productName)
        {
            foreach (KeyValuePair<string, List<Product>> pair in PRODUCT_MAP)
            {
                List<Product> products = pair.Value;
                int index = products.FindIndex(product => product.Name.Equals(productName));

                if (index != -1)
                {
                    ++products[index].Quantity;
                    return products.Where(p => p.Quantity > 0).ToList();
                }
            }

            return new List<Product>();
        }

        public void FinishOrder(List<Product> products)
        {
            // TODO: pozovi servis
        }
    }
}