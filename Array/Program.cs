using System;
using System.Collections.Generic;
using System.Globalization;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] MyList = new double[100];
            MyList = Function.Nhap();

            while (true)
            {
                Console.WriteLine("1.Xoa" + "\n" + "2.Sua" + "\n" + "3.Chen" + "\n" + "4.Hien thi" + "\n" + "5.Thoat");
                var key = Console.ReadLine();
                Function.CheckInt(key);
                if (int.Parse(key) == 1)
                {
                    MyList = Function.Xoa(MyList);
                }
                else if (int.Parse(key) == 2)
                {
                    Function.Sua(MyList);
                }
                else if (int.Parse(key) == 3)
                {
                    MyList = Function.Chen(MyList);
                }
                else if (int.Parse(key) == 4)
                {
                    Function.Xuat(MyList);
                }
                else if (int.Parse(key) == 5)
                {
                    break;
                }
            }

        }
    }
}
