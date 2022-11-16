using System;
namespace QuanLyCuaHang
{
    public class ThaoTacHeThong
    {
        
        static public void HienThiSanPham(ProductItem product)
        {
            Console.WriteLine($"Ten san pham: {product.name}");
            Console.WriteLine($"Ma san pham: {product.id}");
            Console.WriteLine($"Han su dung: {product.expDate}");
            Console.WriteLine($"Nam san xuat: {product.yearOfManufacture}");
            Console.WriteLine($"Nha san xuat: {product.manufacturer}");
            Console.WriteLine($"Phan loai san pham: {product.category}");
        }

        static public void HienThiDanhSachSanPham(ProductItem[] productList, string message)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(message);
            for(int i = 0; i < productList.Length; i++)
            {
                ProductItem product = productList[i];
                Console.WriteLine("----------------------");
                ThaoTacHeThong.HienThiSanPham(product);
            }
            Console.WriteLine("--------------------------------------------");
        }

        static public ProductItem[] HienThiPhanLoaiThaoTac(ProductItem[] products)
        {
            Console.WriteLine("Ban muon thao tac theo:");
            Console.WriteLine("- San pham (Product): Nhap so 1");
            Console.WriteLine("- Loai hang (Category): Nhap so 2");
            Console.WriteLine("- De thoat khoi chuong trinh: Nhap so 3");
            Console.WriteLine("(Trong truong hop nhap khong theo cac loai ke tren - 1 se duoc chon mac dinh)");
            Console.Write("Su lua chon cua ban la: ");

            string actionCategory = Console.ReadLine();


            switch (actionCategory)
            {
                case "1":
                    Console.WriteLine("Ban chon thao tac theo SAN PHAM - Product");
                    return ThaoTacTheoSanPham.DanhSachThaoTacTrenSanPham(products);

                case "2":
                    Console.WriteLine("Ban chon thao tac theo LOAI HANG - Category");
                    return ThaoTacTheoLoaiHang.DanhSachThaoTacTrenLoaiHang(products);

                default:
                    Console.WriteLine("Mac dinh - By default, Ban chon thao tac theo SAN PHAM - Product");
                    return ThaoTacTheoSanPham.DanhSachThaoTacTrenSanPham(products);
            }
            Console.WriteLine("--------------------------------------------");
        }
    }
}

