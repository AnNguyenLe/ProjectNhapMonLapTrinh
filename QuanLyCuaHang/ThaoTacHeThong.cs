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

            Console.Write("Nhap gia tri: Vi du, ban chon TEN san pham - thi nhap: 'Banh mi': ");
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
                    return ThaoTacHeThong.DanhSachThaoTacTrenSanPham(products);
                    
                //case "2":
                //    Console.WriteLine("Ban chon thao tac theo LOAI HANG - Category");
                //    return ThaoTacHeThong.DanhSachThaoTacTrenLoaiHang(products);
                    
                
                default:
                    Console.WriteLine("Mac dinh - By default, Ban chon thao tac theo SAN PHAM - Product");
                    return ThaoTacHeThong.DanhSachThaoTacTrenSanPham(products);
                    break;
            }
            Console.WriteLine("--------------------------------------------");
        }

        static public ProductItem[] DanhSachThaoTacTrenSanPham(ProductItem[] products)
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

            switch (action.ToUpper())
            {
                case "A":
                    Console.WriteLine("Ban chon THEM SAN PHAM");
                    return ThaoTacHeThong.ThemSanPhamMoi(products);
                case "B":
                    Console.WriteLine("Ban chon XOA SAN PHAM");
                    return ThaoTacHeThong.XoaSanPham(products);
                case "C":
                    Console.WriteLine("Ban chon SUA/THAY DOI SAN PHAM");
                    return ThaoTacHeThong.ThayDoiSanPham(products);
                case "D":
                    Console.WriteLine("Ban chon TIM KIEM SAN PHAM");
                    return ThaoTacHeThong.TimKiemSanPham(products); ;
                default:
                    Console.WriteLine("Mac dinh - By default: Ban chon THEM SAN PHAM");
                    return ThaoTacHeThong.ThemSanPhamMoi(products);
            }
            Console.WriteLine("--------------------------------------------");
        }

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

        static public bool DeterminePropKeyIsPropValue(ProductItem item, string propKey, string propValue)
        {
            Type currentItemType = item.GetType();
            string currentItemPropValue = currentItemType.GetField(propKey).GetValue(item).ToString();
            return currentItemPropValue == propValue;
        }

        static public bool DeterminePropKeyIsNotPropValue(ProductItem item, string propKey, string propValue)
        {
            Type currentItemType = item.GetType();
            string currentItemPropValue = currentItemType.GetField(propKey).GetValue(item).ToString().ToLower();
            // So sanh ca 2 gia tri o cung Lower case de dam bao cung noi dung - case insensitive
            return currentItemPropValue != propValue.ToLower();
        }

        static public ProductItem[] XoaSanPham(ProductItem[] products)
        {
            (string propKey, string propValue) = ThaoTacHeThong.HanhDongTheoDacTinh();
            ProductItem[] deletedProducts = Array.FindAll(products, item => ThaoTacHeThong.DeterminePropKeyIsPropValue(item, propKey, propValue));
            ProductItem[] finalProductList = Array.FindAll(products, item => ThaoTacHeThong.DeterminePropKeyIsNotPropValue(item, propKey, propValue));

            Console.WriteLine("Da xoa san pham thanh cong!");

            ThaoTacHeThong.HienThiDanhSachSanPham(deletedProducts, "Danh sach san pham da xoa:");

            ThaoTacHeThong.HienThiDanhSachSanPham(finalProductList, "Danh sach san pham con lai:");

            return finalProductList;
        }

        static public ProductItem[] TimKiemSanPham(ProductItem[] products)
        {
            (string propKey, string propValue) = ThaoTacHeThong.HanhDongTheoDacTinh();
            ProductItem[] macthProductList = Array.FindAll(products, item => ThaoTacHeThong.DeterminePropKeyIsPropValue(item, propKey, propValue));
            ThaoTacHeThong.HienThiDanhSachSanPham(macthProductList, $"Danh sach san pham phu hop voi {propKey} ban yeu cau:");
            return products;
        }

        static public ProductItem[] ThayDoiSanPham(ProductItem[] products)
        {
            ThaoTacHeThong.HienThiDanhSachSanPham(products, "Hay chon Ma (id) cua san pham ma ban muon cap nhat: ");
            Console.Write("Hay chon Ma (id) cua san pham ma ban muon cap nhat trong danh sach san pham phia tren: ");
            string selectedId = Console.ReadLine();

            int matchProductIndex = Array.FindIndex(products, item => ThaoTacHeThong.DeterminePropKeyIsPropValue(item, "id", selectedId));
            ProductItem oldProduct = products[matchProductIndex];

            (string propKey, string propValue) = ThaoTacHeThong.HanhDongTheoDacTinh();


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

