using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Domain.Interfaces.Repositories;
using EC.MVC.Domain.Entities;

namespace EC.MVC.Data.Repositories
{
    public class MonedaRepository : IMonedaRepository
    {

        protected string oCadenaCNN = string.Empty;

        public MonedaRepository()
        {
            oCadenaCNN = ConfigurationManager.ConnectionStrings["CNN"].ToString();
        }

        public List<Moneda> ListarTodos()
        {
            List<Moneda> loMoneda = new List<Moneda>();
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_moneda_listar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                var oMoneda = new Moneda
                                {
                                    Id = (int)odr["Id"],
                                    Nombre = odr["Nombre"].ToString()
                                };
                                loMoneda.Add(oMoneda);
                            }
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                // LOG REPOSITORY
            }
            return loMoneda;
        }
    }
}
