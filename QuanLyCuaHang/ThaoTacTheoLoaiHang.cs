using System;
namespace QuanLyCuaHang
{
    public class ThaoTacTheoLoaiHang
    {
        static public string DanhSachThaoTacTrenLoaiHang(ProductItem[] products)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Ban chon thao tac theo LOAI HANG, vui long chon thao tac tiep theo: ");
            Console.WriteLine("- THEM loai hang: Nhap A");
            Console.WriteLine("- XOA loai hang: Nhap B");
            Console.WriteLine("- SUA loai hang: Nhap C");
            Console.WriteLine("- TIM KIEM loai hang: Nhap D");
            Console.WriteLine("(Trong truong hop nhap khong theo cac loai ke tren - A: THEM loai hang se duoc chon mac dinh)");
            Console.Write("Su lua chon cua ban la: ");

            string action = Console.ReadLine();

            switch (action)
            {
                case "A":
                    Console.WriteLine("Ban chon THEM LOAI HANG");
                    return action;
                case "B":
                    Console.WriteLine("Ban chon XOA LOAI HANG");
                    return action;
                case "C":
                    Console.WriteLine("Ban chon SUA LOAI HANG");
                    return action;
                case "D":
                    Console.WriteLine("Ban chon TIM KIEM LOAI HANG");
                    return action;
                default:
                    Console.WriteLine("Mac dinh - By default: Ban chon THEM LOAI HANG");
                    return "A";
            }
            Console.WriteLine("--------------------------------------------");
        }
    }
}

