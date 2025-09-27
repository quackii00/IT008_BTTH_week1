using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH_BT1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nhập n và tạo mạng ngẫu nhiên
            int n = ReadPositiveInt("Nhap n so nguyen (n>0) : ");
            int[] Arr = CreateRandomArr(n, -50, 150);
            //in mảng ngẫu nhiên ra màng hình
            WriteArr(Arr);
            //Kết quả thực thi theo thứ tự a, b, c của đề bài
            Console.WriteLine("(a). Tong cac so le trong mang la: " + sumObb(Arr));
            Console.WriteLine("(b). Trong mang có " + countPrime(Arr) + " so nguyen to");
            Console.WriteLine("(c). So chinh phuong nho nhat la: " + SmallestPerfectSquare(Arr));
        }

        //Xuất mảng ra mảng hình
        static void WriteArr(int[] arr) 
            {
                Console.Write("Mang gom cac phan tu: ");
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

        //Đọc số nguyên
        static int ReadPositiveInt(string note)
        {
            int n;
            do
            {
                Console.Write(note);
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }

        //Tạo mảng n phần tử ngẫu nhiên dựa vào giới hạn minVal và maxVal
        static int[] CreateRandomArr(int n, int minVal, int maxVal)
        {
            {
                Random rndVal = new Random();
                int[] arr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    arr[i] = rndVal.Next(minVal, maxVal + 1);
                }
                return arr;
            }
        }
        
        //(a) Tổng số lẻ
        static int sumObb(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                if (i % 2 != 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        //Kiểm tra số nguyên tố
        static bool isPrime(int a)
        {
            if (a<2) return false;
            for (int i=2; i<=(int)Math.Sqrt(a); i++)
            {
                if (a %i ==0) return false;
            }    
            return true;
        }

        //(b) Đếm số nguyên tố
        static int countPrime(int[] arr)
        {
            int count = 0;
            foreach (int i in arr)
            {
                if (isPrime(i)) count++;
            }    
            return count;
        }

        //Kiểm tra số chính phương
        static bool isPerfectSquare(int a)
        {
            if ( a<0 ) return false;
            if (Math.Sqrt(a) == (int)Math.Sqrt(a)) return true;
            return false;
        }

        //(c) Tìm số chính phương nhỏ nhất, nếu không có trả về -1
        static int SmallestPerfectSquare(int[] a)
        {
            int smallest = -1;
            foreach(int i in a)
            {
                if (isPerfectSquare(i))
                {
                    if ((smallest > i) || smallest == -1) smallest = i;
                }    
            }
            return smallest;
        }

    }
}
