using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public abstract class Drink : IDrink
    {
        private string _name;
        private int _servingSize;
        private decimal _price;
        private string _brand;

        private string Name
        {
            get
            {
                return this._name;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }

                this._name = value;
            }
        }

        private int ServingSize
        {
            get
            {
                return this._servingSize;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Serving size cannot be less or equal to zero.");
                }

                this._servingSize = value;
            }
        }

        private decimal Price
        {
            get
            {
                return this._price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero.");
                }

                this._price = value;
            }
        }

        private string Brand
        {
            get
            {
                return this._brand;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }

                this._brand = value;
            }
        }

        public Drink(string name, int servingSize, decimal price, string brand)
        {
            Name = name;
            ServingSize = servingSize;
            Price = price;
            Brand = brand;
        }

        public override string ToString()
        {
            return $"{Name} {Brand} - {ServingSize}ml - {string.Format("{0:F2}", Price)}lv";
        }

        public decimal GetPrice()
        {
            return this.Price;
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
