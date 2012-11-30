using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using System.Data;

namespace New_Service_Request.Edit_Service_Request
{
    public partial class Edit_Service_RequestUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                  
                   
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        SPSite site = SPContext.Current.Site;
                        SPWeb web = site.OpenWeb();
                        SPList list = web.Lists["Service Requests"];
                        var chf = (SPFieldChoice)list.Fields["Priority"];
                        ddlPriority.Items.Clear();
                        foreach (string choose in chf.Choices)
                        {

                            ddlPriority.Items.Add(choose);
                        }

                        ddlkeyword.Items.Clear();
                        //ddlkeyword.Items.Add("--select--");
                        var spv = (SPFieldLookup)list.Fields["Keywords"];
                        var mainlkup = spv.LookupList;
                        var lookupList = web.Lists[new Guid(mainlkup)];

                        foreach (SPListItem item in lookupList.Items)
                        {
                            var value = item[spv.LookupField].ToString();
                            ddlkeyword.Items.Add(value);
                        }

                        if (list != null)
                        {
                            
                            //SPList Servicerequest = web.Lists["Service Requests"];

                            var collection = SPContext.Current.Web.Lists.TryGetList("Service Requests").GetItems();
                            foreach (SPListItem item in collection)
                            {
                                var listItem = new ListItem(item["Service Request ID"].ToString());
                                ddlSerReqID.Items.Add(listItem);
                            }
                            loadform();
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
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
        public void loadform()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;
                    var leaveList = web.Lists.TryGetList("Service Requests");
                    var collection = GetListItemCollection(leaveList, "Service Request ID", ddlSerReqID.SelectedItem.Text);

                    // var collection = SPContext.Current.Web.Lists.TryGetList("Service Requests").GetItems();
                    //ddlTitle.Items.Add("--Select--");
                    if (collection.Count > 0)
                    {
                        foreach (SPListItem item in collection)
                        {
                            //var currenttitle = item["Service Request ID"].ToString();
                            //var ddlTitlebox = ddlSerReqID.SelectedValue;



                            txtTitle.Text = item["Service Request Title"].ToString();
                            txtDetails.Text = item["Service Request Details"].ToString();
                            txtIssueRisk.Text = item["Issues Risks"].ToString();
                            // txtkeyword.Text = item["Keywords"].ToString();
                            ddlPriority.SelectedItem.Text = item["Priority"].ToString();
                            txtRequestor.Text = item["Requestor"].ToString();
                            txtPhoneNO.Text = item["Phone Number"].ToString();
                            txtEmail.Text = item["Email Address"].ToString();
                            HiddenFieldID.Value = item["ID"].ToString();


                        }
                    }

                }

            });


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.Lists["Service Requests"];
                        SPListItem item = list.GetItemById(Convert.ToInt32(HiddenFieldID.Value));
                        item["Service Request Title"] = txtTitle.Text;
                        item["Service Request Details"] = txtDetails.Text;
                        item["Issues Risks"] = txtIssueRisk.Text;
                        //string key = ddlkeyword.SelectedValue;
                        var spv = (SPFieldLookup)list.Fields["Keywords"];
                        var mainlkup = spv.LookupList;
                        var lookupList = web.Lists[new Guid(mainlkup)];
                        item["Keywords"] = GetLookFieldIDS(ddlkeyword.SelectedValue, lookupList);
                        item["Priority"] = ddlPriority.SelectedValue;
                        item["Requestor"] = txtRequestor.Text;
                        item["Phone Number"] = txtPhoneNO.Text;
                        item["Email Address"] = txtEmail.Text;
                        if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtDetails.Text) && !string.IsNullOrEmpty(txtPhoneNO.Text) && !string.IsNullOrEmpty(txtEmail.Text))
                        {

                            item.Update();
                            lblerror.Visible = true;
                            lblerror.Text = "Service Request Successfully Updated";
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

                lblerror.Text = ex.Message;

            }
        }

        protected void ddlSerReqID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;
                    var leaveList = web.Lists.TryGetList("Service Requests");
                    var collection = GetListItemCollection(leaveList, "Service Request ID", ddlSerReqID.SelectedItem.Text);

                    // var collection = SPContext.Current.Web.Lists.TryGetList("Service Requests").GetItems();
                    //ddlTitle.Items.Add("--Select--");
                    if (collection.Count > 0)
                    {
                        foreach (SPListItem item in collection)
                        {
                            //var currenttitle = item["Service Request ID"].ToString();
                            //var ddlTitlebox = ddlSerReqID.SelectedValue;



                            txtTitle.Text = item["Service Request Title"].ToString();
                            txtDetails.Text = item["Service Request Details"].ToString();
                            txtIssueRisk.Text = item["Issues Risks"].ToString();
                            // txtkeyword.Text = item["Keywords"].ToString();
                            ddlPriority.SelectedItem.Text = item["Priority"].ToString();
                            txtRequestor.Text = item["Requestor"].ToString();
                            txtPhoneNO.Text = item["Phone Number"].ToString();
                            txtEmail.Text = item["Email Address"].ToString();
                            HiddenFieldID.Value = item["ID"].ToString();


                        }
                    }

                }

            });
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string link = SPContext.Current.Site.Url;

            Response.Redirect(link);
        }

    }
}

