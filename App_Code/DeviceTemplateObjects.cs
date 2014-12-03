using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;


/// <summary>
/// Summary description for DeviceTemplateObjects
/// </summary>
namespace Consilium.UCaaS.CUCMEntityTemplate
{
    public class DeviceTemplateObjects
    {
        int _ApplicationProfileID;
        object _liServerList; // List<VO_ApplicationServer> _liServerList;

        public DeviceTemplateObjects()
        {
        }

        public int CustomerId
        {
            get
            {
                string custid = HttpContext.Current.Session["Consilium.UCaaS.Web.login.LoggedInCustomerId"] == null ? "-1" : HttpContext.Current.Session["Consilium.UCaaS.Web.login.LoggedInCustomerId"].ToString();
                int iCustId=0;
                int.TryParse(custid, out iCustId);
                return iCustId;  //return Int32.Parse(HttpContext.Current.Session["Consilium.UCaaS.Web.login.LoggedInCustomerId"].ToString());
            }
        }

        public int ApplicationProfileID
        {
            set
            {
                _ApplicationProfileID = value;
            }
            get
            {
                return _ApplicationProfileID; //46;
            }
        }

        // public List<VO_ApplicationServer> ServerDetails
        public List<object> ServerDetails
        {
            set
            {
            }
            get
            {
                //_liServerList = appProfile.ApplicationProfileListByID(iClientId, iApplicationProfileId);
                //foreach (var appserver in _liServerList)
                //{
                //    if (appserver.ServerType == "CUCM")
                //    {
                //        return _cucmServerDetails = appserver;
                //    }
                //}
                return null;
            }
        }//end


    }
}