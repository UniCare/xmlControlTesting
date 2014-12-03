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
//-----     Module File Name: BL_PullCUCMData                     				            ----------------
//-----     Module Name: Business Logic Manage AD sync                                    ----------------
//-----     Module Purpose: Business Logic for Manage AD sync  over CUCM            ----------------
//-----     created: Jun 2, 2014							                                        ----------------
//-----     Author: Amresh Kumar                											        ----------------
//----------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
//using Consilium.UCaaS.VO;

/// <summary>
/// Summary description for BL_PullCUCMData
/// </summary>
namespace Consilium.UCaaS.CUCMEntityTemplate
{
    public class BL_PullCUCMData
    {
        public BL_PullCUCMData()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ///// <summary>
        ///// Returns AD sync status of CUCM server refered from application profile
        ///// </summary>
        ///// <param name="CustomerId"></param>
        ///// <param name="ApplicationProfileID"></param>
        ///// <returns></returns>
        //public bool IsADSyncEnabled(VO_ApplicationServer _cucmServerDetails, int CustomerId, int ApplicationProfileID)
        public string GetCommonApplicationProfile(int CustomerId, int ApplicationProfileID)
        {
            try
            {
                string url = "https://" + "192.168.1.92:8443" + "/axl/";
                string host = "192.168.1.92:8443";
                byte[] credBuf = new System.Text.UTF8Encoding().GetBytes("administrator" + ":" + "koushal@123");
                string authorization = "Basic " + Convert.ToBase64String(credBuf);
                string soap = "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" ";
                soap += "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">";
                soap += "<SOAP-ENV:Body>";
                soap += "<axl:getLdapSystem xmlns:axl=\"http://www.cisco.com/AXL/API/10.0\">";
                soap += "</axl:getLdapSystem>";
                soap += "</SOAP-ENV:Body>";
                soap += "</SOAP-ENV:Envelope>";
                Console.Write("getting version");
                string version = SoapVersion(soap);
                Console.Write(version);
                try
                {
                    byte[] soapBytes = Encoding.UTF8.GetBytes(soap);
                    ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.Host = host;
                    req.Accept = "text/*";
                    req.ContentType = "text/xml";
                    req.Headers.Add("SOAPAction: 'CUCM:DB ver=" + version + "'");
                    req.ContentLength = soapBytes.Length;
                    req.Headers.Add("Authorization: " + authorization);
                    req.Method = "POST";
                    Stream stm = req.GetRequestStream();
                    stm.Write(soapBytes, 0, soapBytes.Length);
                    Console.Write("getting response");
                    using (WebResponse response = req.GetResponse())
                    {
                        Stream responseStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(responseStream);
                        string responseFromServer = reader.ReadToEnd();
                        return responseFromServer;
                    }


                }
                catch (WebException e)
                {
                    Console.Write(e.Message);
                    return e.Message;

                }
            }
            catch (Exception exc)
            {
                Console.Write(exc.Message);
                return exc.Message;
            }
        }//end of function

        public string GetVersion()
        {
            try
            {
                string url = "https://" + "192.168.1.92:8443" + "/axl/";
                string host = "192.168.1.92:8443";
                byte[] credBuf = new System.Text.UTF8Encoding().GetBytes("administrator" + ":" + "koushal@123");
                string authorization = "Basic " + Convert.ToBase64String(credBuf);
                string soap = "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" ";
                soap += "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">";
                soap += "<SOAP-ENV:Body>";
                soap += "<axl:getCCMVersion xmlns:axl=\"http://www.cisco.com/AXL/API/1.0\">";
                soap += "</axl:getCCMVersion>";
                soap += "</SOAP-ENV:Body>";
                soap += "</SOAP-ENV:Envelope>";
                Console.Write("getting version");
                string version = SoapVersion(soap);
                Console.Write(version);
                try
                {
                    byte[] soapBytes = Encoding.UTF8.GetBytes(soap);
                    ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.Host = host;
                    req.Accept = "text/*";
                    req.ContentType = "text/xml";
                    req.Headers.Add("SOAPAction: 'CUCM:DB ver=" + version + "'");
                    req.ContentLength = soapBytes.Length;
                    req.Headers.Add("Authorization: " + authorization);
                    req.Method = "POST";
                    Stream stm = req.GetRequestStream();
                    stm.Write(soapBytes, 0, soapBytes.Length);
                    Console.Write("getting response");
                    using (WebResponse response = req.GetResponse())
                    {
                        Stream responseStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(responseStream);
                        string responseFromServer = reader.ReadToEnd();
                        return responseFromServer;
                    }


                }
                catch (WebException e)
                {
                    Console.Write(e.Message);
                    return e.Message;

                }
            }
            catch (Exception exc)
            {
                Console.Write(exc.Message);
                return exc.Message;
            }
        }//end of function

        public string GetRegion()
        {
            try
            {
                string url = "https://" + "192.168.1.92:8443" + "/axl/";
                string host = "192.168.1.92:8443";
                byte[] credBuf = new System.Text.UTF8Encoding().GetBytes("administrator" + ":" + "koushal@123");
                string authorization = "Basic " + Convert.ToBase64String(credBuf);
                string soap = "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" ";
                soap += "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">";
                soap += "<SOAP-ENV:Body>";
                soap += "<axl:getRegion  xmlns:axl=\"http://www.cisco.com/AXL/API/10.0\">";
                soap += "</axl:getRegion>";
                soap += "</SOAP-ENV:Body>";
                soap += "</SOAP-ENV:Envelope>";
                Console.Write("getting version");
                string version = SoapVersion(soap);
                Console.Write(version);
                try
                {
                    byte[] soapBytes = Encoding.UTF8.GetBytes(soap);
                    ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.Host = host;
                    req.Accept = "text/*";
                    req.ContentType = "text/xml";
                    req.Headers.Add("SOAPAction: 'CUCM:DB ver=" + version + "'");
                    req.ContentLength = soapBytes.Length;
                    req.Headers.Add("Authorization: " + authorization);
                    req.Method = "POST";
                    Stream stm = req.GetRequestStream();
                    stm.Write(soapBytes, 0, soapBytes.Length);
                    Console.Write("getting response");
                    using (WebResponse response = req.GetResponse())
                    {
                        Stream responseStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(responseStream);
                        string responseFromServer = reader.ReadToEnd();
                        return responseFromServer;
                    }


                }
                catch (WebException e)
                {
                    Console.Write(e.Message);
                    return e.Message;

                }
            }
            catch (Exception exc)
            {
                Console.Write(exc.Message);
                return exc.Message;
            }
        }//end of function

        public static string SoapVersion(string str)
        {
            XmlDocument oXML = new XmlDocument();
            oXML.LoadXml(str);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(oXML.NameTable);
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");

            XElement el = XElement.Parse(oXML.DocumentElement.SelectSingleNode("soap:Body", nsmgr).ChildNodes[0].OuterXml);
            XNamespace xns1 = el.GetNamespaceOfPrefix("axl");
            string[] mm = xns1.ToString().Split('/');
            return mm[mm.Length - 1].ToString();
        }//end of Soap Version

    }
}