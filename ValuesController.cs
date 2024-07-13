using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString);
        Customer cust = new Customer();
        // GET api/values
        public List<Customer> Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("Sp_Customer_Get",con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Customer> lstCustomer = new List<Customer>();
            if(dt.Rows.Count > 0)
            {
                for(int i =0; i <dt.Rows.Count; i++)
                {
                    Customer cust = new Customer();
                    cust.CustId = Convert.ToInt32(dt.Rows[i]["CustId"]);
                    cust.CustName = dt.Rows[i]["CustName"].ToString();
                    cust.AcctType = dt.Rows[i]["AcctType"].ToString();
                    cust.AcctNo = dt.Rows[i]["AcctNo"].ToString();
                    cust.City = dt.Rows[i]["City"].ToString();
                    lstCustomer.Add(cust);
                }
            }
            if(lstCustomer.Count > 0)
            {
                return lstCustomer;
            }
            else
            {
                return null;
            }
        }

        // GET api/values/5
        public Customer Get(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("Sp_Customer_GetByID", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@CustId", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Customer cust = new Customer();
            if (dt.Rows.Count > 0)
            {
                  cust.CustId = Convert.ToInt32(dt.Rows[0]["CustId"]);
                  cust.CustName = dt.Rows[0]["CustName"].ToString();
                  cust.AcctType = dt.Rows[0]["AcctType"].ToString();
                  cust.AcctNo = dt.Rows[0]["AcctNo"].ToString();
                  cust.City = dt.Rows[0]["City"].ToString();
            }
            if (cust != null)
            {
                return cust;
            }
            else
            {
                return null;
            }
        }

        // POST api/values
        public string Post(Customer customer)
        {
            string msg = " ";
            if(customer != null)
            {
                SqlCommand cmd = new SqlCommand("Sp_Customer_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustId", customer.CustId);
                cmd.Parameters.AddWithValue("@CustName", customer.CustName);
                cmd.Parameters.AddWithValue("@AcctType",customer.AcctType);
                cmd.Parameters.AddWithValue("@AcctNo",customer.AcctNo);
                cmd.Parameters.AddWithValue("@City",customer.City);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if(i>0)
                {
                    msg= "Data has been inserted";
                }
                else
                {
                    msg= "Error";
                }
            }
            return msg;
        }

        // PUT api/values/5
        public string Put(int id, Customer customer)
        {
            string msg = " ";
            if (customer != null)
            {
                SqlCommand cmd = new SqlCommand("Sp_Customer_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustId", id);
                cmd.Parameters.AddWithValue("@CustName", customer.CustName);
                cmd.Parameters.AddWithValue("@AcctType", customer.AcctType);
                cmd.Parameters.AddWithValue("@AcctNo", customer.AcctNo);
                cmd.Parameters.AddWithValue("@City", customer.City);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    msg = "Data has been updated";
                }
                else
                {
                    msg = "Error";
                }
            }
            return msg;
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            string msg = " ";

            SqlCommand cmd = new SqlCommand("Sp_Customer_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustId", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                msg = "Data has been deleted";
            }
            else
            {
                msg = "Error";
            }
            return msg;
        }
    }
}
