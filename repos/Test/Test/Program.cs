using System;
class Test
{
    public unsafe void Method()
    {
        int[] myArray =  { 1, 2, 3, 4, 5 };
        fixed (int* ptr = myArray) Display(ptr);

    }
    public unsafe void Display(int* pt)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(*(pt + i));
        }
    }
    class MyClient
    {
        public static void Main()
        {
            Test mc = new Test();
            mc.Method();
        }
    }
}
