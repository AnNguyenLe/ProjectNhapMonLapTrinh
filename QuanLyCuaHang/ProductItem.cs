using System;
namespace QuanLyCuaHang
{
    public struct ProductItem
    {
        public string id;
        public string name;
        public DateTime expDate;
        public string manufacturer;
        public int yearOfManufacture;
        public string category;

        public ProductItem(string id, string name, string expDate, string yearOfManufacture,  string manufacturer, string category)
        {
            this.id = id;
            this.name = name;
            this.expDate = DateTime.Parse(expDate);
            this.manufacturer = manufacturer;
            this.yearOfManufacture = Int32.Parse(yearOfManufacture);
            this.category = category;
        }
    }
}

