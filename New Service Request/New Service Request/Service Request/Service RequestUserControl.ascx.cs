using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.WebControls;

namespace New_Service_Request.Service_Request
{
    public partial class Service_RequestUserControl : UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try{
            if (!Page.IsPostBack)
            {


                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    //SPSite site = new SPSite(SPContext.Current.Site.Url +\Support");

                    SPSite site = new SPSite("http://devsp1:43647/Support/");
                   // SPSite site = SPContext.Current.Site.Url;
                    SPWeb web = site.OpenWeb();

                    SPList list = web.Lists["Service Requests"];
                    var chf = (SPFieldChoice)list.Fields["Priority"];
                    ddlPriority.Items.Clear();
                    ddlPriority.Items.Add("--Select--");
                    foreach (string choose in chf.Choices)
                    {
                        ddlPriority.Items.Add(choose);
                    }

                    ddlkeyword.Items.Clear();
                    ddlkeyword.Items.Add("--select--");
                    var spv = (SPFieldLookup)list.Fields["Keywords"];
                    var mainlkup = spv.LookupList;
                    var lookupList = web.Lists[new Guid(mainlkup)];

                    foreach (SPListItem item in lookupList.Items)
                    {
                        var value = item[spv.LookupField].ToString();
                        ddlkeyword.Items.Add(value);
                    }


                });
            }
            }
            catch (Exception ex)
            {
                lblerror.Visible = true;
                lblerror.Text = ex.Message;
            }
        }

        public static SPFieldLookupValueCollection GetLookFieldIDS(string lookupValues, SPList lookupSourceList)
        {
            SPFieldLookupValueCollection lookupIds = new SPFieldLookupValueCollection();
            string[] lookups = lookupValues.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string lookupValue in lookups)
            {
                SPQuery query = new Microsoft.SharePoint.SPQuery();
                query.Query = String.Format("<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>{0}</Value></Eq></Where>", lookupValue);
                SPListItemCollection listItems = lookupSourceList.GetItems(query);
                foreach (Microsoft.SharePoint.SPListItem item in listItems)
                {
                    SPFieldLookupValue value = new SPFieldLookupValue(item.ID.ToString());
                    lookupIds.Add(value);
                    break;
                }
            }
            return lookupIds;
        }


        //public void FirstList()
        //{

        //    try
        //    {

        //        SPSecurity.RunWithElevatedPrivileges(delegate()
        //       {
        //           using (SPSite site = new SPSite(SPContext.Current.Site.Url))
        //           {
        //               SPWeb web = site.OpenWeb();
        //               web.AllowUnsafeUpdates = true;
        //               SPList list = web.Lists["Service Requests"];
        //               SPListItem items = list.Items.Add();
        //               string currenttime = DateTime.Now.ToString("Mdyyyyhhmmss");

        //               items["Service Request ID"] = currenttime;
        //               items["Service Request Title"] = txtTitle.Text;
        //               items["Service Request Details"] = txtDetails.Text;
        //               items["Issues Risks"] = txtIssueRisk.Text;
        //               //string key = ddlkeyword.SelectedValue;
        //               var spv = (SPFieldLookup)list.Fields["Keywords"];
        //               var mainlkup = spv.LookupList;
        //               var lookupList = web.Lists[new Guid(mainlkup)];
        //               items["Keywords"] = GetLookFieldIDS(ddlkeyword.SelectedValue, lookupList);
        //               items["Priority"] = ddlPriority.SelectedValue;
        //               items["Requestor"] = txtRequestor.Text;
        //               items["Phone Number"] = txtPhoneNO.Text;
        //               items["Email Address"] = txtEmail.Text;
        //               if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtDetails.Text) && !string.IsNullOrEmpty(txtPhoneNO.Text) && !string.IsNullOrEmpty(txtEmail.Text))
        //               {

        //                   items.Update();

        //                   lblDatetimesec.Text = currenttime;
        //                   lblerror.Visible = true;
        //                   lblerror.Text = "You have successfully submitted the Service Request, Please note the Service Request ID for Further enquiry";
        //               }
        //               else
        //               {
        //                   lblerror.Visible = true;
        //                   lblerror.Text = "All fields are Required";
        //               }

        //           }

        //       });


        //    }

        //    catch (Exception ex)
        //    {

        //        lblerror.Text = ex.Message;

        //    }
        //}




        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite("http://devsp1:43647/Support/"))
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.Lists["Service Requests"];
                        SPListItem items = list.Items.Add();
                        string currenttime = DateTime.Now.ToString("Mdyyyyhhmmss");

                        items["Service Request ID"] = currenttime;
                        items["Service Request Title"] = txtTitle.Text;
                        items["Service Request Details"] = txtDetails.Text;
                        items["Issues/Risks"] = txtIssueRisk.Text;
                        //string key = ddlkeyword.SelectedValue;
                        var spv = (SPFieldLookup)list.Fields["Keywords"];
                        var mainlkup = spv.LookupList;
                        var lookupList = web.Lists[new Guid(mainlkup)];
                        items["Keywords"] = GetLookFieldIDS(ddlkeyword.SelectedValue, lookupList);
                        items["Priority"] = ddlPriority.SelectedValue;
                        items["Requestor"] = txtRequestor.Text;
                        items["Phone Number"] = txtPhoneNO.Text;
                        items["Email Address"] = txtEmail.Text;
                        if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtDetails.Text) && !string.IsNullOrEmpty(txtPhoneNO.Text) && !string.IsNullOrEmpty(txtEmail.Text))
                        {

                            items.Update();

                            lblDatetimesec.Text = currenttime;
                            lblerror.Visible = true;
                            lblerror.Text = "You have successfully submitted the Service Request, Please note the Service Request ID for Further enquiry";
                        }
                        else
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "All fields are Required";
                        }

                    }

                });


            }

            catch (Exception ex)
            {
                lblerror.Visible = true;
                lblerror.Text = ex.Message;

            }

            txtTitle.ReadOnly = true;
            txtDetails.ReadOnly = true;
            txtIssueRisk.ReadOnly = true;
            ddlkeyword.Enabled = false;
            ddlPriority.Enabled = false;
            txtRequestor.ReadOnly = true;
            txtPhoneNO.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtTitle.Focus();
            Button1.Enabled = false;

        }

       
        protected void Button2_Click(object sender, EventArgs e)
        {
            // Response.Redirect("/default.aspx");
            txtTitle.ReadOnly = false;
            txtDetails.ReadOnly = false;
            txtIssueRisk.ReadOnly = false;
            ddlkeyword.Enabled = true;
            ddlPriority.Enabled = true;
            txtRequestor.ReadOnly = false;
            txtPhoneNO.ReadOnly = false;
            txtEmail.ReadOnly = false;
            Button1.Enabled = true;
            txtTitle.Text = "";
            txtDetails.Text = "";
            txtIssueRisk.Text = "";
            ddlPriority.SelectedValue = "(3) Low";
            txtRequestor.Text = "";
            txtPhoneNO.Text = "";
            txtEmail.Text = "";
            txtTitle.Focus();
            lblDatetimesec.Text = "";
            txtTitle.Focus();

        }




    }

}
