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
            string selection = ThaoTacHeThong.NhapGiaTri();

            Console.WriteLine("Truong hop tim kiem san pham theo ngay het han: Vui long nhap cu phap DD/MM/YYYY - vi du: Ngay 1 thang 2 nam 2020 se la 01/02/2020.");
            Console.Write("Nhap gia tri: Vi du, ban chon TEN san pham - thi nhap: 'Banh Mi': ");
            string inputValue = ThaoTacHeThong.NhapGiaTri();

            switch (selection)
            {
                case "1":
                    return (Constants.PROP_KEY_NAME, inputValue);
                case "2":
                    return (Constants.PROP_KEY_ID, inputValue);
                case "3":
                    return (Constants.PROP_KEY_EXP_DATE, DateTime.Parse(inputValue).ToString());
                case "4":
                    return (Constants.PROP_KEY_YEAR_OF_MANUFACTURE, inputValue);
                case "5":
                    return (Constants.PROP_KEY_MANUFACTURER, inputValue);
                case "6":
                    return (Constants.PROP_KEY_CATEGORY, inputValue);
                default:
                    return (Constants.PROP_KEY_ID, inputValue);
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

            string action = ThaoTacHeThong.NhapGiaTri();

            switch (action.ToUpper())
            {
                case "A":
                    Console.WriteLine("Ban chon THEM SAN PHAM");
                    return ThemSanPhamMoi(products);
                case "B":
                    Console.WriteLine("Ban chon XOA SAN PHAM");
                    return XoaSanPham(products);
                case "C":
                    Console.WriteLine("Ban chon SUA/THAY DOI SAN PHAM");
                    return ThayDoiSanPham(products);
                case "D":
                    Console.WriteLine("Ban chon TIM KIEM SAN PHAM");
                    return TimKiemSanPham(products); ;
                case "E":
                    Console.WriteLine("Ban chon HIEN THI DANH SACH SAN PHAM");
                    ThaoTacHeThong.HienThiDanhSachSanPham(products, "Danh sach san pham hien co");
                    return products;
                default:
                    Console.WriteLine("Mac dinh - By default: Ban chon THEM SAN PHAM");
                    return ThemSanPhamMoi(products);
            }
        }

        static public ProductItem[] ThemSanPhamMoi(ProductItem[] products)
        {
            ProductItem newProduct = new ProductItem();
            Console.WriteLine("Nhap thong tin cho san pham moi:");

            Console.Write("ID cua san pham: ");
            newProduct.id = ThaoTacHeThong.NhapGiaTri();

            Console.Write("Ten cua san pham: ");
            newProduct.name = ThaoTacHeThong.NhapGiaTri();

            Console.Write("Han su dung cua san pham - vi du: Jan 1, 2009: ");
            newProduct.expDate = DateTime.Parse(ThaoTacHeThong.NhapGiaTri()).ToString("dd/MM/yyyy");

            Console.Write("Nam san xuat cua san pham - vi du: 2022: ");
            newProduct.yearOfManufacture = int.Parse(ThaoTacHeThong.NhapGiaTri());

            Console.Write("Ten cua nha san xuat: ");
            newProduct.manufacturer = ThaoTacHeThong.NhapGiaTri();

            Console.Write("Loai san pham - vi du: Loai san pham cua Banh Mi la Thuc Pham: ");
            newProduct.category = ThaoTacHeThong.NhapGiaTri();

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
            (string propKey, string propValue) = HanhDongTheoDacTinh();
            ProductItem[] deletedProducts = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsPropValue(item, propKey, propValue));
            ProductItem[] finalProductList = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsNotPropValue(item, propKey, propValue));

            Console.WriteLine("Da xoa san pham thanh cong!");

            ThaoTacHeThong.HienThiDanhSachSanPham(deletedProducts, "Danh sach san pham da xoa:");

            ThaoTacHeThong.HienThiDanhSachSanPham(finalProductList, "Danh sach san pham con lai:");

            return finalProductList;
        }

        static public ProductItem[] TimKiemSanPham(ProductItem[] products)
        {
            (string propKey, string propValue) = HanhDongTheoDacTinh();
            string inputExpDate = DateTime.Parse(propValue).ToString("dd/MM/yyyy");

            ProductItem[] macthProductList = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsPropValueCaseInsensitive(item, propKey, inputExpDate));
            ThaoTacHeThong.HienThiDanhSachSanPham(macthProductList, $"Danh sach san pham phu hop voi {propKey} ban yeu cau:");
            return products;
        }

        static public ProductItem[] ThayDoiSanPham(ProductItem[] products)
        {
            ThaoTacHeThong.HienThiDanhSachSanPham(products, "Hay chon Ma (id) cua san pham ma ban muon cap nhat: ");
            Console.Write("Hay chon Ma (id) cua san pham ma ban muon cap nhat trong danh sach san pham phia tren: ");
            string selectedId = ThaoTacHeThong.NhapGiaTri();

            int matchProductIndex = Array.FindIndex(products, item => HelperFunctions.DeterminePropKeyIsPropValue(item, Constants.PROP_KEY_ID, selectedId));
            ProductItem oldProduct = products[matchProductIndex];

            (string propKey, string propValue) = HanhDongTheoDacTinh();


            // Update value cho key trong product da chon
            object boxedOldProduct = oldProduct;
            oldProduct.GetType().GetField(propKey)?.SetValue(boxedOldProduct, propValue);
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

