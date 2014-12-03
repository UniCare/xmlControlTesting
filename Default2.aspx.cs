using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Consilium.UCaaS.CUCMEntityTemplate;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BL_PullCUCMData obj = new BL_PullCUCMData();
        obj.GetRegion();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {//save
        //HttpContext.Current.Server.MapPath("App_Data\\DefaultTemplate") + "\\6921_default.xml";
        //ControlHelper controlhelper = new ControlHelper();
        //if (controlhelper.SaveTemplateData(sPath, DeviceTemplateControl1))
        //{
        //    //show message accordingly
        //}
    }
    protected void Button2_Click(object sender, EventArgs e)
    {//Restore

    }
}