using System;
namespace BTTH_Bai06
{
    class Program
    {
        static void Main(string[] args)
        {
            //Đọc n hàng và m cột
            int n = PositiveInt("Nhap n dong (n>0): ");
            int m = PositiveInt("Nhap m cot (m>0): ");
            int k = PositiveRow(n);
            int[,] arr = CreateRandomArr(n, m, -50, 150);
            //(a) Xuất ma trận
            Console.WriteLine("(a). Ma tran : ");
            WriteMatrix(arr);
            Console.WriteLine();
            //(b) in phần tử lớn nhất và nhỏ nhất
            Console.WriteLine("(b.1). Phan tu lon nhat la: " + FindMax(arr));
            Console.WriteLine("(b.2). Phan tu nho nhat la: " + FindMin(arr));
            Console.WriteLine();
            //(c) Dòng có tổng lớn nhất
            Console.WriteLine("(c). Dong co tong lon nhat la dong thu : " + (1 + FindMaxSumRow(arr)));
            //(d) Tổng các số không phải số nguyên tố
            Console.WriteLine("(d). Tong cac so KHONG phai so nguyen to la: " + SumIsNotPrime(arr));
            //(e) Xóa dòng thứ k
            Console.WriteLine($"(e). Ma tran sau khi xoa hang thu {k}");
            WriteMatrix(RemoveRow(arr, k));
            Console.WriteLine();
            //(f) Xóa cột chứa phần tử lớn nhất
            Console.WriteLine($"(f). Ma tran sau khi xoa cot chua phan tu lon nhat {FindMax(arr)} la");
            WriteMatrix(RemoveColsHaveMaxValue(arr));
        }

        //Đọc kiểu số nguyên
        static int PositiveInt(string note)
        {
            int value;
            do
            {
                Console.Write(note);
            }
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0);
            return value;
        }

        //Đọc hàng hợp lệ
        static int PositiveRow(int n)
        {
            int Pos;
            do
            {
                Console.Write($"Nhap hang ban muon xoa ({1}->{n}): ");
            }
            while (!int.TryParse(Console.ReadLine(), out Pos) || (Pos <= 0 || Pos > n));
            return Pos;
        }

        // Tạo mảng 2 chiều có phần tử ngẫu nhiên trong khoảng min, max
        static int[,] CreateRandomArr(int n, int m, int min, int max)
        {
            Random rnd = new Random();
            int[,] arr = new int[n, m];
            for (int i=0; i<n;i++)
            {
                for (int j=0; j<m;j++)
                {
                    arr[i,j] = rnd.Next(min,max+1);
                }    
            }    
            return arr;
        }

        //(a) Xuất ma trận ra màn hình
        static void WriteMatrix(int[,] arr)
        {
            if(arr==null)
            {
                Console.WriteLine("Mang Rong!");
                return;
            } 
                
            Console.WriteLine("------------Matrix----------");
            for (int i=0; i< arr.GetLength(0);i++)
            {
                Console.Write($"({i + 1})  ");
                for (int j =0; j<arr.GetLength(1);j++)
                {
                    Console.Write(arr[i,j].ToString().PadLeft(5));
                } 
                Console.WriteLine();
            }    
        }

        //(b)Tìm phần tử lớn nhất
        static int FindMax(int[,] arr)
        {
            
            int max = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max) max= arr[i, j];
                }  
            }
            return max;
        }

        //(b) Tìm phần tử nhỏ nhất
        static int FindMin(int[,] arr)
        {
            int min = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < min) min = arr[i, j];
                }
            }
            return min;
        }

        //(c) Tìm dòng có tổng lớn nhất
        static int FindMaxSumRow(int[,] arr)
        {
            {
                int MaxSum = 0;
                int indexRow = 0;
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    MaxSum += arr[0, i];
                }
                for (int i = 1; i < arr.GetLength(0); i++)
                {
                    int Sum = 0;
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Sum += arr[i, j];
                    }
                    if (Sum > MaxSum)
                    {
                        MaxSum = Sum;
                        indexRow = i;
                    }
                }
                return indexRow;
            }
        }
        
        //Kiểm tra số nguyên tố
        static bool IsPrime(int x)
        {
            if (x<2) return false;
            if (x % 2 == 0) return false;
            for (int i=3; i<=(int)Math.Sqrt(x); i+=2)
            {
                if (x % i == 0) return false;
            }    
            return true;
        }

        //(d)Tính tổng các số không phải là số nguyên tố
        static int SumIsNotPrime(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (!IsPrime(arr[i, j])) sum += arr[i, j];
                }
            }
            return sum;
        }

        //(e) Xóa dòng thứ k trong ma trận ( trả về ma trận mới)
        static int[,] RemoveRow(int[,] arr,int k)
        {
            if (arr.GetLength(0) == 1) return null;
            int[,] newArr = new int[arr.GetLength(0) - 1, arr.GetLength(1)];
            for (int i=0; i<k-1; i++)
            {
                for(int j=0; j<newArr.GetLength(1);j++)
                {
                    newArr[i,j] = arr[i,j];
                }    
            }
            for (int i = k-1; i < newArr.GetLength(0); i++)
            {
                for (int j = 0; j < newArr.GetLength(1); j++)
                {
                    newArr[i, j] = arr[i+1, j];
                }
            }
            return newArr;
        }

        //Tìm Cột chứa phần tử lớn nhất
        static int GetColIndexofMaxValue(int[,] arr)
        {
            for (int i=0; i<arr.GetLength(0);i++)
            {
                for(int j=0; j<arr.GetLength(1);j++)
                {
                    if (arr[i, j] == FindMax(arr)) return j;
                }    
            }
            return -1;
        }

        //Xóa cột có index k
        static int[,] RemoveCol(int[,]arr, int k)
        {
            int[,] newArr = new int[arr.GetLength(0), arr.GetLength(1) - 1];
            for (int i=0;i<k;i++)
            {
                for (int j =0; j<arr.GetLength(0);j++)
                {
                    newArr[j, i] = arr[j, i];
                }    
            }
            for (int i = k; i < newArr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    newArr[j, i] = arr[j, i+1];
                }
            }
            return newArr;
        }

        //(f) Xóa cột chứa phần tử lớn nhất
        static int[,] RemoveColsHaveMaxValue(int[,] arr)
        {
            if (arr == null) return null;
            int[,] newArr;
            int MaxValue = FindMax(arr);
            int IndexMaxValue = GetColIndexofMaxValue(arr);
            newArr=RemoveCol(arr, IndexMaxValue);
            // Vì trong ma trận có nhiều phần tử cùng giá trị lớn nhất
            while (FindMax(newArr) ==MaxValue)
            {
                newArr=RemoveCol(newArr, GetColIndexofMaxValue(newArr));
            }    
            return newArr;
        }
    }
}