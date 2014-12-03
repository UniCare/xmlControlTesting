using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;
using System.IO;

public partial class DeviceMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindControlDetails();
        }
    }

    protected void BindControlDetails()
    {
        string sTemplatePath= Server.MapPath("App_Data\\CommonTemplate.xml");
        string sXMLContent=File.ReadAllText(sTemplatePath);
        XmlDocument doc=new XmlDocument();

        doc.LoadXml(sXMLContent);
        XmlNodeList nl = doc.SelectNodes("DeviceFieldInformation");
        TextReader reader = File.OpenText(sTemplatePath);
        try
        {
            XmlDataSource xmlDS = new XmlDataSource();
            xmlDS.XPath = "/DeviceFieldInformation/Panel/Field";
            xmlDS.DataFile = sTemplatePath;
            gvTemp.DataSource = xmlDS;
            gvTemp.DataBind();
        }
        catch
        {
        }
        finally
        {
            reader.Close();
        }

    }
    protected void gvTemp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label myHyperLink = e.Row.FindControl("lblParameterName") as Label;
        //}
        if (gvTemp.EditIndex >= 0)
        {
            if (gvTemp.EditIndex == e.Row.RowIndex)
            {
                Label lbl = ((Label)e.Row.FindControl("hDataSource"));
                if (lbl != null)
                {
                    string sDataSourceType = ((Label)e.Row.FindControl("lblDataSource")).Text;
                }
                
            }
        }

    }
    protected void gvTemp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTemp.EditIndex = e.NewEditIndex;
        BindControlDetails();
    }
    protected void gvTemp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTemp.EditIndex = -1;
        BindControlDetails();
    }
    protected void gvTemp_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        gvTemp.EditIndex = -1;
        BindControlDetails();
    }
}