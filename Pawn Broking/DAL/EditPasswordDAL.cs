using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pawn_Broking.DAL
{
    internal class EditPasswordDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Validate Password from Database
        public bool ValidatePassword(int EPId, string EPassword)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            bool isValid = false;

            try
            {
                string sql = "SELECT * FROM EditPassword WHERE EPId = @EPId AND EPassword = @EPassword";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@EPId", EPId);
                cmd.Parameters.AddWithValue("@EPassword", EPassword);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    isValid = true;  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               
                conn.Close();
            }

            return isValid;
        }
        #endregion
    }
}
