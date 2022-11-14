using System;

namespace QuanLyCuaHang
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khoi tao chuong trinh
            Console.WriteLine("Chao mung ban den voi chuong trinh Quan Ly Cua Hang");

            // Sample Array of Products
            ProductItem[] productList = {
                new ProductItem("1", "Banh mi", "Feb 2, 2023", "2022", "Sai Gon", "Thuc Pham"),
                new ProductItem("2", "Xoai", "Jan 1, 2023", "2022", "My Tho", "Trai Cay"),
                new ProductItem("3", "Hu tieu", "Mar 3, 2023", "2022", "My Tho", "Thuc Pham"),
                new ProductItem("4", "Pho", "Apr 4, 2023", "2022", "Ha Noi", "Thuc Pham"),
                new ProductItem("5", "Bun bo", "May 5, 2023", "2022", "Hue", "Thuc Pham"),
                new ProductItem("6", "Mang cut", "Jun 6, 2023", "2022", "Tien Giang", "Trai Cay"),
                new ProductItem("7", "Bot tra xanh", "Jul 7, 2023", "2021", "Uji - Japan", "Thuc Pham"),
                new ProductItem("8", "Cacao", "Aug 8, 2023", "2021", "My Tho", "Thuc Pham"),
                new ProductItem("9", "May xay sinh to", "Sep 9, 2023", "2020", "Philips", "Hang Gia Dung"),
                new ProductItem("10", "Bep dien tu", "Oct 10, 2023", "2019", "Electrolux", "Hang Gia Dung"),
                new ProductItem("11", "Keo", "Nov 11, 2023","2020", "Mars",  "Thuc Pham"),
                new ProductItem("12", "Kem", "Dec 12, 2023", "2021", "Walls", "Thuc Pham")
            };

            // Xuat danh sach san pham
            ThaoTacHeThong.HienThiDanhSachSanPham(productList);

            while (true)
            {
                // Hoi nguoi dung muon lam gi tiep theo
                ThaoTacHeThong.HienThiPhanLoaiThaoTac(productList);
                
            }
            Console.WriteLine("Da thoat khoi chuong trinh - De tiep tuc su dung, ban hay khoi dong lai");
            Console.ReadLine();
        }
    }
}

