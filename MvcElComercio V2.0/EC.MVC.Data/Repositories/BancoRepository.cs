using System;
using System.Collections.Generic;
using EC.MVC.Domain.Interfaces.Repositories;
using EC.MVC.Domain.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EC.MVC.Data.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        protected string oCadenaCNN = string.Empty;

        public BancoRepository()
        {
            oCadenaCNN = ConfigurationManager.ConnectionStrings["CNN"].ToString();
        }

        /// <summary>
        /// Crear nuevo banco
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Agregar(Banco obj)
        {
            bool oSalida = false;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_banco_agregar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                        cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            oSalida = true;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                // LOG REPOSITORY
            }
            return oSalida;
        }

        public bool Actualizar(Banco obj)
        {
            bool oSalida = false;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_banco_actualizar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                        cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            oSalida = true;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                // LOG REPOSITORY
            }
            return oSalida;
        }

        public bool Eliminar(Banco obj)
        {
            bool oSalida = false;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_eli_banco", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            oSalida = true;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                // LOG REPOSITORY
            }
            return oSalida;
        }

        /// <summary>
        /// Listar banco por ID
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Banco ListarPorId(Banco obj)
        {
            Banco oBanco = null;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_banco_listarXid", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                oBanco = new Banco
                               {
                                   Id = (int)odr["Id"],
                                   Nombre = odr["Nombre"].ToString(),
                                   Direccion = odr["Direccion"].ToString(),
                                   Fecha = Convert.ToDateTime(odr["Fecha"].ToString())
                               };
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
            return oBanco;
        }

        /// <summary>
        /// Listado de bancos
        /// </summary>
        /// <returns></returns>
        public List<Banco> ListarTodos()
        {
            List<Banco> loBancos = new List<Banco>();
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_banco_listado", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                var oBanco = new Banco
                                {
                                    Id = (int)odr["Id"],
                                    Nombre = odr["Nombre"].ToString(),
                                    Direccion = odr["Direccion"].ToString(),
                                    Fecha = Convert.ToDateTime(odr["Fecha"].ToString())
                                };
                                loBancos.Add(oBanco);
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
            return loBancos;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public string Validar(Banco obj)
        {
            string sMensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_banco_validar", con))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                sMensaje = odr["mensaje"].ToString();
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
            return sMensaje;
        }
    }
}
