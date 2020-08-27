<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" ValidateRequest="false" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to implement FormView layout using ASPxCardView</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>How to implement FormView layout using ASPxCardView
        </h1>
        <div>
            <dx:ASPxCardView ID="ASPxCardView1" runat="server" DataSourceID="ObjectDataSource1" Width="800px"
                AutoGenerateColumns="False" KeyFieldName="ProductID" OnInitNewCard="ASPxCardView1_InitNewCard">
                <SettingsPager>
                    <SettingsTableLayout ColumnCount="1" RowsPerPage="1" />
                </SettingsPager>
                <SettingsEditing Mode="EditForm" NewCardPosition="Bottom"></SettingsEditing>
                <Columns>
                    <dx:CardViewTextColumn FieldName="ProductID" ReadOnly="true" Visible="false">
                    </dx:CardViewTextColumn>
                    <dx:CardViewTextColumn FieldName="ProductName" VisibleIndex="0">
                    </dx:CardViewTextColumn>
                    <dx:CardViewSpinEditColumn FieldName="UnitPrice" VisibleIndex="1">
                        <PropertiesSpinEdit DisplayFormatString="c">
                        </PropertiesSpinEdit>
                    </dx:CardViewSpinEditColumn>
                    <dx:CardViewSpinEditColumn FieldName="UnitsOnOrder" VisibleIndex="2">
                        <PropertiesSpinEdit DisplayFormatString="g">
                        </PropertiesSpinEdit>
                    </dx:CardViewSpinEditColumn>
                </Columns>
                <CardLayoutProperties>
                    <Items>
                        <dx:CardViewCommandLayoutItem ShowEditButton="true" ShowNewButton="true" ShowDeleteButton="true"></dx:CardViewCommandLayoutItem>
                        <dx:CardViewColumnLayoutItem ColumnName="ProductName"></dx:CardViewColumnLayoutItem>
                        <dx:CardViewColumnLayoutItem ColumnName="UnitPrice"></dx:CardViewColumnLayoutItem>
                        <dx:CardViewColumnLayoutItem ColumnName="UnitsOnOrder"></dx:CardViewColumnLayoutItem>
                        <dx:EditModeCommandLayoutItem ShowUpdateButton="true" ShowCancelButton="true"></dx:EditModeCommandLayoutItem>
                    </Items>
                </CardLayoutProperties>
            </dx:ASPxCardView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Product"
                DeleteMethod="DeleteProduct"
                InsertMethod="InsertProduct"
                SelectMethod="GetProducts" TypeName="ProductDataContext"
                UpdateMethod="UpdateProduct"
                OnInserted="ObjectDataSource1_Inserted"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>