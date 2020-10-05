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
using MoreLinq;
using static System.Console;

namespace DesignPatterns
{
    public interface IInteger
    {
        int Value { get; }
    }

    public static class Dimensions
    {
        public class Two : IInteger
        {
            public int Value => 2;
        }

        public class Three : IInteger
        {
            public int Value => 3;
        }
    }

    public class Vector<TSelf, T, D>
        where TSelf : Vector<TSelf, T, D>, new()
        where D : IInteger, new()
    {
        protected T[] _data;

        public Vector()
        {
            // complains without new()
            _data = new T[new D().Value];
        }

        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            _data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); i++)
                _data[i] = values[i];
        }

        public static TSelf Create(params T[] values)
        {
            var result = new TSelf();
            var requiredSize = new D().Value;
            result._data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); i++)
                result._data[i] = values[i];

            return result;
        }

        public T this[int index]
        {
            get => _data[index];
            set => _data[index] = value;
        }

        public T X
        {
            get => _data[0];
            set => _data[0] = value;
        }
    }

    public class VectorOfInt<D> : Vector<VectorOfInt<D>, int, D>
        where D : IInteger, new()
    {
        public VectorOfInt()
        {
        }

        public VectorOfInt(params int[] values) : base(values)
        {
        }

        public static VectorOfInt<D> operator +
            (VectorOfInt<D> lhs, VectorOfInt<D> rhs)
        {
            var result = new VectorOfInt<D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
                result[i] = lhs[i] + rhs[i];

            return result;
        }
    }

    public class VectorOfFloat<D> : Vector<VectorOfFloat<D>, float, D>
       where D : IInteger, new()
    {
        public VectorOfFloat()
        {
        }

        public VectorOfFloat(params float[] values) : base(values)
        {
        }
    }

    public class Vector2i : VectorOfInt<Dimensions.Two>
    {
        public Vector2i()
        {
        }

        public Vector2i(params int[] values) : base(values)
        {
        }
    }

    public class Vector3f : VectorOfFloat<Dimensions.Three>
    {
        public override string ToString()
        {
            return $"{string.Join(", ", _data)}";
        }
    }

    // cannot work
    // public class Vector2f : Vector<float, 2> {}

    public class Program
    {
        static void Main(string[] args)
        {
            var vector = new Vector2i(1, 2);
            vector[0] = 0;

            var vector2 = new Vector2i(3, 2);
            var result = vector + vector2;

            var vector3 = Vector3f.Create(3.5f, 2.2f, 1f);
        }
    }
}
