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
//-----     Module File Name: IControlBuilder                     				                    ----------------
//-----     Module Name: An interface to define base class for all controls              ----------------
//-----     Module Purpose: Build a check box ui dynamically                                ----------------
//-----     created: Jun 2, 2014							                                            ----------------
//-----     Author: Amresh Kumar                											        ----------------
//----------------------------------------------------------------------------------------------

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
    public interface IControlBuilder
    {
        Control BuildControl(XmlNode node);
    }
}