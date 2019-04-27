using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public abstract class Food
    {
        private string _name;
        private int _servingSize;
        private decimal _price;

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

        public Food(string name, int servingSize, decimal price)
        {
            Name = name;
            ServingSize = servingSize;
            Price = price;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {string.Format("{0:F2}", this.Price)}";
        }
    }
}
