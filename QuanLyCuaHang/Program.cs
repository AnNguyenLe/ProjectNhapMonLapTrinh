using System;

namespace QuanLyCuaHang
{
    class Program
    {
        static void Main(string[] args)
        {

            // Khoi tao chuong trinh
            Console.WriteLine("Chao mung ban den voi chuong trinh Quan Ly Cua Hang");

            // San pham dau tien
            ProductItem[] productList = { ThaoTacHeThong.NhapSanPhamMoi() };

            // Xuat danh sach san pham
            ThaoTacHeThong.HienThiDanhSachSanPham(productList);

            while (true)
            {
                // Hoi nguoi dung muon lam gi tiep theo
                ThaoTacHeThong.HienThiPhanLoaiThaoTac();

                

            }

            Console.ReadLine();
        }
    }
}

