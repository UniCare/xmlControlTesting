using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using Consilium.UCaaS.CUCMEntityTemplate;


public partial class DeviceTemplateControl : System.Web.UI.UserControl
{
    string _deviceid;
    public string DeviceID
    {
        get
        {
            return _deviceid;
        }
        set
        {
            _deviceid = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          
        }
    }

    /// <summary>
    /// Prepare the screen
    /// </summary>
    /// <param name="e"></param>
    protected override void OnInit(EventArgs e)
    {
        if (_deviceid != null)
        {
            string sPath = HttpContext.Current.Server.MapPath("App_Data") + "\\DeviceCommon.xml";
            IUIBuilder helper = new XMLHelper();
            pnlContainer.Controls.Clear();
            HtmlTable ht = helper.BuildUI(sPath, false);
            pnlContainer.Controls.Add(ht);
        }
        base.OnInit(e);
    }
}