using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace Service_Request.Submit_Service_Request
{
    public partial class Submit_Service_RequestUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
                       {
                           SPSite site = SPContext.Current.Site;
                           SPWeb web = site.OpenWeb();
                           SPList list = web.Lists["Submit Service Request"];
                           var chf = (SPFieldChoice)list.Fields["Priority"];
                           ddlpriority.Items.Clear();
                           foreach (string choose in chf.Choices)
                           {

                               ddlpriority.Items.Add(choose);
                           }

                       });
        }

        public void FirstList()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.Lists["Submit Service Request"];
                        SPListItem items = list.Items.Add();
                        items["Title"] = txtTitle.Text.ToString();
                        items["Detail"] = txtDetail.Text.ToString();
                        items["Priority"] = ddlpriority.SelectedItem.Text.ToString();
                        items["Name"] = txtName.Text.ToString();
                        items["Phone#"] = txtpno.Text.ToString();
                        items["Email"] = txtemail.Text.ToString();
                        if (txtTitle.Text != null)
                        {
                            if (txtDetail.Text != null)
                            {
                                if (txtName.Text != null)
                                {
                                    if (txtpno.Text != null)
                                    {

                                        items.Update();
                                    }
                                }
                            }
                        }
                    }

                });
        }

        public void SecondList()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;
                    SPList list = web.Lists["Service Request Tasks"];
                    SPListItem items = list.Items.Add();
                    items["Title"] = txtTitle.Text.ToString();
                    items["Detail"] = txtDetail.Text.ToString();
                    items["Priority"] = ddlpriority.SelectedItem.Text.ToString();
                    items["Name"] = txtName.Text.ToString();
                    items["Phone#"] = txtpno.Text.ToString();
                    items["Email"] = txtemail.Text.ToString();

                    if (txtTitle.Text != null)
                        if (txtDetail.Text != null)
                            if (txtName.Text != null)
                                if (txtpno.Text != null)

                                    items.Update();
                }
            });


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            FirstList();
            SecondList();
            txtTitle.Text = "";
            txtDetail.Text = "";
            txtName.Text = "";
            txtpno.Text = "";
            txtemail.Text = "";
            txtTitle.Focus();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtDetail.Text = "";
            txtName.Text = "";
            txtpno.Text = "";
            txtemail.Text = "";
            txtTitle.Focus();
        }
    }
}
