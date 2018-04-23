using System;
using System.Collections.Generic;

[Serializable]
public class Product : IEquatable<Product> {
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int UnitsOnOrder { get; set; }
    public decimal UnitPrice { get; set; }

    public Product(int id, string name, int unitsOnOrder, decimal price) {
        ProductID = id;
        ProductName = name;
        UnitsOnOrder = unitsOnOrder;
        UnitPrice = price;
    }
    public Product() { }

    public bool Equals(Product other) {
        return this.ProductID.Equals(other.ProductID);
    }
}