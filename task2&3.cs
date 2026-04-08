using lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class VectorByte
    {
        protected byte[] BArray;
        protected uint n { get; }
        protected int codeError { get; set; }
        protected static uint num_vec;

        public VectorByte()
        {
            BArray = new byte[1] { 0 };
            n = 1;
            codeError = 0;
            num_vec++;
        }

        public VectorByte(uint size)
        {
            BArray = new byte[size];
            n = size;
            codeError = 0;
            num_vec++;
        }

        public VectorByte(uint size, byte value)
        {
            BArray = new byte[size];
            for (int i = 0; i < size; i++) BArray[i] = value;
            n = size;
            codeError = 0;
            num_vec++;
        }

        ~VectorByte()
        {
            Console.WriteLine("VectorByte object destroyed");
        }

        public void Input()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"[{i}] = ");
                BArray[i] = byte.Parse(Console.ReadLine());
            }
        }

        public void Print()
        {
            for (int i = 0; i < n; i++) Console.Write(BArray[i] + " ");
            Console.WriteLine();
        }

        public void setValue(byte value)
        {
            for (int i = 0; i < this.n; i++)
            {
                BArray[i] = value;
            }
        }

        static public uint GetNumVec() => num_vec;

        public uint Size => n;
        public int ErrorCode { get => codeError; set => codeError = value; }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= n) { codeError = 1; return 0; }
                return BArray[index];
            }
            set
            {
                if (index < 0 || index >= n) codeError = 1;
                else BArray[index] = value;
            }
        }

        public static VectorByte operator ++(VectorByte v)
        {
            for (int i = 0; i < v.n; i++) v.BArray[i]++;
            return v;
        }

        public static VectorByte operator --(VectorByte v)
        {
            for (int i = 0; i < v.n; i++) v.BArray[i]--;
            return v;
        }

        public static bool operator true(VectorByte v) => v.n != 0;
        public static bool operator false(VectorByte v) => v.n == 0;
        public static bool operator !(VectorByte v) => v.n != 0;

        public static VectorByte operator +(VectorByte v1, VectorByte v2)
        {
            uint max = Math.Max(v1.n, v2.n);
            VectorByte res = new VectorByte(max);
            for (int i = 0; i < Math.Min(v1.n, v2.n); i++) res[i] = (byte)(v1[i] + v2[i]);
            return res;
        }

        public static VectorByte operator +(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] + s);
            return res;
        }

        public static VectorByte operator -(VectorByte v1, VectorByte v2)
        {
            uint max = Math.Max(v1.n, v2.n);
            VectorByte res = new VectorByte(max);
            for (int i = 0; i < Math.Min(v1.n, v2.n); i++) res[i] = (byte)(v1[i] - v2[i]);
            return res;
        }

        public static VectorByte operator -(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] - s);
            return res;
        }

        public static VectorByte operator *(VectorByte v1, VectorByte v2)
        {
            uint max = Math.Max(v1.n, v2.n);
            VectorByte res = new VectorByte(max);
            for (int i = 0; i < Math.Min(v1.n, v2.n); i++) res[i] = (byte)(v1[i] * v2[i]);
            return res;
        }

        public static VectorByte operator *(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] * s);
            return res;
        }

        public static VectorByte operator /(VectorByte v1, VectorByte v2)
        {
            uint max = Math.Max(v1.n, v2.n);
            VectorByte res = new VectorByte(max);
            for (int i = 0; i < Math.Min(v1.n, v2.n); i++) res[i] = v2[i] != 0 ? (byte)(v1[i] / v2[i]) : (byte)0;
            return res;
        }

        public static VectorByte operator /(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = s != 0 ? (byte)(v[i] / s) : (byte)0;
            return res;
        }

        public static bool operator ==(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if (v1[i] != v2[i]) return false;
            return true;
        }

        public static bool operator !=(VectorByte v1, VectorByte v2) => !(v1 == v2);

        public static bool operator >(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if (v1[i] <= v2[i]) return false;
            return true;
        }

        public static bool operator <(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if (v1[i] >= v2[i]) return false;
            return true;
        }

        public static bool operator >=(VectorByte v1, VectorByte v2) => (v1 > v2) || (v1 == v2);

        public static bool operator <=(VectorByte v1, VectorByte v2) => (v1 < v2) || (v1 == v2);

        public static bool operator |(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if (v1[i] != 0 && v2[i] != 0) return true;
            return false;
        }

        public static bool operator |(VectorByte v, byte s)
        {
            if (s == 0) return false;
            for (int i = 0; i < v.n; i++) if (v[i] != 0) return true;
            return false;
        }

        public static bool operator ^(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if ((v1[i] != 0) ^ (v2[i] != 0)) return true;
            return false;
        }

        public static bool operator ^(VectorByte v, byte s)
        {
            if (s == 0) return false;
            for (int i = 0; i < v.n; i++) if ((v[i] != 0) ^ (s != 0)) return true;
            return false;
        }

        public static VectorByte operator >>(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return new VectorByte(0);
            VectorByte res = new VectorByte(v1.n);
            for (int i = 0; i < v1.n; i++) res[i] = (byte)(v1[i] > v2[i] ? 1 : 0);
            return res;
        }

        public static VectorByte operator >>(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] > s ? 1 : 0);
            return res;
        }

        public static VectorByte operator <<(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return new VectorByte(0);
            VectorByte res = new VectorByte(v1.n);
            for (int i = 0; i < v1.n; i++) res[i] = (byte)(v1[i] < v2[i] ? 1 : 0);
            return res;
        }

        public static VectorByte operator <<(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] < s ? 1 : 0);
            return res;
        }

        struct InfoStruct
        {
            public string Medium;
            public double Volume;
            public string Name;
            public string Author;
        }

    public class Program
    {
        static void Main(string[] args)
        {
                while (true)
                {
                    int task;
                    Console.WriteLine("Enter task number (1-5) or 0 to exit:");
                    switch (task)
                    {
                        case 2:
                            Console.WriteLine("=== Constructors ===");
                            VectorByte v1 = new VectorByte();
                            VectorByte v2 = new VectorByte(5);
                            VectorByte v3 = new VectorByte(5, 2);

                            v1.Print();
                            v2.Print();
                            v3.Print();

                            Console.WriteLine("\n=== setValue ===");
                            v2.setValue(3);
                            v2.Print();

                            Console.WriteLine("\n=== Indexer ===");
                            v2[0] = 10;
                            Console.WriteLine($"v2[0] = {v2[0]}");

                            Console.WriteLine("\n=== ++ and -- ===");
                            ++v2;
                            v2.Print();
                            --v2;
                            v2.Print();

                            Console.WriteLine("\n=== Arithmetic operations ===");
                            VectorByte v4 = new VectorByte(5, 1);

                            (v2 + v4).Print();
                            (v2 + (byte)2).Print();

                            (v2 - v4).Print();
                            (v2 - (byte)1).Print();

                            (v2 * v4).Print();
                            (v2 * (byte)2).Print();

                            (v2 / v4).Print();
                            (v2 / (byte)2).Print();

                            Console.WriteLine("\n=== Comparison ===");
                            Console.WriteLine($"v2 == v4: {v2 == v4}");
                            Console.WriteLine($"v2 != v4: {v2 != v4}");
                            Console.WriteLine($"v2 > v4: {v2 > v4}");
                            Console.WriteLine($"v2 < v4: {v2 < v4}");
                            Console.WriteLine($"v2 >= v4: {v2 >= v4}");
                            Console.WriteLine($"v2 <= v4: {v2 <= v4}");

                            Console.WriteLine("\n=== Logical operators ===");
                            Console.WriteLine($"v2 | v4: {v2 | v4}");
                            Console.WriteLine($"v2 | 1: {v2 | (byte)1}");

                            Console.WriteLine($"v2 ^ v4: {v2 ^ v4}");
                            Console.WriteLine($"v2 ^ 1: {v2 ^ (byte)1}");

                            Console.WriteLine($"!v2: {!v2}");

                            Console.WriteLine("\n=== true / false ===");
                            if (v2)
                                Console.WriteLine("v2 is TRUE");
                            else
                                Console.WriteLine("v2 is FALSE");

                            Console.WriteLine("\n=== >> and << operators ===");
                            (v2 >> v4).Print();
                            (v2 >> (byte)2).Print();

                            (v2 << v4).Print();
                            (v2 << (byte)2).Print();

                            Console.WriteLine("\n=== Properties ===");
                            Console.WriteLine($"Size: {v2.Size}");
                            Console.WriteLine($"ErrorCode: {v2.ErrorCode}");

                            Console.WriteLine("\n=== Static count ===");
                            Console.WriteLine($"Total vectors: {VectorByte.GetNumVec()}");

                            Console.WriteLine("\n=== End of test ===");

                        case 3:
                            List<InfoStruct> listStruct = new List<InfoStruct>();
                            List<(string Medium, double Volume, string Name, string Author)> listTuples = new List<(string Medium, double Volume, string Name, string Author)> { };
                            listTuples.Add(("USB", 16.0, "Data1", "Author A"));
                            listTuples.Add(("HDD", 500.0, "Data2", "Author B"));
                            double targetVol = 16.0;
                            var toRemove = listTuples.FirstOrDefault(x => x.Volume == targetVol);
                            listTuples.Remove(toRemove);
                            int targetIndex = 1;
                            listTuples.Insert(targetIndex - 1, ("SSD", 256.0, "NewData", "Author C"));

                            for (int i = 0; i < listTuples.Count; i++)
                            {
                                Console.WriteLine($"Medium: {listTuples[i].Medium}, Volume: {listTuples[i].Volume}, Name: {listTuples[i].Name}, Author: {listTuples[i].Author}");
                            }
                        case 0:
                            Console.WriteLine("Exiting...");
                            return;
                    }
                }
    }
}
