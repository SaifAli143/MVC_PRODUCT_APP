using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_PRODUCT_APP.Models
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Product> GetAllProduct()
        {

            List<Product> list = new List<Product>();
            string str = "select * from PRODUCT_TABLE";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Product_Id = Convert.ToInt32(dr["Product_Id"]);
                    p.Product_Name = dr["Product_Name"].ToString();
                    p.Product_Price = Convert.ToDecimal(dr["Product_Price"]);
                    p.Company_Name = dr["Company_name"].ToString();
                    p.Product_Description = dr["Product_Description"].ToString();
                    list.Add(p);
                }
                con.Close();
                return list;
            }
            else
            {
                con.Close();
                return list;
            }

        }

        public Product GetProductById(int id)
        {
            Product p = new Product();
            string str = "select * from PRODUCT_TABLE where Product_Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    p.Product_Id = Convert.ToInt32(dr["Product_Id"]);
                    p.Product_Name = dr["Product_Name"].ToString();
                    p.Product_Price = Convert.ToDecimal(dr["Product_Price"]);
                    p.Company_Name = dr["Company_name"].ToString();
                    p.Product_Description = dr["Product_Description"].ToString();
                    
                }
                con.Close();
                return p;
            }
            else
            {
                con.Close();
                return p;
            }

        }
        public int Save(Product Prod)
        {

            string str = "insert into PRODUCT_TABLE values(@name,@price,@company,@description)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", Prod.Product_Name);
            cmd.Parameters.AddWithValue("@price", Prod.Product_Price);
            cmd.Parameters.AddWithValue("@company", Prod.Company_Name);
            cmd.Parameters.AddWithValue("@description", Prod.Product_Description);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;


        }
        public int Update(Product Prod)
        {
            string str = "update PRODUCT_TABLE set Product_Name=@name,Product_Price=@price,Company_Name=@company,Product_Description=@description where Product_Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", Prod.Product_Id);
            cmd.Parameters.AddWithValue("@name", Prod.Product_Name);
            cmd.Parameters.AddWithValue("@price", Prod.Product_Price);
            cmd.Parameters.AddWithValue("@company", Prod.Company_Name);
            cmd.Parameters.AddWithValue("@description", Prod.Product_Description);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Delete(int id)
        {
            string str = "delete from PRODUCT_TABLE where Product_Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

    }
}
