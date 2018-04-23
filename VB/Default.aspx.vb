Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Public processNewCard As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not processNewCard Then
            ASPxCardView1.FilterExpression = ""
        Else
            processNewCard = False
        End If
    End Sub
    Protected Sub ASPxCardView1_InitNewCard(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs)
        'Hiding an existing card on a page on inserting
        processNewCard = True
        If ASPxCardView1.IsNewCardEditing Then
            ASPxCardView1.FilterExpression = "false"
        End If
    End Sub

    Protected Sub ObjectDataSource1_Inserted(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs)
        'Moving to the newly inserted record
        Dim key? As Integer = DirectCast(e.ReturnValue, Integer?)
        If key IsNot Nothing Then
            ASPxCardView1.PageIndex = ASPxCardView1.FindVisibleIndexByKeyValue(key)
        End If
    End Sub
End Class