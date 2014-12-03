using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Consilium.UCaaS.CUCMEntityTemplate;

public partial class DefaultTemplateTesting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sPath = HttpContext.Current.Server.MapPath("App_Data\\DefaultTemplate") + "\\DeviceCommon_default.xml";
        ControlHelper controlhelper = new ControlHelper();
        if (controlhelper.SaveDefaultTemplateData(sPath, DefaultDeviceTemplateControl1))
        {
            //show message accordingly
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string sPath = HttpContext.Current.Server.MapPath("App_Data\\DefaultTemplate") + "\\DeviceCommon_default.xml";
        ControlHelper controlhelper = new ControlHelper();
        if (controlhelper.SetTemplateData(sPath, DefaultDeviceTemplateControl1,"22",true))
        {
            //show message accordingly
        }
    }
}