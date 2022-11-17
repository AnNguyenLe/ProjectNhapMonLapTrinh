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

            string action = ThaoTacHeThong.NhapGiaTri();

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
                    return ThayDoiLoaiHang(products);
                case "D":
                    Console.WriteLine("Ban chon TIM KIEM LOAI HANG");
                    return TimKiemLoaiHang(products); ;
                case "E":
                    Console.WriteLine("Ban chon HIEN THI DANH SACH LOAI HANG");
                    string[] uniqueCategoryList = HelperFunctions.GetUniqueCategoryList(products);
                    HienThiDanhSachLoaiHang(uniqueCategoryList, "Danh sach loai hang hien co");
                    return products;
                default:
                    Console.WriteLine("Mac dinh - By default: Ban chon THEM LOAI HANG");
                    return ThemLoaiHangMoi(products);
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
            string newCategory = ThaoTacHeThong.NhapGiaTri();

            // Check if newCategory exist in uniqueCategoryList
            if (uniqueCategoryList.Contains(newCategory))
            {
                Console.WriteLine("Loai san pham ban vua nhap KHONG PHAI la loai hang moi");
                return products;
            }

            ProductItem newProduct = new ProductItem();
            Console.WriteLine("Nhap thong tin cho san pham moi cho loai hang ban vua tao:");

            Console.Write("ID cua san pham: ");
            newProduct.id = ThaoTacHeThong.NhapGiaTri();

            Console.Write("Ten cua san pham: ");
            newProduct.name = ThaoTacHeThong.NhapGiaTri();

            Console.Write("Han su dung cua san pham - vi du: Jan 1, 2009: ");
            newProduct.expDate = DateTime.Parse(ThaoTacHeThong.NhapGiaTri());

            Console.Write("Nam san xuat cua san pham - vi du: 2022: ");
            newProduct.yearOfManufacture = int.Parse(ThaoTacHeThong.NhapGiaTri());

            Console.Write("Ten cua nha san xuat: ");
            newProduct.manufacturer = ThaoTacHeThong.NhapGiaTri();

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
            string category = ThaoTacHeThong.NhapGiaTri();

            if (!uniqueCategoryList.Contains(category))
            {
                Console.WriteLine("Khong tim thay loai hang ban vua nhap!");
                return products;
            }

            Console.WriteLine($"Nhung san pham duoc danh dau la loai hang {category} se bi xoa - ban co muon tiep tuc?");
            Console.Write("Nhap 'Yes' neu ban muon tiep tuc: ");

            string userConfirmation = ThaoTacHeThong.NhapGiaTri();

            if (userConfirmation.ToLower() != "yes")
            {
                Console.WriteLine("Da dung viec xoa loai hang - Khong san pham nao bi xoa");
                return products;
            }

            ProductItem[] deletedProducts = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsPropValue(item, Constants.PROP_KEY_CATEGORY, category));
            ProductItem[] finalProductList = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsNotPropValue(item, Constants.PROP_KEY_CATEGORY, category));

            Console.WriteLine($"Da xoa san pham co loai hang la {category} thanh cong!");

            ThaoTacHeThong.HienThiDanhSachSanPham(deletedProducts, "Danh sach san pham da xoa:");

            ThaoTacHeThong.HienThiDanhSachSanPham(finalProductList, "Danh sach san pham con lai:");

            return finalProductList;
        }

        static public ProductItem[] TimKiemLoaiHang(ProductItem[] products)
        {
            string[] uniqueCategoryList = HelperFunctions.GetUniqueCategoryList(products);
            Console.WriteLine("Hien tai co nhung loai hang sau day:");
            HienThiDanhSachLoaiHang(uniqueCategoryList, "Danh sach loai hang hien co");
            Console.Write("Nhap loai hang ban muon tim kiem: ");
            string searchCategory = ThaoTacHeThong.NhapGiaTri();

            if (!uniqueCategoryList.Contains(searchCategory))
            {
                Console.WriteLine("Khong tim thay loai hang ban vua nhap!");
                return products;
            }

            ProductItem[] matchedProducts = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsPropValue(item, Constants.PROP_KEY_CATEGORY, searchCategory));
            ThaoTacHeThong.HienThiDanhSachSanPham(matchedProducts, $"Danh sach san pham duoc phan loai la {searchCategory}: ");
            return products;
        }

        static public ProductItem[] ThayDoiLoaiHang(ProductItem[] products)
        {
            string[] uniqueCategoryList = HelperFunctions.GetUniqueCategoryList(products);
            Console.WriteLine("Hien tai co nhung loai hang sau day:");
            HienThiDanhSachLoaiHang(uniqueCategoryList, "Danh sach loai hang hien co");
            Console.Write("Nhap loai hang ban muon thay doi: ");

            string searchCategory = ThaoTacHeThong.NhapGiaTri();

            if (!uniqueCategoryList.Contains(searchCategory))
            {
                Console.WriteLine("Khong tim thay loai hang ban vua nhap!");
                return products;
            }

            Console.Write($"Nhap ten loai hang moi thay the cho {searchCategory}: ");
            string updatedCategory = ThaoTacHeThong.NhapGiaTri();

            Console.WriteLine($"Nhung san pham duoc danh dau la loai hang {searchCategory} se bi thay doi thanh {updatedCategory} - ban co muon tiep tuc?");
            Console.Write("Nhap 'Yes' neu ban muon tiep tuc: ");

            string userConfirmation = ThaoTacHeThong.NhapGiaTri();

            if (userConfirmation.ToLower() != "yes")
            {
                Console.WriteLine("Da dung viec thay doi loai hang - Khong san pham nao bi thay doi");
                return products;
            }

            ProductItem[] toBeUpdatedProducts = Array.FindAll(products, item => HelperFunctions.DeterminePropKeyIsPropValue(item, Constants.PROP_KEY_CATEGORY, searchCategory));

            for (int i = 0; i < toBeUpdatedProducts.Length; i++)
            {
                ProductItem oldProduct = toBeUpdatedProducts[i];
                int index = Array.IndexOf(products, toBeUpdatedProducts[i]);

                object boxedOldProduct = oldProduct;
                oldProduct.GetType().GetField(Constants.PROP_KEY_CATEGORY)?.SetValue(boxedOldProduct, updatedCategory);
                ProductItem updatedProduct = (ProductItem)boxedOldProduct;

                products[index] = updatedProduct;
            }

            Console.WriteLine($"Da cap nhat san pham co loai hang la {searchCategory} thanh {updatedCategory} thanh cong!");
            ThaoTacHeThong.HienThiDanhSachSanPham(toBeUpdatedProducts, "Danh sach san pham da cap nhat loai hang moi:");

            return products;
        }
    }
}

