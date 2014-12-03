using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;


/// <summary>
/// XMLHelper
/// </summary>
namespace Consilium.UCaaS.CUCMEntityTemplate
{
 
    public class XMLHelper : IUIBuilder
    {
        public XMLHelper()
        {
        }

        public XmlDocument GetTemplateXML(string xmlPath)
        {
            if (!File.Exists(xmlPath)) return new XmlDocument();
            string xml = File.ReadAllText(xmlPath);
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(xml);
                return xmlDocument;
            }
            catch (Exception exp)
            {
                return null;
            }
        }//End

        public HtmlTable BuildUI(string sPath, bool IsDefaultTemplate)
        {
            XmlDocument doc = GetTemplateXML(sPath);
            if (doc == null) return null;
            XmlNodeList controls = GetControlList(doc);
            HtmlTable containerHT = new HtmlTable();
            containerHT.Border = 1;
            //containerHT.Style.Add("Font-Family", "Verdana");
            //containerHT.Style.Add("Font-Size", "12px");
            HtmlTableRow htr1 = new HtmlTableRow();
            HtmlTableCell htc1 = new HtmlTableCell();
            htc1.ColSpan = 1;
            htr1.Cells.Add(htc1);
            htr1.Attributes["class"] = "GridHeader";
            htc1.InnerText = "Device Template ";
            containerHT.Rows.Add(htr1);
            
            foreach (XmlNode xmlnode in controls)
            {
                //Build panel caption
                HtmlTableRow rowCaption = GetPanelCaption(xmlnode);
                containerHT.Rows.Add(rowCaption);
               
                //Get all fields data from current panel
                XmlNodeList FieldNodes = xmlnode.SelectNodes("Field");
                HtmlTableRow htr = new HtmlTableRow();
                HtmlTableCell htc = new HtmlTableCell();
                HtmlTable htSection = BuildPanel(FieldNodes, IsDefaultTemplate);
                htc.Controls.Add(htSection);
                htr.Cells.Add(htc);
                containerHT.Rows.Add(htr);
            }
            return containerHT;
        }//End


        protected HtmlTableRow GetPanelCaption(XmlNode xmlnode)
        {
            string sTableCaption = xmlnode.Attributes["Caption"].InnerText;
            HtmlTableCell cellCaption = new HtmlTableCell();
            cellCaption.InnerText = sTableCaption;
            cellCaption.Style.Add("Font-Weight", "Bold");
            HtmlTableRow rowCaption = new HtmlTableRow();
            rowCaption.Cells.Add(cellCaption);
            return rowCaption;
        }


        protected HtmlTable BuildPanel(XmlNodeList controls, bool IsDefaultTemplate)
        {
            HtmlTable ht = new HtmlTable();
            ht.Border = 0;
            ht.CellPadding = 0;
            ht.CellSpacing = 10;
            int seq = 0;
            ht.Width = "100%";
            HtmlTableRow tr = new HtmlTableRow();
            foreach (XmlNode control in controls)
            {
                //if (IsDefaultTemplate == false)
                //{
                //    if (seq % 2 == 0) //complete html table row with two cells
                //    {
                //        tr = new HtmlTableRow();
                //    }
                //}
                //else 
                
                tr = new HtmlTableRow();            
                XmlNode nodeType = control.SelectSingleNode("ControlType");
                HtmlTableCell htcCaption = new HtmlTableCell();
                htcCaption.InnerText = control.SelectSingleNode("Title").InnerText;
                IControlBuilder cb = null;
                if (nodeType.InnerText == "TextBox")
                {
                    cb = new TextBoxBuilder();
                }
                else if (nodeType.InnerText == "CheckBox")
                {
                    cb = new CheckBoxBuilder();
                }
                else if (nodeType.InnerText == "DropDownList")
                {
                    cb = new DropDownListBuilder();
                }
                else continue;

                Control ctrl = cb.BuildControl(control);
                HtmlTableCell htc = new HtmlTableCell();
                htc.Controls.Add(ctrl);
                tr.Cells.Add(htcCaption);
                tr.Cells.Add(htc);
                if (IsDefaultTemplate == true)
                {
                    HtmlTableCell htcSA = new HtmlTableCell();
                    XmlNode  defaultCreationID =control.SelectSingleNode("SetOnCreationID");
                    RadioButtonList rbList = new RadioButtonList();
                    rbList.ID=defaultCreationID.InnerText;
                    rbList.Items.Add(new ListItem("Set on Create"));
                    rbList.Items.Add(new ListItem("Set Always"));
                    rbList.RepeatDirection = RepeatDirection.Horizontal;
                    rbList.SelectedIndex = 0;
                    htcSA.Controls.Add(rbList);
                    htcSA.Width = "25%";
                    tr.Cells.Add(htcSA);
                }

            
                ht.Rows.Add(tr);
                seq++;
            }
            return ht;
        }


        protected XmlNodeList GetControlList(XmlDocument doc)
        {
            return doc.GetElementsByTagName("Panel");
        }
    }
}
