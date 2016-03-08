using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_LaptopShop
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private string ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery batteryType;
        private double batteryLife;
        private decimal price;

        public Laptop(string model, string manufacturer, string processor, string ram,
            string graphicsCard, string hdd, string screen, Battery batteryType, double batteryLife, decimal price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.RAM = ram;
            this.GraphicsCard = graphicsCard;
            this.HDD = hdd;
            this.Screen = screen;
            this.BatteryType = batteryType;
            this.BatteryLife = batteryLife;
            this.Price = price;
        }

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop()
        {

        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (value.Count() < 2)
                {
                    throw new ArgumentException("Model must be atleast 2 characters long!");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (value.Count() < 2)
                {
                    throw new ArgumentException("Manufacturer must be atleast 2 characters long!");
                }

                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get
            {
                return this.processor;
            }
            set
            {
                if (value.Count() < 2)
                {
                    throw new ArgumentException("Processor cannot be less than 2 characters long!");
                }

                this.processor = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public string RAM
        {
            get
            {
                return this.ram;
            }

            set
            {
                if (value.Count() < 3)
                {
                    throw new ArgumentException("RAM cannot be less than 3 characters long!");
                }

                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get
            {
                return this.graphicsCard;
            }

            set
            {
                if (value.Count() < 2)
                {
                    throw new ArgumentException("Graphics card cannot be less than 2 characters long!");
                }

                this.graphicsCard = value;
            }

        }
        public string HDD
        {
            get
            {
                return this.hdd;
            }

            set
            {
                if (value.Count() < 2)
                {
                    throw new ArgumentException("HDD cannot be less that 2 characters long!");
                }

                this.hdd = value;
            }
        }

        public string Screen
        {
            get
            {
                return this.screen;
            }

            set
            {
                if (value.Count() < 2)
                {
                    throw new ArgumentException("Screen cannot be less than 2 characters long!");
                }

                this.screen = value;
            }
        }
        public double BatteryLife
        {
            get
            {
                return this.batteryLife;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery life cannot be negative!");
                }

                this.batteryLife = value;
            }
        }

        public Battery BatteryType
        {
            get
            {
                return this.batteryType;
            }

            set
            {
                this.batteryType = value;
            }
        }

        public override string ToString()
        {
            if ((ram == null) && (manufacturer == null) && (processor == null) && (graphicsCard == null) && (screen == null) && (batteryType == null)
                && (batteryLife == 0))
            {
                return string.Format("model : {0}\nprice : {1:f2}lv.", this.model, this.price);
            }

            else
            {
                return string.Format("model : {0}\nmanufacturer : {1}\nprocessor : {2}\nRAM : {3}\ngraphics card : {4}\nHDD : {5}\nscreen : {6}\nbattery : {7}\nbattery life : {8}hour(s)\nprice : {9:f2}lv.",
                    this.model, this.manufacturer, this.processor, this.ram, this.graphicsCard, this.hdd, this.screen, this.batteryType, this.batteryLife, this.price);
            }
        }
    }
}
