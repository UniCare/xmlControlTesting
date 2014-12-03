//----------------------------------------------------------------------------------------------
//-----           _____                 _ _ _                 						                    ----------------
//-----          /  __ \               (_) (_)                						                    ----------------
//-----          | /  \/ ___  _ __  ___ _| |_ _   _ _ __ ___  						            ----------------
//-----          | |    / _ \| '_ \/ __| | | | | | | '_ ` _ \ 						                ----------------
//-----          | \__/\ (_) | | | \__ \ | | | |_| | | | | | |						                ----------------
//-----           \____/\___/|_| |_|___/_|_|_|\__,_|_| |_| |_|						        ----------------
//-----	         Copyright © 2014 Consilium Software Inc. All rights reserved.		    ----------------
//-----     												                                                    ----------------
//-----     												                                                    ----------------
//-----     Module File Name: TextBoxBuilder                                 				            ----------------
//-----     Module Name: A control builder class to build control dynamically            ----------------
//-----     Module Purpose: Build a DropDownListBuilder ui dynamically                   ----------------
//-----     created: Jun 2, 2014							                                            ----------------
//-----     Author: Amresh Kumar                											        ----------------
//----------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;

namespace Consilium.UCaaS.CUCMEntityTemplate
{
    public class TextBoxBuilder : IControlBuilder
    {
        public Control BuildControl(XmlNode node)
        {
            XmlNode nodeControlID = node.SelectSingleNode("FieldKeyName");
            TextBox tControl = new TextBox();
            tControl.ID = nodeControlID.InnerText;
            tControl.MaxLength = 0;
            tControl.Width = 200;
            BindDefaultValue(node, tControl);
            return tControl;
        }

        public void BindDefaultValue(XmlNode node,TextBox tControl)
        {
            XmlNode nodeDefaultValue = node.SelectSingleNode("Default");
            if (nodeDefaultValue != null)
            {
                tControl.Text = nodeDefaultValue.InnerText;
            }
        }//End
    }
}
