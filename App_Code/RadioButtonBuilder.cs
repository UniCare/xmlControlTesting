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
//-----     Module File Name: RadioButtonBuilder                     				            ----------------
//-----     Module Name: A control builder class to build control dynamically            ----------------
//-----     Module Purpose: Build a RadioButton ui dynamically                                ----------------
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
    public class RadioButtonBuilder : IControlBuilder
    {
        public Control BuildControl(XmlNode node)
        {
            XmlNode nodeControlID = node.SelectSingleNode("FieldKeyName");
            RadioButton cbControl = new RadioButton();
            cbControl.ID = nodeControlID.InnerText;
            return cbControl;
        }
    }
}
