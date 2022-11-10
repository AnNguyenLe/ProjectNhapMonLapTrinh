using System;
namespace QuanLyCuaHang
{
    public class ThaoTacHeThong
    {
        static public ProductItem NhapSanPhamMoi()
        {
            ProductItem product;
            Console.WriteLine("Nhap thong tin cho san pham moi:");

            Console.Write("ID cua san pham: ");
            product.id = Console.ReadLine();

            Console.Write("Ten cua san pham: ");
            product.name = Console.ReadLine();

            Console.Write("Han su dung cua san pham - vi du: Jan 1, 2009: ");
            product.expDate = DateTime.Parse(Console.ReadLine());
            product.yearOfManufacture = product.expDate.Year;

            Console.Write("Ten cua nha san xuat: ");
            product.manufacturer = Console.ReadLine();

            Console.Write("Loai san pham - vi du: Loai san pham cua Banh Mi la Thuc Pham: ");
            product.category = Console.ReadLine();

            return product;
        }

        static public void HienThiDanhSachSanPham(ProductItem[] productList)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Danh sach san pham: ");
            for(int i = 0; i < productList.Length; i++)
            {
                ProductItem product = productList[i];
                Console.WriteLine("----------------------");
                Console.WriteLine($"Ten san pham: {product.name}");
                Console.WriteLine($"Ma san pham: {product.id}");
                Console.WriteLine($"Han su dung: {product.expDate}");
                Console.WriteLine($"Nha san xuat: {product.yearOfManufacture}");
                Console.WriteLine($"Phan loai san pham: {product.category}");
            }
            Console.WriteLine("--------------------------------------------");
        }

        static public void HienThiPhanLoaiThaoTac()
        {
            Console.WriteLine("Ban muon thao tac theo:");
            Console.WriteLine("- San pham (Product): Nhap so 1");
            Console.WriteLine("- Loai hang (Category): Nhap so 2");
            Console.WriteLine("(Trong truong hop nhap khong theo cac loai ke tren - 1 se duoc chon mac dinh)");
            Console.Write("Su lua chon cua ban la: ");

            string actionCategory = Console.ReadLine();


            switch (actionCategory)
            {
                case "1":
                    Console.WriteLine("Ban chon thao tac theo SAN PHAM - Product");
                    ThaoTacHeThong.DanhSachThaoTacTrenSanPham();
                    break;
                case "2":
                    Console.WriteLine("Ban chon thao tac theo LOAI HANG - Category");
                    ThaoTacHeThong.DanhSachThaoTacTrenLoaiHang();
                    break;
                default:
                    Console.WriteLine("Mac dinh - By default, Ban chon thao tac theo SAN PHAM - Product");
                    ThaoTacHeThong.DanhSachThaoTacTrenSanPham();
                    break;
            }
            Console.WriteLine("--------------------------------------------");
        }

        static public void DanhSachThaoTacTrenSanPham()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Ban chon thao tac tren SAN PHAM, vui long chon thao tac tiep theo: ");
            Console.WriteLine("- THEM san pham: Nhap A");
            Console.WriteLine("- XOA san pham: Nhap B");
            Console.WriteLine("- SUA san pham: Nhap C");
            Console.WriteLine("- TIM KIEM san pham: Nhap D");
            Console.WriteLine("(Trong truong hop nhap khong theo cac loai ke tren - A: THEM san pham se duoc chon mac dinh)");
            Console.Write("Su lua chon cua ban la: ");

            string action = Console.ReadLine();

            switch (action)
            {
                case "A":
                    Console.WriteLine("Ban chon THEM SAN PHAM");
                    break;
                case "B":
                    Console.WriteLine("Ban chon XOA SAN PHAM");
                    break;
                case "C":
                    Console.WriteLine("Ban chon SUA SAN PHAM");
                    break;
                case "D":
                    Console.WriteLine("Ban chon TIM KIEM SAN PHAM");
                    break;
                default:
                    Console.WriteLine("Mac dinh - By default: Ban chon THEM SAN PHAM");
                    break;
            }
            Console.WriteLine("--------------------------------------------");
        }

        static public void DanhSachThaoTacTrenLoaiHang()
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
                    break;
                case "B":
                    Console.WriteLine("Ban chon XOA LOAI HANG");
                    break;
                case "C":
                    Console.WriteLine("Ban chon SUA LOAI HANG");
                    break;
                case "D":
                    Console.WriteLine("Ban chon TIM KIEM LOAI HANG");
                    break;
                default:
                    Console.WriteLine("Mac dinh - By default: Ban chon THEM LOAI HANG");
                    break;
            }
            Console.WriteLine("--------------------------------------------");
        }
    }
}

