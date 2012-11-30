using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace LookUp.Lookup
{
    public partial class LookupUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPSite site = new SPSite("http://sp2010/");
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists["Service Requests"];
            ddlLookup.Items.Clear();
            ddlLookup.Items.Add("--select--");
            var spv = (SPFieldLookup) list.Fields["Keywords"];
            var mainlkup = spv.LookupList;            
            var lookupList = web.Lists[new Guid(mainlkup)];

            foreach(SPListItem item in lookupList.Items)
            {

                var value = item[spv.LookupField].ToString();
                ddlLookup.Items.Add(value);
            }
            

            
            //ddlLookup.Items.Clear();
            //ddlLookup.Items.Add("--select--");

            //    var spv = (SPFieldLookup) employeeLeaveType["Keywords"].ToString());
            //    ddlLookup.Items.Add(spv.LookupValue);

        }

    }




}

