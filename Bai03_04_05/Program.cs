using System;
using System.Reflection.Metadata.Ecma335;

namespace BTTH_Bai03_04_05
{
    public class Program
    {
        static void Main(String[] args)
        {
            Date userDate = new Date();
            Console.WriteLine("Chon cac option sau: ");
            Console.WriteLine("1. Nhap ngay thang nam roi kiem tra tinh hop le");
            Console.WriteLine("2. Nhap thang nam roi in ra so ngay cua thang ");
            Console.WriteLine("3. Nhap ngay thang nam roi in ra thu trong tuan");
            Console.Write("Lua chon cua ban la (1,2,3): ");
            byte Option = byte.Parse(Console.ReadLine());
            do
            {
                switch (Option)
                {
                    case 1:
                        {
                            Console.WriteLine("Kiem tra tinh hop le cua ngay thang nam");
                            userDate.ReadDate();
                            Console.WriteLine((userDate.IsValidDate()) ? "Ngay Hop le" : "Ngay Khong Hop le");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Tim so ngay trong thang dua vao thang va nam");
                            userDate.ReadMonthAndYear();
                            Console.WriteLine(userDate.GetDaysInMonth() != 0 ? "So ngay trong thang la {0}" : "Khong the xac dinh vi thang, nam khong hop le", userDate.GetDaysInMonth());
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Tim thu trong tuan dua vao ngay thang nam");
                            userDate.ReadDate();
                            while (!userDate.IsValidDate())
                            {
                                Console.WriteLine("Ngay khong hop le, Hay nhap lai!");
                                userDate.ReadDate();
                            }    
                            Console.WriteLine("Thu trong tuan la: " + userDate.DayOfWeek());
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Moi chon lai Option");
                            break;
                        }
                }
                Console.WriteLine("Chon lai Option hoac nhap 0 de ket thuc chuong trinh");
                Console.Write("Lua chon cua ban la (1,2,3,0): ");
                Option = byte.Parse(Console.ReadLine());
            } while (Option >= 1 && Option <= 3);
                    
           
            
        }
    }
    public class Date
    {
        private int Day;
        private int Month;
        private int Year;
        public Date( int Day =1, int Month = 0, int Year = 0)
        {
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
        }

        //Nhập ngày tháng năm từ bàn phím
        public void ReadDate()
        {
            Console.Write("Nhap Ngay (1-31) : ");
            this.Day = byte.Parse(Console.ReadLine());
            Console.Write("Nhap Thang (1-12) : ");
            this.Month = byte.Parse(Console.ReadLine());
            Console.Write("Nhap Nam (Khac 0): ");
            this.Year= int.Parse(Console.ReadLine());
        }
        

        //Kiểm tra có phải năm nhuận không
        private bool IsLeap()
        {
            return (this.Year % 4 == 0 && this.Year % 100 != 0) || (this.Year % 400 == 0);
        }
        //(a)Kiểm tra Ngày,tháng,năm có hợp lệ không
        public bool IsValidDate()
        {
           if (this.Year ==0) return false;
           switch (this.Month)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        if (this.Day <=0 || this.Day >30) return false;
                        break;
                    }
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        if (this.Day <=0 || this.Day>31) return false;
                        break;
                    }
                case 2:
                    {
                        if (this.Day >29) return false;
                        if (this.Day == 29 && !IsLeap()) return false;
                        break;
                    }
                default:
                    {
                        return false;
                    }

            }
            return true;

        }
        //Nhập tháng và năm
        public void ReadMonthAndYear()
        {
            Console.Write("Nhap Thang : ");
            this.Month = byte.Parse(Console.ReadLine());
            Console.Write("Nhap Nam : ");
            this.Year = int.Parse(Console.ReadLine());
        }
       
        public byte GetDaysInMonth()
        {
            if (!IsValidDate()) return 0;
            switch (this.Month)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        return 30;
                    }
                case 2:
                    {
                        return IsLeap() ? (byte)29 : (byte)28;
                    }
                default:
                    {
                        return 31;
                    }
            }
        }
        public string DayOfWeek()
        {
            int d = Day;
            int m = Month;
            int y = Year;

            if (m < 3)
            {
                m += 12;
                y -= 1;
            }

            int K = y % 100;
            int J = y / 100;

            int h = (d + 13 * (m + 1) / 5 + K + K / 4 + J / 4 + 5 * J) % 7;

            string[] days = { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            return days[(h + 7) % 7];
        }


    }
}

