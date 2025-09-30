using System;

namespace BTTH_Bai02
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Nhập số nguyên dương n
            int n = PositiveInt("Nhap so nguyen duong n (n>0): ");
            //in kết quả ra màng hình
            Console.WriteLine("Tong cac so nguyen to < {0} la: {1}", n, SumPrimesBelow(n));
        }

        //Đọc số nguyên dương
        static int PositiveInt(string note)
        {
            int n;
            do
            {
                Console.Write(note);
               
            }
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0) ;
            return n;
        }

        //Kiểm tra số nguyên tố
        static bool isPrime(int x)
        {
            if (x <2) return false;
           
            for (int i= 2; i<= Math.Sqrt(x); i++)
            {
                if (x % i == 0) return false;
            }  
            return true;
        }

        //Tính Tổng các số nguyên tố nhỏ hơn n
        static int SumPrimesBelow(int n)
        {
            int Sum = 0;
            for (int i=0; i<n; i++)
            {
                if (isPrime(i)) Sum += i;
            }
            return Sum;
        }
    }
}

