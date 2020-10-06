using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Autofac;
using MoreLinq;
using static System.Console;

namespace DesignPatterns
{
    public static class ExtensionMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if (!ReferenceEquals(self, other)) return;

            foreach (var from in self)
            {
                foreach (var to in other)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
            }
        }
    }

    public class Neuron : IEnumerable<Neuron>
    {
        public float Value;
        public List<Neuron> In, Out;

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {

    }

    public class Program
    {
        static void Main(string[] args)
        {
            var neuron = new Neuron();
            var neuron2 = new Neuron();

            neuron.ConnectTo(neuron2);

            var layer = new NeuronLayer();
            var layer2 = new NeuronLayer();

            neuron.ConnectTo(layer);
            layer.ConnectTo(layer2);
        }
    }
}
