using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace DesignPatterns
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("Nice tea");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("Nice coffee");
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
            WriteLine($"Ready {amount} ml cup of tea");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Ready {amount} ml cup of coffee");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinkFactory>> _factories =
            new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                // checks if t implements IHotDrinkFactory and not an interface
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                    _factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        Activator.CreateInstance(t) as IHotDrinkFactory
                    ));
            }
        }

        public IHotDrink MakeDrink()
        {
            WriteLine("Available drinks: ");
            for (int index = 0; index < _factories.Count; index++)
            {
                var tuple = _factories[index];
                WriteLine($"{index}: {tuple.Item1}");
            }

            Write("Select drink: ");
            for (; ; )
            {
                string s;
                if ((s = ReadLine()) != null && int.TryParse(s, out int i) && i >= 0 && i < _factories.Count)
                {
                    Write("Specify amount: ");
                    s = ReadLine();
                    if (s != null && int.TryParse(s, out int amount) && amount > 0)
                        return _factories[i].Item2.Prepare(amount);
                }

                WriteLine("Incorrect input, try again");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink.Consume();
        }
    }
}
