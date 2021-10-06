using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;

namespace Array
{
    class Function
    {
        public static string CheckInt(string data)//Kiem tra input kieu int
        {
            int intrange;
            while (!int.TryParse(data, out intrange))
            {
                Console.Write("Nhap sai, xin moi nhap lai:" + " ");
                data = Console.ReadLine();
            }    
                return data.ToString();
        }
        public static string CheckDouble(string data)//Kiem tra input kieu double
        {
            double doublerange;
            while (!double.TryParse(data, out doublerange))
            {
                Console.Write("Nhap sai, xin moi nhap lai:" + " ");
                data = Console.ReadLine();
            }
            return data.ToString();
        }
        public static double[] Nhap()
        {
            Console.Write("Nhap so phan tu:" + " ");
            var length = Console.ReadLine();
            length= CheckInt(length);
            double[] array = new double[int.Parse(length)];
            for (int i = 0; i < int.Parse(length); i++)
            {
                Console.Write("Nhap phan tu thu" + " " + (i + 1) + ": ");
                var value = Console.ReadLine();
                value = CheckDouble(value);
                array[i] = double.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
            }
            return array;
        }
        public static void Xuat(double[] array)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("");

        }
        public static double[] Xoa(double[] array)//Xoa tat ca cac gia tri input
        {
            int index = 0;
            int length = 0;
            Console.Write("Nhap gia tri muon xoa:" + " ");
            var value = Console.ReadLine();
            value = CheckDouble (value);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != double.Parse(value))
                {
                    length++;
                }
            }
            double[] newarray = new double[length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != double.Parse(value))
                {
                    newarray[index] = array[i];
                    index++;
                }
            }
            return newarray;
        }
        public static double[] Chen(double[] array)//Tao mang moi, chen gia tri vao mang moi
        {
            double[] newarray = new double[array.Length + 1];
            Console.Write("Nhap vi tri can chen:" + " ");
            var position = Console.ReadLine();
            position = CheckInt(position);
            CheckInt(position);
            Console.Write("Nhap gia tri can chen:" + " ");
            var value = Console.ReadLine();
            value = CheckDouble(value);
            for (int index = 0; index < array.Length + 1; index++)
            {
                if (index < int.Parse(position) - 1)
                    newarray[index] = array[index];
                else if (index == int.Parse(position) - 1)
                    newarray[index] = double.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
                else
                    newarray[index] = array[index - 1];
            }
            return newarray;
        }
        public static void Sua(double[] array)
        {
            Console.Write("Nhap vi tri can sua:" + " ");
            var position = Console.ReadLine();
            position = CheckInt(position);
            Console.Write("Nhap gia tri can sua:" + " ");
            var value = Console.ReadLine();
            value = CheckDouble(value);
            array[int.Parse(position) - 1] = double.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
        }
    }
}


