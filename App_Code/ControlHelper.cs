using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ControlHelper
/// </summary>
namespace Consilium.UCaaS.CUCMEntityTemplate
{
    public class ControlHelper
    {
        public ControlHelper()
        {
        }

        public static string GetControlValue(XmlNode node, UserControl control, string sControlId)
        {
            Control ctrl = (control.FindControl(sControlId));
            return GetValue(ctrl);
        }


        public static bool SetControlValue(UserControl control, string sControlId, string OldValue)
        {
            Control ctrl = (control.FindControl(sControlId));
            return SetValue(ctrl, OldValue);
        }

        /// <summary>
        /// Set Value
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool SetValue(Control control, string value)
        {
            if (control.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
            {
                DropDownList ddl = ((DropDownList)control);
                if (ddl.Items.Count > 0)
                {
                    ddl.SelectedIndex = -1;
                    foreach (ListItem li in ddl.Items)
                    {
                        if (li.Text == value)
                        {
                            li.Selected = true;
                            break;
                        }
                    }
                    return true;
                }
            }
            if (control.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
            {
                TextBox tb = control as TextBox;
                tb.Text = value;
                return true;
            }
            if (control.GetType().ToString() == "System.Web.UI.WebControls.CheckBox")
            {
                CheckBox tb = control as CheckBox;
                bool bChecked = false;
                bool isChecked = bool.TryParse(value, out bChecked);
                tb.Checked = bChecked;
                return true;
            }
            if (control.GetType().ToString() == "System.Web.UI.WebControls.RadioButtonList")
            {
                RadioButtonList rbl = control as RadioButtonList;
                Boolean bValue=false;
                Boolean.TryParse(value, out bValue);
                if (bValue == true) rbl.Items[0].Selected = true;
                else rbl.Items[1].Selected = true;
                return true;
            }
            return false;
        }

        public static string GetValue(Control control)
        {
            if (control.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
            {
                DropDownList ddl = ((DropDownList)control);
                if (ddl.Items.Count > 0)
                    return ddl.SelectedItem.Value;
                return string.Empty;
            }
            if (control.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
            {
                TextBox tb = control as TextBox;
                return tb.Text;
            }
            if (control.GetType().ToString() == "System.Web.UI.WebControls.CheckBox")
            {
                CheckBox tb = control as CheckBox;
                return tb.Checked.ToString();
            }

            if (control.GetType().ToString() == "System.Web.UI.WebControls.RadioButtonList")
            {
                RadioButtonList rbl = control as RadioButtonList;
                return (rbl.SelectedIndex==0?1:0).ToString();
            }
            else return string.Empty;
        }


        public bool SaveTemplateData(string sPath, UserControl uc)
        {
            IUIBuilder helper = new XMLHelper();
            XmlDocument doc = helper.GetTemplateXML(sPath);
            XmlNodeList xnl = doc.SelectNodes("/DeviceFieldInformation/Panel/Field");
            List<SqlParameter[]> param = new List<SqlParameter[]>();
            if (xnl != null)
            {

                foreach (XmlNode node in xnl)
                {
                    SqlParameter[] sqlParamList = new SqlParameter[4];
                    string TagCaption = node.SelectSingleNode("Title").InnerText;
                    sqlParamList[0] = new SqlParameter("@CaptionName", TagCaption);
                    string sid = node.SelectSingleNode("FieldKeyName").InnerText;
                    sqlParamList[1] = new SqlParameter("@ControlName", sid);
                    string sControlType = node.SelectSingleNode("ControlType").InnerText;
                    string str = ControlHelper.GetControlValue(node, uc, sid);
                    sqlParamList[2] = new SqlParameter("@ControlValue", str);
                    sqlParamList[3] = new SqlParameter("@TemplateMasterId", 65);
                    param.Add(sqlParamList);
                }

                ControlDataHelper obj = new ControlDataHelper();
                obj.ExecuteSPCreateTemplateData(param, "Usp_InsertTemplateData");
                return true;
            }
            return false;
        }//End



        public bool SaveDefaultTemplateData(string sPath, UserControl uc)
        {
            IUIBuilder helper = new XMLHelper();
            XmlDocument doc = helper.GetTemplateXML(sPath);
            XmlNodeList xnl = doc.SelectNodes("/DeviceFieldInformation/Panel/Field");
            List<SqlParameter[]> param = new List<SqlParameter[]>();
            if (xnl != null)
            {

                foreach (XmlNode node in xnl)
                {
                    SqlParameter[] sqlParamList = new SqlParameter[6];
                    string TagCaption = node.SelectSingleNode("Title").InnerText;
                    sqlParamList[0] = new SqlParameter("@CaptionName", TagCaption);
                    string sid = node.SelectSingleNode("FieldKeyName").InnerText;

                    sqlParamList[1] = new SqlParameter("@ControlName", sid);

                    string sControlType = node.SelectSingleNode("ControlType").InnerText;
                    string str = ControlHelper.GetControlValue(node, uc, sid);
                    sqlParamList[2] = new SqlParameter("@ControlValue", str);

                    sqlParamList[3] = new SqlParameter("@TemplateMasterId", "22");

                    string setonCreationId = node.SelectSingleNode("SetOnCreationID").InnerText;
                    sqlParamList[5] = new SqlParameter("@SetOnCreationControlId", setonCreationId);

                    string SetOnCreationValue = ControlHelper.GetControlValue(node, uc, setonCreationId);
                    sqlParamList[4] = new SqlParameter("@SetOnCreation", SetOnCreationValue);

                    param.Add(sqlParamList);
                }

                ControlDataHelper obj = new ControlDataHelper();
                obj.ExecuteSPCreateTemplateData(param, "Usp_InsertDefaultDeviceTemplateData");
                return true;
            }
            return false;
        }//End

        //end
        public bool SetTemplateData(string sPath, UserControl uc,string TemplateID,  bool IsDefaultTemplate)
        {
            IUIBuilder helper = new XMLHelper();
            XmlDocument doc = helper.GetTemplateXML(sPath);
            XmlNodeList xnl = doc.SelectNodes("/DeviceFieldInformation/Panel/Field");
            ControlDataHelper obj = new ControlDataHelper();
            DataTable dt = obj.GetTemplateData(TemplateID);
            if (xnl != null)
            {
                foreach (XmlNode node in xnl)
                {
                    string sid = node.SelectSingleNode("FieldKeyName").InnerText;
                    var reslt = from tbl in dt.AsEnumerable()
                                where tbl.Field<string>("ControlName").Equals(sid, StringComparison.InvariantCultureIgnoreCase)
                                select tbl.Field<string>("ControlValue");

                    if (reslt.Count() > 0)
                    {
                        string value = reslt.Single();
                        bool sResponse = ControlHelper.SetControlValue( uc, sid, value);
                    }

                    if (IsDefaultTemplate)
                    {
                        string rbSetonCreationId = node.SelectSingleNode("SetOnCreationID").InnerText;
                        var resltSetOnCreationn = from tbl in dt.AsEnumerable()
                                                  where tbl.Field<string>("SetOnCreationControlId").Equals(rbSetonCreationId, StringComparison.InvariantCultureIgnoreCase)
                                    select tbl.Field<Boolean>("SetOnCreation");

                        if (resltSetOnCreationn.Count() > 0)
                        {
                            Boolean value = resltSetOnCreationn.Single();
                            bool sResponse = ControlHelper.SetControlValue(uc, rbSetonCreationId, value.ToString());
                        }
                    }
                }
                return true;
            }
            return false;
        }//End of func
    }
}