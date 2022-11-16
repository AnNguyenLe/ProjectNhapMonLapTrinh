using System;
namespace QuanLyCuaHang
{
    public class ThaoTacTheoLoaiHang
    {
        static public ProductItem[] DanhSachThaoTacTrenLoaiHang(ProductItem[] products)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Ban chon thao tac tren LOAI HANG, vui long chon thao tac tiep theo: ");
            Console.WriteLine("- THEM loai hang: Nhap A");
            Console.WriteLine("- XOA loai hang: Nhap B");
            Console.WriteLine("- SUA loai hang: Nhap C");
            Console.WriteLine("- TIM KIEM loai hang: Nhap D");
            Console.WriteLine("- HIEN THI DANH SACH cac loai hang: Nhap E");
            Console.WriteLine("(Trong truong hop nhap khong theo cac loai ke tren - A: THEM san pham se duoc chon mac dinh)");
            Console.Write("Su lua chon cua ban la: ");

            string action = Console.ReadLine();

            switch (action.ToUpper())
            {
                case "A":
                    Console.WriteLine("Ban chon THEM LOAI HANG");
                    return ThaoTacTheoSanPham.ThemSanPhamMoi(products);
                case "B":
                    Console.WriteLine("Ban chon XOA LOAI HANG");
                    return ThaoTacTheoSanPham.XoaSanPham(products);
                case "C":
                    Console.WriteLine("Ban chon SUA/THAY DOI LOAI HANG");
                    return ThaoTacTheoSanPham.ThayDoiSanPham(products);
                case "D":
                    Console.WriteLine("Ban chon TIM KIEM LOAI HANG");
                    return ThaoTacTheoSanPham.TimKiemSanPham(products); ;
                case "E":
                    Console.WriteLine("Ban chon HIEN THI DANH SACH LOAI HANG");
                    ThaoTacHeThong.HienThiDanhSachSanPham(products, "Danh sach loai hang hien co");
                    return products;
                default:
                    Console.WriteLine("Mac dinh - By default: Ban chon THEM LOAI HANG");
                    return ThaoTacTheoSanPham.ThemSanPhamMoi(products);
            }
            Console.WriteLine("--------------------------------------------");
        }
    }
}

