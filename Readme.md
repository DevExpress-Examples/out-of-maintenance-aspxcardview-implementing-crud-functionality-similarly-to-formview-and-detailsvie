# ASPxCardView - Implementing CRUD functionality similarly to FormView and DetailsView


<p>This example illustrates how to implement CRUD (create, read, update, delete) operations in the manner supported by FormView and DetailsView. In other words, records should be edited one by one. The easiest way to accomplish this task is to use <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxCardViewtopic"><strong>ASPxCardView</strong></a>. This control supports data binding and data editing operations out of the box. It also provides the form-like layout and allows you to generate required editors with ease. <br><br>Click the "<strong>Show Implementation Details</strong>" button below to see a step-by-step guide on how to implement this scenario. </p>


<h3>Description</h3>

<p>The main steps to implement this scenario are as follows.<br>1. Bind the <strong>ASPxCardView</strong> control to a data source component with Insert, Update and Delete operations enabled. In this example, the <a href="https://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.objectdatasource(v=vs.110).aspx"><strong>ObjectDataSource</strong> </a>component is used.<br>2. Add the <strong>CardLayoutProperties -&gt;&nbsp;</strong><a href="https://documentation.devexpress.com/#AspNet/DevExpressWebCardViewFormLayoutProperties_Itemstopic"><strong>Items </strong></a>and <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxCardView_Columnstopic"><strong>Columns</strong></a>&nbsp;automatically or manually.<br>3.&nbsp;Specify the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridBase_KeyFieldNametopic"><strong>ASPxCardView.KeyFieldName</strong></a>&nbsp;property.<br>4. Set <strong>ASPxCardView&nbsp;</strong> -&gt;&nbsp;<a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxCardView_SettingsPagertopic"><strong>SettingsPager</strong></a><strong>&nbsp;-</strong>&gt; <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxCardViewPagerSettings_SettingsTableLayouttopic"><strong>SettingsTableLayout</strong></a>.<a href="https://documentation.devexpress.com/#AspNet/DevExpressWebCardViewTableLayoutSettings_ColumnCounttopic"><strong>ColumnCount</strong></a> and <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebCardViewTableLayoutSettings_RowsPerPagetopic"><strong>SettingsTableLayout.RowsPerPage</strong></a> to <strong>1</strong>.<br><br>All these operations can be performed via <strong>ASPxCardView's Designer&nbsp;<a href="https://www.screencast.com/t/NepLtAi1vqDu">(video)</a>.</strong><br><br>On the insert operation, <strong>ASPxCardView</strong> adds an empty card on top of an existing one, so two cards are shown on a page. If you wish to avoid this behavior, handle the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxCardView_InitNewCardtopic"><strong>ASPxCardView.InitNewCard</strong></a>&nbsp;event and filter <strong>ASPxCardView</strong> so that it returns 0 records. Then, restore <strong>ASPxCardView</strong> to its initial state on<strong> Page.Load</strong>:</p>
<code lang="cs">  public bool processNewCard;
    protected void Page_Load(object sender, EventArgs e) {
        if (!processNewCard) {
            ASPxCardView1.FilterExpression = "";
        }
        else
            processNewCard = false;
    }
    protected void ASPxCardView1_InitNewCard(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e) {
        processNewCard = true;
        if (ASPxCardView1.IsNewCardEditing)
            ASPxCardView1.FilterExpression = "false";
    }
</code>
<p>&nbsp;</p>
<p>&nbsp;</p>
<code lang="vb"> Public processNewCard As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not processNewCard Then
            ASPxCardView1.FilterExpression = ""
        Else
            processNewCard = False
        End If
    End Sub
    Protected Sub ASPxCardView1_InitNewCard(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs)
        processNewCard = True
        If ASPxCardView1.IsNewCardEditing Then
            ASPxCardView1.FilterExpression = "false"
        End If
    End Sub
</code>
<p>&nbsp;</p>
<p>In addition to that, this example illustrates how to navigate to a newly inserted record automatically. Note that this scenario requires&nbsp;the key value of the inserted record right after the insertion. So, the&nbsp;solution may vary for different data sources and configurations. In this example, the <strong>ObjectDataSource.Inserted</strong> event is used to get the record key. To navigate to the required page, use the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridBase_PageIndextopic"><strong>ASPxCardView.PageIndex</strong></a><strong>&nbsp;</strong>property:</p>
<code lang="cs">protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e) {
        int? key = (int?)e.ReturnValue;
        if (key != null)
            ASPxCardView1.PageIndex = ASPxCardView1.FindVisibleIndexByKeyValue(key);
    }</code>
<code lang="vb">Protected Sub ObjectDataSource1_Inserted(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs)
        Dim key? As Integer = DirectCast(e.ReturnValue, Integer?)
        If key IsNot Nothing Then
            ASPxCardView1.PageIndex = ASPxCardView1.FindVisibleIndexByKeyValue(key)
        End If
    End Sub
</code>
<p>&nbsp;</p>

<br/>


