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
//-----     Module File Name: ControlDataHelper                     				            ----------------
//-----     Module Name: A control builder class to build control dynamically            ----------------
//-----     Module Purpose: Build a DropDownListBuilder ui dynamically                   ----------------
//-----     created: Jun 2, 2014							                                            ----------------
//-----     Author: Amresh Kumar                											        ----------------
//----------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for db
/// </summary>
namespace Consilium.UCaaS.CUCMEntityTemplate
{
    public class ControlDataHelper
    {
        public ControlDataHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetDevicePoolList(string qry)
        {
            SqlConnection con = new SqlConnection();
            string scon = ConfigurationManager.ConnectionStrings["UCaaSConnectionString"].ToString();
            con.ConnectionString = scon;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = qry;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                return dt;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                con.Close();
            }

        }

        public DataTable RunSPReturnDataTable(string sp_name, SqlParameter[] param)
        {
            SqlConnection con = new SqlConnection();
            string scon = ConfigurationManager.ConnectionStrings["UCaaSConnectionString"].ToString();
            con.ConnectionString = scon;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = sp_name;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                foreach (SqlParameter tParam in param)
                    cmd.Parameters.Add(tParam);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                else return null;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                con.Close();
            }

        }


        public bool ExecuteSPCreateTemplateData(List<SqlParameter[]> paramList, string proc)
        {
            SqlConnection con = new SqlConnection();
            string scon = ConfigurationManager.ConnectionStrings["UCaaSConnectionString"].ToString();
            con.ConnectionString = scon;
            try
            {
                con.Open();
                foreach (SqlParameter[] param in paramList)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    foreach (SqlParameter tParam in param)
                        cmd.Parameters.Add(tParam);
                    cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                con.Close();
            }
        }//end




        public DataTable GetTemplateData(string sTemplateId)
        {
            SqlConnection con = new SqlConnection();
            string scon = ConfigurationManager.ConnectionStrings["UCaaSConnectionString"].ToString();
            con.ConnectionString = scon;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Usp_GetTemplateData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                con.Close();
            }
        }//end
    }
}