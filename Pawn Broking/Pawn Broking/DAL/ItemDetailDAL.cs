using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pawn_Broking.BLL;

namespace Pawn_Broking.DAL
{
    internal class ItemDetailDAL
    {
        private SqlConnection dbcon = new SqlConnection("Data Source=DESKTOP-6JKB17U\\SQL;Initial Catalog=PawnBrokingNew;User ID=sa;Password=1234;");

        public bool Insert(ItemDetailBLL item)
        {
            string query = "INSERT INTO ItemDetail (ItemType, ItemName) VALUES (@ItemType, @ItemName)";
            using (SqlCommand cmd = new SqlCommand(query, dbcon))
            {
                cmd.Parameters.AddWithValue("@ItemType", item.ItemType);
                cmd.Parameters.AddWithValue("@ItemName", item.ItemName);

                dbcon.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                dbcon.Close();

                return rowsAffected > 0;
            }
        }

        public bool Update(ItemDetailBLL item)
        {
            string query = "UPDATE ItemDetail SET ItemType=@ItemType, ItemName=@ItemName WHERE ItemCode=@ItemCode";
            using (SqlCommand cmd = new SqlCommand(query, dbcon))
            {
                cmd.Parameters.AddWithValue("@ItemType", item.ItemType);
                cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                cmd.Parameters.AddWithValue("@ItemCode", item.ItemCode);

                dbcon.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                dbcon.Close();

                return rowsAffected > 0;
            }
        }

        // Method to Fetch ItemDetail by ItemCode
        public DataTable GetItemDetailByCode(int itemCode)
        {
            string query = "SELECT * FROM ItemDetail WHERE ItemCode=@ItemCode";
            using (SqlCommand cmd = new SqlCommand(query, dbcon))
            {
                cmd.Parameters.AddWithValue("@ItemCode", itemCode);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
