using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EC.MVC.Domain.Entities;
using EC.MVC.Domain.Interfaces.Repositories;

namespace EC.MVC.Data.Repositories
{
    public class SucursalRepository: ISucursalRepository
    {
        protected string oCadenaCNN = string.Empty;

        public SucursalRepository()
        {
            oCadenaCNN = ConfigurationManager.ConnectionStrings["CNN"].ToString();
        }

        public bool Agregar(Sucursal obj)
        {
            bool oSalida = false;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_sucursal_agregar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                        cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                        cmd.Parameters.AddWithValue("@IdBanco", obj.Banco.Id);
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

        public bool Actualizar(Sucursal obj)
        {
            bool oSalida = false;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_sucursal_actualizar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                        cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                        cmd.Parameters.AddWithValue("@IdBanco", obj.Banco.Id);
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

        public string Validar(Sucursal obj)
        {
            string sMensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_sucursal_validar", con))
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

        public bool Eliminar(Sucursal obj)
        {
            bool oSalida = false;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_sucursal_eliminar", con))
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

        public Sucursal ListarPorId(Sucursal obj)
        {
            Sucursal oSucursal = null;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_sucursal_listarXid", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                oSucursal = new Sucursal
                                {
                                    Id = (int)odr["Id"],
                                    Nombre = odr["Nombre"].ToString(),
                                    Direccion = odr["Direccion"].ToString(),
                                    Fecha = Convert.ToDateTime(odr["Fecha"].ToString()),
                                    Banco = new Banco() { Id = (int)odr["IdBanco"], Nombre = odr["Banco"].ToString() } 
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
            return oSucursal;
        }

        public List<Sucursal> ListarTodos()
        {
            List<Sucursal> loSucursal = new List<Sucursal>();
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_sucursal_listado", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                var oSucursal = new Sucursal
                                {
                                    Id = (int)odr["Id"],
                                    Nombre = odr["Nombre"].ToString(),
                                    Direccion = odr["Direccion"].ToString(),
                                    Fecha = Convert.ToDateTime(odr["Fecha"].ToString()),
                                    Banco = new Banco() { Id = (int)odr["IdBanco"], Nombre = odr["Banco"].ToString() } 
                                };
                                loSucursal.Add(oSucursal);
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
            return loSucursal;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public List<Sucursal> ListarxBanco(Banco obj)
        {
            List<Sucursal> loSucursal = new List<Sucursal>();
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_sucursal_listadoxBanco", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                var oSucursal = new Sucursal
                                {
                                    Id = (int)odr["Id"],
                                    Nombre = odr["Nombre"].ToString(),
                                    Direccion = odr["Direccion"].ToString(),
                                    Fecha = Convert.ToDateTime(odr["Fecha"].ToString()),
                                    Banco = new Banco() { Id = (int)odr["IdBanco"], Nombre = odr["Banco"].ToString() }
                                };
                                loSucursal.Add(oSucursal);
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
            return loSucursal;
        }
    }
}
