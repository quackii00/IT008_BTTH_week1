using System;


namespace BTTH_Bai03_04_05
{
    public class Program
    {
        static void Main(String[] args)
        {
            byte Option;
            Date userDate = new Date();
            do
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Nhap ngay/thang/nam va kiem tra ngay hop le");
                Console.WriteLine("2. Nhap thang/nam va in ra so ngay cua thang do");
                Console.WriteLine("3. Nhap ngay/thang/nam va in ra thu trong tuan");
                Console.WriteLine("0. Thoat");
                Console.Write("Lua chon: ");

                if (!byte.TryParse(Console.ReadLine(), out Option))
                {
                    Console.WriteLine("Nhap khong hop le. Thu lai!");
                    continue;
                }

              
                switch (Option)
                {
                    //(a)
                    case 1:
                        {
                            Console.WriteLine("Kiem tra tinh hop le cua ngay thang nam");
                            userDate.ReadDate();
                            userDate.GetDate();
                            Console.WriteLine((userDate.IsValidDate())? 
                                " la Ngay Hop le" : " la Ngay Khong Hop le");
                            break;
                        }
                    //(b)
                    case 2:
                        {
                            Console.WriteLine("Tim so ngay trong thang dua vao thang va nam");
                            userDate.ReadMonthAndYear();
                            Console.WriteLine($"So ngay trong thang {userDate.GetMonth()}/{userDate.GetYear()} la {userDate.GetDaysInMonth()}"); 
                            break;
                        }
                    //(c)
                    case 3:
                        {
                            Console.WriteLine("Tim thu trong tuan dua vao ngay thang nam");
                            userDate.ReadDate();
                            while (!userDate.IsValidDate())
                            {
                                Console.WriteLine("Ngay khong hop le, Hay nhap lai!");
                                userDate.ReadDate();
                            }    
                            userDate.GetDate();
                            Console.WriteLine( $" la : {userDate.DayOfWeek()}");
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Ket thuc chuong trinh");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Moi chon lai !");
                            break;
                        }
                }
            } while (Option !=0);  
        }
    }
    public class Date
    {
        private int Day;
        private int Month;
        private int Year;

        public Date( int Day =1, int Month = 1, int Year = 1)
        {
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
        }

        //Xuat Ngày/Tháng/Năm
        public void GetDate()
        {
            Console.Write($"{Day}/{Month}/{Year}");
        }

        //Lấy giá trị Month
        public int GetMonth()
        {
            return Month;
        }
        public int GetYear()
        {
            return Year;
        }
        //Nhập số nguyên trong khoảng max, min
        public int ReadIntInRange(string note, int min, int max)
        {
            int num;
            do
            {
                Console.Write(note);
            } while (!int.TryParse(Console.ReadLine(), out num)
                || num > max || num < min);
            return num;
        }

        //Nhập số nguyên khác 0
        public int ReadIntNot0(string note)
        {
            int num;
            do
            {
                Console.Write(note);
            } while (!int.TryParse(Console.ReadLine(), out num)
                || num ==0);
            return num;
        }

        //Nhập ngày tháng năm từ bàn phím
        public void ReadDate()
        {
            this.Day = ReadIntInRange("Nhap Ngay (1-31) : ", 1, 31);
            this.Month = ReadIntInRange("Nhap Thang(1 - 12) : ", 1, 12);
            this.Year = ReadIntNot0("Nhap Nam (Khac 0): ");
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
            Console.Write("Nhap Thang ( 1-12): ");
            this.Month = byte.Parse(Console.ReadLine());
            Console.Write("Nhap Nam (khac 0): ");
            this.Year = int.Parse(Console.ReadLine());
        }
       
        //Trả về số ngày của tháng khi biết tháng và năm
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

        //Trả về Thứ trong tuần
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

            string[] days = { "Thu bay", "Chu nhat", "Thu hai", "Thu ba", "Thu tu", "Thu nam", "Thu sau" };
            return days[(h + 7) % 7];
        }
    }
}

