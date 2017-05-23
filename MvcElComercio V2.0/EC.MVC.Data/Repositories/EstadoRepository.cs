using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EC.MVC.Domain.Entities;
using EC.MVC.Domain.Interfaces.Repositories;

namespace EC.MVC.Data.Repositories
{

    public class EstadoRepository : IEstadoRepository
    {

        protected string oCadenaCNN = string.Empty;

        public EstadoRepository()
        {
            oCadenaCNN = ConfigurationManager.ConnectionStrings["CNN"].ToString();
        }

        public List<Estado> ListarTodos()
        {
            List<Estado> loEstado = new List<Estado>();
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_estado_listar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                var oEstado = new Estado
                                {
                                    Id = (int)odr["Id"],
                                    Nombre = odr["Nombre"].ToString()
                                };
                                loEstado.Add(oEstado);
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
            return loEstado;
        }
    }
}
