namespace Classes
{
    internal class Product
    {
        private string _name;

        private string _shopName;

        private double _price;

        private bool _isValid = true;

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    Console.WriteLine("Цена должна быть больше нуля");
                    _isValid = false;
                }
            }
        }

        public string ShopName
        {
            get
            {
                return _shopName;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _shopName = value;
                }
                else
                {
                    Console.WriteLine("Название магазина не должно быть пустым");
                    _isValid = false;
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Название товара не может быть пустым");
                    _isValid = false;
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
        }

        public Product(string name, string shopName, double price)
        {
            Name = name;
            ShopName = shopName;
            Price = price;

            if (!_isValid)
            {
                Console.WriteLine($"Проверьте введенные данные{Environment.NewLine}");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название товара: {_name}{Environment.NewLine}" +
                              $"Цена в рублях: {_price}{Environment.NewLine}" +
                              $"Название магазина: {_shopName}{Environment.NewLine}{Environment.NewLine}");
        }

        public static double operator +(Product firstProduct, Product secondProduct)
        {
            if (firstProduct._isValid & secondProduct._isValid)
            {
                return firstProduct._price + secondProduct._price;
            }
            else
            {
                Console.WriteLine("Проверьте товары, данные некорректны");
                return 0;
            }
        }

        public bool Equals(Product secondProduct)
        {
            if (secondProduct._isValid)
            {
                return ((this._price == secondProduct._price) &
                        (this._name == secondProduct._name) &
                        (this._shopName == secondProduct._shopName));
            }
            else
            {
                Console.WriteLine("Проверьте товары, данные некорректны");
                return false;
            }
        }
    }
}
