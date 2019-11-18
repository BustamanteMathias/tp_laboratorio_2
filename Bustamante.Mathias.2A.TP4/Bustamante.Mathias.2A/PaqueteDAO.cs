using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Bustamante.Mathias._2A
{
    static class PaqueteDAO
    {
        #region ATRIBUTOS
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region CONSTRUCTOR
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.CadenaDeConexion);
            PaqueteDAO.comando = new SqlCommand();
        }
        #endregion

        #region METODO
        public static bool Insertar(Paquete p)
        {
            bool rtn = false;
            string sqlQuery = "INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "', '" + p.TrackingID + "','Bustamante Mathias')";

            try
            {
                PaqueteDAO.comando.CommandType = CommandType.Text;
                PaqueteDAO.comando.CommandText = sqlQuery;
                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;

                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();

                rtn = true;
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                PaqueteDAO.conexion.Close();
            }

            return rtn;
        }
        #endregion
    }
}
