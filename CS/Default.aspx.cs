using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    public bool processNewCard;
    protected void Page_Load(object sender, EventArgs e) {
        if (!processNewCard) {
            ASPxCardView1.FilterExpression = "";
        }
        else
            processNewCard = false;
    }
    protected void ASPxCardView1_InitNewCard(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e) {
        //Hiding an existing card on a page on inserting
        processNewCard = true;
        if (ASPxCardView1.IsNewCardEditing)
            ASPxCardView1.FilterExpression = "false";
    }

    protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e) {
        //Moving to the newly inserted record
        int? key = (int?)e.ReturnValue;
        if (key != null)
            ASPxCardView1.PageIndex = ASPxCardView1.FindVisibleIndexByKeyValue(key);
    }
}