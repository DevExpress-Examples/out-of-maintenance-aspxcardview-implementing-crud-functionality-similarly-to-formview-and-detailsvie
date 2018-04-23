Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Web
Imports System.Linq

<DataObject(True)> _
Public Class ProductDataContext
    Private Shared Property Products() As List(Of Product)
        Get
            If HttpContext.Current.Session("Products") Is Nothing Then
                Dim list As New List(Of Product)()
                list.Add(New Product(0, "Apples", 1, 10.0D))
                list.Add(New Product(1, "Gingerbread", 10, 15.0D))
                list.Add(New Product(2, "Yogurt", 12, 20.0D))
                HttpContext.Current.Session("Products") = list
                Return list
            Else
                Return DirectCast(HttpContext.Current.Session("Products"), List(Of Product))
            End If
        End Get
        Set(ByVal value As List(Of Product))
            HttpContext.Current.Session("Products") = value
        End Set
    End Property
    <DataObjectMethod(DataObjectMethodType.Select, True)> _
    Public Function GetProducts() As List(Of Product)
        Return Products
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function InsertProduct(ByVal product As Product) As Integer

        Dim products_Renamed As List(Of Product) = Products
        product.ProductID = If(Products.Count = 0, 0, Products.Max(Function(i) i.ProductID) + 1)
        products_Renamed.Add(product)
        Return product.ProductID
    End Function

    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Sub UpdateProduct(ByVal product As Product)

        Dim products_Renamed As List(Of Product) = Products
        Dim productToUpdate = products_Renamed.Find(Function(p) p.ProductID = product.ProductID)
        productToUpdate.ProductName = product.ProductName
        productToUpdate.UnitPrice = product.UnitPrice
        productToUpdate.UnitsOnOrder = product.UnitsOnOrder
    End Sub

    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Sub DeleteProduct(ByVal product As Product)

        Dim products_Renamed As List(Of Product) = Products
        products_Renamed.Remove(product)
    End Sub
End Class