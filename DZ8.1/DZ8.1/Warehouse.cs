namespace Classes
{
    internal class Warehouse
    {
        private Product[] _products = Array.Empty<Product>();

        public Product[] Products
        {
            get
            {
                return _products;
            }
        }

        public void AddProduct(Product product)
        {
            if (product.IsValid)
            {
                int oldQuantity = _products.Length;
                Product[] newProducts = new Product[oldQuantity + 1];
                for (int i = 0; i < oldQuantity; i++)
                {
                    newProducts[i] = _products[i];
                }
                newProducts[oldQuantity] = product;
                _products = new Product[oldQuantity + 1];
                _products = newProducts;
            }
            else
            {
                Console.WriteLine("Невозможно добавить товар");
            }
        }

        public void DeleteProduct(Product product)
        {
            int quantity = _products.Length;
            for (int i = 0; i < quantity; i++)
            {
                if (_products[i].Equals(product))
                {
                    Product[] newProducts = new Product[quantity - 1];
                    for (int j = 0; j < quantity - 1; j++)
                    {
                        newProducts[j] = j < i ? _products[j] : _products[j + 1];
                    }
                    _products = newProducts;
                    break;
                }
            }
        }

        public void ShowProductInfoByIndex(int index)
        {
            if (index >= 0 & index < _products.Length)
            {
                _products[index].ShowInfo();
            }
            else
            {
                Console.WriteLine("Товара с таким индексом не существует");
            }
        }

        public void ShowProductInfoByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                foreach (Product product in _products)
                {
                    if (product.Name.Equals(name))
                    {
                        product.ShowInfo();
                    }
                }
            }
            else
            {
                Console.WriteLine("Товара с таким именем не существует");
            }
        }
    }
}