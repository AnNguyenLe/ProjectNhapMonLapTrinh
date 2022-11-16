using System;
namespace QuanLyCuaHang
{
    public class HelperFunctions
    {
        static public string GetPropValueFromProductItem(ProductItem productItem, string propKey)
        {
            Type currentItemType = productItem.GetType();
            return currentItemType.GetField(propKey).GetValue(productItem).ToString();
        }

        static public bool DeterminePropKeyIsPropValue(ProductItem item, string propKey, string propValue)
        {
            string currentItemPropValue = HelperFunctions.GetPropValueFromProductItem(item, propKey);
            return currentItemPropValue == propValue;
        }

        static public string[] TrimLowercaseSplitString(string inputString)
        {
            return inputString.Trim().ToLower().Split(" ");
        }

        static public bool DeterminePropKeyIsPropValueCaseInsensitive(ProductItem item, string propKey, string propValue)
        {
            string currentItemPropValue = HelperFunctions.GetPropValueFromProductItem(item, propKey);
            string[] currentItemPropValueStringArray = HelperFunctions.TrimLowercaseSplitString(currentItemPropValue);
            string coreContentOfCurrentItemPropValue = String.Join("", currentItemPropValueStringArray);

            string[] propValueStringArray = HelperFunctions.TrimLowercaseSplitString(propValue);
            string coreContentOfPropValue = String.Join("", propValueStringArray);

            return coreContentOfCurrentItemPropValue == coreContentOfPropValue;
        }

        static public bool DeterminePropKeyIsNotPropValue(ProductItem item, string propKey, string propValue)
        {
            string currentItemPropValue = HelperFunctions.GetPropValueFromProductItem(item, propKey).ToLower();
            // So sanh ca 2 gia tri o cung Lower case de dam bao cung noi dung - case insensitive
            return currentItemPropValue != propValue.ToLower();
        }

        static public string[] GetUniqueCategoryList(ProductItem[] products)
        {
            string[] categoryList = new string[products.Length];
            for (int i = 0; i < products.Length; i++)
            {
                categoryList[i] = products[0].category;
            }

            return categoryList.Distinct().ToArray();
        }
    }
}

