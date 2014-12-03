using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Xml;
using System.Xml.XPath;
using System.Data;
using System.Data.SqlClient;

namespace Consilium.UCaaS.CUCMEntityTemplate
{
    public class DataBinder
    {
        public static void BindControl(DropDownList ddlControl, XmlNode control)
        {
            DataTable dt = null;
            XmlNode SourceTpeNode = control.SelectSingleNode("Source/SourceInfo/SourceType");
            if (SourceTpeNode == null) return;
            if (SourceTpeNode.InnerText == string.Empty) return;


            if (SourceTpeNode.InnerText == "DB")
            {
                ControlDataHelper dbObject = new ControlDataHelper();
                ddlControl.DataTextField = control.SelectSingleNode("Source/SourceInfo/Value").InnerText;
                ddlControl.DataValueField = control.SelectSingleNode("Source/SourceInfo/Key").InnerText;
                string sp_name = GetStoredProcName(control);
                if (sp_name.Trim() == string.Empty) return;
                SqlParameter[] param = GetSQLParameter(control);
                try
                {
                    dt = dbObject.RunSPReturnDataTable(sp_name, param);
                }
                catch (Exception)
                {
                    // throw;
                }

                ddlControl.DataSource = dt;
                ddlControl.DataBind();
            }
            else if (SourceTpeNode.InnerText == "INLINE")
            {
                XmlNodeList nodeList = control.SelectNodes("Source/SourceInfo/ListItem/Item");
                Dictionary<string, string> ItemDictionary = new Dictionary<string, string>();
                foreach (XmlNode nodeItem in nodeList)
                {
                    ItemDictionary.Add(nodeItem.InnerText, nodeItem.InnerText);
                }
                ddlControl.DataTextField = "value";
                ddlControl.DataValueField = "key";
                ddlControl.DataSource = ItemDictionary;
                ddlControl.DataBind();
            }
        }

        static SqlParameter[] GetSQLParameter(XmlNode control)
        {
            XmlNodeList nodeParameters = control.SelectNodes("Source/SourceInfo/SQLParameter/ParameterName");
            DeviceTemplateObjects deviceTemplateObjects = new DeviceTemplateObjects();
            if (nodeParameters != null)
            {
                int countParameter = nodeParameters.Count;
                SqlParameter[] param = new SqlParameter[countParameter];
                for (int iParamCount = 0; iParamCount < countParameter; iParamCount++)
                {
                    string sText = nodeParameters[iParamCount].InnerText;
                    object obj = deviceTemplateObjects.GetType().GetProperty(sText).GetValue(deviceTemplateObjects, null);
                    param[iParamCount] = new SqlParameter("@" + sText, obj);
                }
                return param;
            }
            else return null;
        }

        static string GetStoredProcName(XmlNode control)
        {
            XmlNode nodeSP = control.SelectSingleNode("Source/SourceInfo/Caption");
            if (nodeSP != null)
            {
                return nodeSP.InnerText;
            }
            else return string.Empty;

        }//End
    }
}
