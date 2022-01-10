
using System.Collections.Generic;

namespace Programm
{

    public interface IBuilder
    {

        void motherboard();

        void cpu();

        void ram();

        void videoСard();

        void cooler();

        void hardDrive();

        void powerSupply();

        void body();

        void ssd();

    }

    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new();

        public ConcreteBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._product = new Product();
        }
        public void cpu()
        {
            this._product.Add("CPU");
        }
        public void ram()
        {
            this._product.Add("Ram");
        }

        public void videoСard()
        {
            this._product.Add("videoСard");
        }

        public void motherboard()
        {
            this._product.Add("Motherboard");
        }
        public void cooler()
        {
            this._product.Add("cooler");
        }
        public void hardDrive()
        {
            this._product.Add("hardDrive");
        }
        public void powerSupply()
        {
            this._product.Add("powerSupply");
        }
        public void body()
        {
            this._product.Add("body");
        }
        public void ssd()
        {
            this._product.Add("ssd");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }


    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Product parts: " + str + "\n";
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildMinimalViableProduct()
        {
            this._builder.cpu();
            this._builder.motherboard();
            this._builder.hardDrive();
            this._builder.ram();
            this._builder.powerSupply();
            this._builder.body();
        }

        public void BuildFullFeaturedProduct()
        {
            this._builder.cpu();
            this._builder.motherboard();
            this._builder.hardDrive();
            this._builder.ram();
            this._builder.powerSupply();
            this._builder.videoСard();
            this._builder.ssd();
            this._builder.body();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("PC:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Only cpu:");
            builder.cpu();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("minimal assembly PC:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());


            Console.WriteLine("No ram:");
            builder.cpu();
            builder.motherboard();
            builder.hardDrive();
            builder.powerSupply();
            builder.videoСard();
            builder.ssd();
            builder.body();
            Console.Write(builder.GetProduct().ListParts());
        }
    }
}