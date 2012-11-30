using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using System.Data;
namespace Service_Request.Service_Request_Tasks
{
    public partial class Service_Request_TasksUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
              {
                  using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                  {
                      SPWeb web = site.OpenWeb();
                      web.AllowUnsafeUpdates = true;
                      var list = SPContext.Current.Web.Lists.TryGetList("Service Request Tasks");

                      if (list != null)
                      {
                          ddlTitle.Items.Clear();
                          ddlTitle.Items.Add("--Select--");
                          var collection = GetListItemCollection(list, "AssignedStatus", "Pending");
                          foreach (SPListItem item in collection)
                          {
                              var listItem = new ListItem(item["Title"].ToString());
                              ddlTitle.Items.Add(listItem);
                          }
                      }
                  }

              });
            }
        }



        internal SPListItemCollection GetListItemCollection(SPList spList, string key, string value)
        {
            // Return list item collection based on the lookup field

            SPField spField = spList.Fields[key];
            var query = new SPQuery
            {
                Query = @"<Where>
<Eq>
<FieldRef Name='" + spField.InternalName + @"'/><Value Type='" + spField.Type.ToString() + @"'>" + value + @"</Value>
</Eq>
</Where>"
            };

            return spList.GetItems(query);
        }

        protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;                   
                    var collection = GetListItemCollection(web.Lists["Service Request Tasks"], "AssignedStatus", "Pending");
                    //ddlTitle.Items.Add("--Select--");
                    foreach (SPListItem item in collection)
                    {                       
                        var currenttitle = item["Title"].ToString();
                        var ddlTitlebox = ddlTitle.SelectedValue;

                        if (currenttitle == ddlTitlebox)
                        {

                            txtName.Text = item["Name"].ToString();
                            txtDetail.Text = item["Detail"].ToString();
                            txtemail.Text = item["Email"].ToString();
                            txtpno.Text = item["Phone#"].ToString();
                            txtPriority.Text = item["Priority"].ToString();
                            item.Update();
                        }

                    }

                }

            });
        }

        //ddlTitle.DataValueField = "Title"; // List field holding value - first column is called Title anyway!
        //ddlTitle.DataTextField = "Title"; // List field holding name to be displayed on page 
        //ddlTitle.DataBind();


    }
}
