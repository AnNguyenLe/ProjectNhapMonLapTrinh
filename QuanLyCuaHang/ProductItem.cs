using System;
namespace QuanLyCuaHang
{
    public struct ProductItem
    {
        public string id;
        public string name;
        public string expDate;
        public string manufacturer;
        public int yearOfManufacture;
        public string category;

        public ProductItem(string id, string name, string expDate, string yearOfManufacture,  string manufacturer, string category)
        {
            this.id = id;
            this.name = name;
            this.expDate = DateTime.Parse(expDate).ToString("dd/MM/yyyy");
            this.manufacturer = manufacturer;
            this.yearOfManufacture = int.Parse(yearOfManufacture);
            this.category = category;
        }
    }
}

