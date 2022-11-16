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
            Console.WriteLine("(Trong truong hop nhap khong theo cac loai ke tren - A: THEM loai hang se duoc chon mac dinh)");
            Console.Write("Su lua chon cua ban la: ");

            string action = Console.ReadLine();

            switch (action.ToUpper())
            {
                case "A":
                    Console.WriteLine("Ban chon THEM LOAI HANG");
                    return ThemLoaiHangMoi(products);
                case "B":
                    Console.WriteLine("Ban chon XOA LOAI HANG");
                    return XoaLoaiHang(products);
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
        }

        static public void HienThiDanhSachLoaiHang(string[] categoryList, string message)
        {
            Console.WriteLine("----------------");
            Console.WriteLine($"{message}:");
            foreach(string category in categoryList)
            {
                Console.WriteLine($"- {category}");
            }
            Console.WriteLine("----------------");
        }

        static public ProductItem[] ThemLoaiHangMoi(ProductItem[] products)
        {
            string[] uniqueCategoryList = HelperFunctions.GetUniqueCategoryList(products);

            HienThiDanhSachLoaiHang(uniqueCategoryList, "Danh sach loai hang hien co");

            Console.Write("Nhap ten loai hang moi: ");
            string newCategory = Console.ReadLine();

            // Check if newCategory exist in uniqueCategoryList
            if (uniqueCategoryList.Contains(newCategory))
            {
                Console.WriteLine("Loai san pham ban vua nhap KHONG PHAI la loai hang moi");
                return products;
            }

            ProductItem newProduct = new ProductItem();
            Console.WriteLine("Nhap thong tin cho san pham moi cho loai hang ban vua tao:");

            Console.Write("ID cua san pham: ");
            newProduct.id = Console.ReadLine();

            Console.Write("Ten cua san pham: ");
            newProduct.name = Console.ReadLine();

            Console.Write("Han su dung cua san pham - vi du: Jan 1, 2009: ");
            newProduct.expDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Nam san xuat cua san pham - vi du: 2022: ");
            newProduct.yearOfManufacture = Int32.Parse(Console.ReadLine());

            Console.Write("Ten cua nha san xuat: ");
            newProduct.manufacturer = Console.ReadLine();

            newProduct.category = newCategory;

            // Tang kich thuoc cua Array len 1
            Array.Resize(ref products, products.Length + 1);

            // Them 1 san pham moi vao vi tri cuoi cung cua array
            products.SetValue(newProduct, products.Length - 1);

            Console.WriteLine("Chuc mung ban vua tao 1 san pham moi cho loai hang moi thanh cong");
            return products;
        }

        static public ProductItem[] XoaLoaiHang(ProductItem[] products)
        {
            string[] uniqueCategoryList = HelperFunctions.GetUniqueCategoryList(products);

            Console.Write("Nhap loai hang ban muon xoa:");
            string category = Console.ReadLine();

            if (!uniqueCategoryList.Contains(category))
            {
                Console.WriteLine("Khong tim thay loai hang ban vua nhap!");
                return products;
            }

            Console.WriteLine($"Nhung san pham duoc danh dau la loai hang {category} se bi xoa - ban co muon tiep tuc?");
            Console.Write("Nhap 'Yes' neu ban muon tiep tuc: ");

            string userConfirmation = Console.ReadLine();

            if (userConfirmation != "Yes")
            {
                Console.WriteLine("Da dung viec xoa loai hang - Khong san pham nao bi xoa");
                return products;
            }

            ProductItem[] deletedProducts = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsPropValue(item, "category", category));
            ProductItem[] finalProductList = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsNotPropValue(item, "category", category));

            Console.WriteLine($"Da xoa san pham co loai hang la {category} thanh cong!");

            ThaoTacHeThong.HienThiDanhSachSanPham(deletedProducts, "Danh sach san pham da xoa:");

            ThaoTacHeThong.HienThiDanhSachSanPham(finalProductList, "Danh sach san pham con lai:");

            return finalProductList;
        }
    }
}

