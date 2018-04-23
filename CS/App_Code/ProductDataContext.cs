using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Linq;

[DataObject(true)]
public class ProductDataContext {
    private static List<Product> Products {
        get {
            if (HttpContext.Current.Session["Products"] == null) {
                List<Product> list = new List<Product>();
                list.Add(new Product(0, "Apples", 1, 10.0m));
                list.Add(new Product(1, "Gingerbread", 10, 15.0m));
                list.Add(new Product(2, "Yogurt", 12, 20.0m));
                HttpContext.Current.Session["Products"] = list;
                return list;
            }
            else
                return (List<Product>)HttpContext.Current.Session["Products"];
        }
        set {
            HttpContext.Current.Session["Products"] = value;
        }
    }
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public List<Product> GetProducts() {
        return Products;
    }

    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int InsertProduct(Product product) {
        List<Product> products = Products;
        product.ProductID = Products.Count == 0 ? 0 : Products.Max(i => i.ProductID) + 1;
        products.Add(product);
        return product.ProductID;
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static void UpdateProduct(Product product) {
        List<Product> products = Products;
        var productToUpdate = products.Find(p => p.ProductID == product.ProductID);
        productToUpdate.ProductName = product.ProductName;
        productToUpdate.UnitPrice = product.UnitPrice;
        productToUpdate.UnitsOnOrder = product.UnitsOnOrder;
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static void DeleteProduct(Product product) {
        List<Product> products = Products;
        products.Remove(product);
    }
}