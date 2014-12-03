using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Consilium.UCaaS.CUCMEntityTemplate;

public partial class DefaultDeviceTemplateControl : System.Web.UI.UserControl
{
    bool IsDefault = true;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //Prepare the UI
    protected override void OnInit(EventArgs e)
    {
        string sPath = HttpContext.Current.Server.MapPath("App_Data\\DefaultTemplate") + "\\DeviceCommon_default.xml";
        IUIBuilder helper = new XMLHelper();
        pnlContainer.Controls.Clear();
        HtmlTable ht = helper.BuildUI(sPath, IsDefault );
        pnlContainer.Controls.Add(ht);
        base.OnInit(e);
    }
}