Imports System
Imports System.Collections.Generic

<Serializable> _
Public Class Product
    Implements IEquatable(Of Product)

    Public Property ProductID() As Integer
    Public Property ProductName() As String
    Public Property UnitsOnOrder() As Integer
    Public Property UnitPrice() As Decimal

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal unitsOnOrder As Integer, ByVal price As Decimal)
        ProductID = id
        ProductName = name
        Me.UnitsOnOrder = unitsOnOrder
        UnitPrice = price
    End Sub
    Public Sub New()
    End Sub

    Public Overloads Function Equals(ByVal other As Product) As Boolean Implements IEquatable(Of Product).Equals
        Return Me.ProductID.Equals(other.ProductID)
    End Function
End Class