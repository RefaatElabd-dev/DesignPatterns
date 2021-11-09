using System;
using System.Collections.Generic;
using static System.Console;

namespace AbstractFactory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("I prefere Tea with Milk");
        }
    }

    internal class Coffie : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This coffie is Sensational");
        }
    }

    internal class Milk : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This Milk is Delisues");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"boil Water, pour {amount} then add 20 Gram of suger");
            return new Tea();
        }
    }
    internal class CoffieFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind som beans, Poil Water, pour {amount} then add 20 Gram of suger");
            return new Coffie();
        }
    }

    internal class MilkFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"boil Milk, pour {amount} then add 20 Gram of suger");
            return new Milk();
        }
    }

    public class HotDrinkMachine
    {
        //public enum AvailableDrinks
        //{
        //    Coffie, Tea
        //}

        //private Dictionary<AvailableDrinks, IHotDrinkFactory> factories = 
        //    new Dictionary<AvailableDrinks, IHotDrinkFactory>();

        //public HotDrinkMachine()
        //{
        //    foreach (AvailableDrinks drink in Enum.GetValues(typeof(AvailableDrinks)))
        //    {
        //        var x = Enum.GetName(typeof(AvailableDrinks), drink);
        //        var factory = (IHotDrinkFactory) Activator.CreateInstance(
        //            Type.GetType("AbstractFactory." + Enum.GetName(typeof(AvailableDrinks), drink) + "Factory"));

        //        factories.Add(drink, factory);
        //    }
        //}

        //public IHotDrink MakeDrink(AvailableDrinks drink, int amount)
        //{
        //    return factories[drink].Prepare(amount);
        //}

        public List<Tuple<string, IHotDrinkFactory>> factories = 
            new List<Tuple<string, IHotDrinkFactory>>();
        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(
                        Tuple.Create(t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t) ));
                }
            }
        }

        public IHotDrink hotDrink()
        {
            for (int i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                WriteLine($"{i}: {tuple.Item1} : {tuple.Item2}");
            }

            while (true)
            {
                string s;
                if((s = ReadLine())!= null
                    && int.TryParse(s, out int i)
                    && i >=0
                    && i < factories.Count)
                {
                    Write("Spicify Amount: ");
                    s = ReadLine();
                    if(s != null 
                        && int.TryParse(s, out int amount)
                        && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                    Console.WriteLine("incorrect input, try again... ");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //HotDrinkMachine machine = new HotDrinkMachine();
            //var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrinks.Coffie, 7);
            //drink.Consume();

            HotDrinkMachine machine = new HotDrinkMachine();
            var drink = machine.hotDrink();
            drink.Consume();
        }
    }
}
