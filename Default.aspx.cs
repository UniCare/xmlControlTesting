using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.SqlClient;
using Consilium.UCaaS.CUCMEntityTemplate;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Remove the session details
        Session["Consilium.UCaaS.Web.login.LoggedInCustomerId"] = "9490";
    }//End

    protected void Button1_Click(object sender, EventArgs e)
    {
        string DeviceID = "DeviceCommon";
        string sPath = HttpContext.Current.Server.MapPath("App_Data") + "\\" + DeviceID + ".xml";
        ControlHelper controlhelper = new ControlHelper();

        if (controlhelper.SaveTemplateData(sPath, DeviceTemplateControl1))
        {
            //show message accordingly
        }
    }

    protected void btnRestore_Click(object sender, EventArgs e)
    {
        string DeviceTemplateID = "22";
        string DeviceID = "DeviceCommon";
        string sPath = HttpContext.Current.Server.MapPath("App_Data") + "\\" + DeviceID + ".xml";
        ControlHelper controlhelper = new ControlHelper();
        if (controlhelper.SetTemplateData(sPath, DeviceTemplateControl1, DeviceTemplateID, false))
        {
            //show message accordingly
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}