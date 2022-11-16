using System;
namespace QuanLyCuaHang
{
    public class ThaoTacTheoSanPham
    {
        static public (string, string) HanhDongTheoDacTinh()
        {
            Console.WriteLine("Dua tren:");
            Console.WriteLine("- TEN san pham: Nhap '1'");
            Console.WriteLine("- MA (ID) san pham: Nhap '2'");
            Console.WriteLine("- HAN SU DUNG san pham: Nhap '3'");
            Console.WriteLine("- NAM SAN XUAT san pham: Nhap '4'");
            Console.WriteLine("- NHA SAN XUAT san pham: Nhap '5'");
            Console.WriteLine("- LOAI san pham: Nhap '6'");
            Console.WriteLine("(Lua chon mac dinh la DUA TREN MA (ID) của san pham)");

            Console.Write("Lua chon cua ban la: ");
            string selection = Console.ReadLine();

            Console.Write("Nhap gia tri: Vi du, ban chon TEN san pham - thi nhap: 'Banh Mi': ");
            string inputValue = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    return ("name", inputValue);
                case "2":
                    return ("id", inputValue);
                case "3":
                    return ("expDate", inputValue);
                case "4":
                    return ("yearOfManufacture", inputValue);
                case "5":
                    return ("manufacturer", inputValue);
                case "6":
                    return ("category", inputValue);
                default:
                    return ("id", inputValue);
            }

        }

        static public ProductItem[] DanhSachThaoTacTrenSanPham(ProductItem[] products)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Ban chon thao tac tren SAN PHAM, vui long chon thao tac tiep theo: ");
            Console.WriteLine("- THEM san pham: Nhap A");
            Console.WriteLine("- XOA san pham: Nhap B");
            Console.WriteLine("- SUA san pham: Nhap C");
            Console.WriteLine("- TIM KIEM san pham: Nhap D");
            Console.WriteLine("- HIEN THI DANH SACH cac san pham: Nhap E");
            Console.WriteLine("(Trong truong hop nhap khong theo cac loai ke tren - A: THEM san pham se duoc chon mac dinh)");
            Console.Write("Su lua chon cua ban la: ");

            string action = Console.ReadLine();

            switch (action.ToUpper())
            {
                case "A":
                    Console.WriteLine("Ban chon THEM SAN PHAM");
                    return ThaoTacTheoSanPham.ThemSanPhamMoi(products);
                case "B":
                    Console.WriteLine("Ban chon XOA SAN PHAM");
                    return ThaoTacTheoSanPham.XoaSanPham(products);
                case "C":
                    Console.WriteLine("Ban chon SUA/THAY DOI SAN PHAM");
                    return ThaoTacTheoSanPham.ThayDoiSanPham(products);
                case "D":
                    Console.WriteLine("Ban chon TIM KIEM SAN PHAM");
                    return ThaoTacTheoSanPham.TimKiemSanPham(products); ;
                case "E":
                    Console.WriteLine("Ban chon HIEN THI DANH SACH SAN PHAM");
                    ThaoTacHeThong.HienThiDanhSachSanPham(products, "Danh sach san pham hien co");
                    return products;
                default:
                    Console.WriteLine("Mac dinh - By default: Ban chon THEM SAN PHAM");
                    return ThaoTacTheoSanPham.ThemSanPhamMoi(products);
            }
            Console.WriteLine("--------------------------------------------");
        }

        static public ProductItem[] ThemSanPhamMoi(ProductItem[] products)
        {
            ProductItem newProduct = new ProductItem();
            Console.WriteLine("Nhap thong tin cho san pham moi:");

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

            Console.Write("Loai san pham - vi du: Loai san pham cua Banh Mi la Thuc Pham: ");
            newProduct.category = Console.ReadLine();

            // Tang kich thuoc cua Array len 1
            Array.Resize(ref products, products.Length + 1);

            // Them 1 san pham moi vao vi tri cuoi cung cua array
            products.SetValue(newProduct, products.Length - 1);

            Console.WriteLine("Da them 1 san pham moi thanh cong!");
            ThaoTacHeThong.HienThiDanhSachSanPham(products, "Danh sach san pham da duoc cap nhat nhu sau: ");
            return products;
        }

        static public ProductItem[] XoaSanPham(ProductItem[] products)
        {
            (string propKey, string propValue) = ThaoTacTheoSanPham.HanhDongTheoDacTinh();
            ProductItem[] deletedProducts = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsPropValue(item, propKey, propValue));
            ProductItem[] finalProductList = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsNotPropValue(item, propKey, propValue));

            Console.WriteLine("Da xoa san pham thanh cong!");

            ThaoTacHeThong.HienThiDanhSachSanPham(deletedProducts, "Danh sach san pham da xoa:");

            ThaoTacHeThong.HienThiDanhSachSanPham(finalProductList, "Danh sach san pham con lai:");

            return finalProductList;
        }

        static public ProductItem[] TimKiemSanPham(ProductItem[] products)
        {
            (string propKey, string propValue) = ThaoTacTheoSanPham.HanhDongTheoDacTinh();
            ProductItem[] macthProductList = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsPropValueCaseInsensitive(item, propKey, propValue));
            ThaoTacHeThong.HienThiDanhSachSanPham(macthProductList, $"Danh sach san pham phu hop voi {propKey} ban yeu cau:");
            return products;
        }

        static public ProductItem[] ThayDoiSanPham(ProductItem[] products)
        {
            ThaoTacHeThong.HienThiDanhSachSanPham(products, "Hay chon Ma (id) cua san pham ma ban muon cap nhat: ");
            Console.Write("Hay chon Ma (id) cua san pham ma ban muon cap nhat trong danh sach san pham phia tren: ");
            string selectedId = Console.ReadLine();

            int matchProductIndex = Array.FindIndex(products, item => HelperFunctions.DeterminePropKeyIsPropValue(item, "id", selectedId));
            ProductItem oldProduct = products[matchProductIndex];

            (string propKey, string propValue) = ThaoTacTheoSanPham.HanhDongTheoDacTinh();


            // Update value cho key trong product da chon
            object boxedOldProduct = oldProduct;
            oldProduct.GetType().GetField(propKey).SetValue(boxedOldProduct, propValue);
            ProductItem updatedProduct = (ProductItem)boxedOldProduct;

            // Cap nhat productList
            products[matchProductIndex] = updatedProduct;

            Console.WriteLine("Da cap nhat san pham thanh cong!");

            Console.WriteLine("San pham truoc khi duoc cap nhat: ");
            ThaoTacHeThong.HienThiSanPham(oldProduct);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("San pham sau khi duoc cap nhat: ");
            ThaoTacHeThong.HienThiSanPham(updatedProduct);

            ThaoTacHeThong.HienThiDanhSachSanPham(products, "Danh sach san pham sau khi cap nhat:");
            return products;
        }
    }
}

