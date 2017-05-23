using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EC.MVC.Domain.Entities;
using EC.MVC.Domain.Interfaces.Repositories;

namespace EC.MVC.Data.Repositories
{
    public class OrdenPagoRepository : IOrdenPagoRepository
    {
        protected string oCadenaCNN = string.Empty;

        public OrdenPagoRepository()
        {
            oCadenaCNN = ConfigurationManager.ConnectionStrings["CNN"].ToString();
        }

        public bool Agregar(OrdenPago obj)
        {
            bool oSalida = false;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_ordenpago_agregar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@IdSucursal", obj.Sucursal.Id);
                        cmd.Parameters.AddWithValue("@IdMoneda", obj.Moneda.Id);
                        cmd.Parameters.AddWithValue("@IdEstado", obj.Estado.Id);
                        cmd.Parameters.AddWithValue("@Monto", obj.Monto);
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

        public bool Actualizar(OrdenPago obj)
        {
            bool oSalida = false;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_ordenpago_actualizar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@IdSucursal", obj.Sucursal.Id);
                        cmd.Parameters.AddWithValue("@IdMoneda", obj.Moneda.Id);
                        cmd.Parameters.AddWithValue("@IdEstado", obj.Estado.Id);
                        cmd.Parameters.AddWithValue("@Monto", obj.Monto);
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

        public bool Eliminar(OrdenPago obj)
        {
            bool oSalida = false;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_ordenpago_eliminar", con))
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

        public OrdenPago ListarPorId(OrdenPago obj)
        {
            OrdenPago oOrdenPago = null;
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_ordenpago_listarXid", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                oOrdenPago = new OrdenPago
                                {
                                    Id = (int)odr["Id"],
                                    Moneda = new Moneda() { Id = (int)odr["IdMoneda"], Nombre = odr["Moneda"].ToString() },
                                    Estado = new Estado() { Id = (int)odr["IdEstado"], Nombre = odr["Estado"].ToString() },
                                    Sucursal = new Sucursal() { Id = (int)odr["IdSucursal"], Nombre = odr["Sucursal"].ToString() },
                                    Monto = decimal.Parse(odr["Monto"].ToString()),
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
            return oOrdenPago;
        }

        public List<OrdenPago> ListarTodos()
        {
            List<OrdenPago> loOrdenPago = new List<OrdenPago>();
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_ordenpago_listado", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                var oOrdenPago = new OrdenPago
                                {
                                    Id = (int)odr["Id"],
                                    Moneda = new Moneda() { Id = (int)odr["IdMoneda"], Nombre = odr["Moneda"].ToString() },
                                    Estado = new Estado() { Id = (int)odr["IdEstado"], Nombre = odr["Estado"].ToString() },
                                    Sucursal = new Sucursal() { Id = (int)odr["IdSucursal"], Nombre = odr["Sucursal"].ToString() },
                                    Monto = decimal.Parse(odr["Monto"].ToString()),
                                    Fecha = Convert.ToDateTime(odr["Fecha"].ToString())
                                };
                                loOrdenPago.Add(oOrdenPago);
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
            return loOrdenPago;
        }


        public List<OrdenPago> ListarPorMoneda(Moneda oMoneda, Sucursal oSucursal)
        {
            List<OrdenPago> loOrdenPago = new List<OrdenPago>();
            try
            {
                using (SqlConnection con = new SqlConnection(oCadenaCNN))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_ordenpago_listadoxmoneda", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", oSucursal.Id);
                        cmd.Parameters.AddWithValue("@IdMoneda", oMoneda.Id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader odr = cmd.ExecuteReader())
                        {
                            while (odr.Read())
                            {
                                var oOrdenPago = new OrdenPago
                                {
                                    Id = (int)odr["Id"],
                                    Moneda = new Moneda() { Id = (int)odr["IdMoneda"], Nombre = odr["Moneda"].ToString() },
                                    Estado = new Estado() { Id = (int)odr["IdEstado"], Nombre = odr["Estado"].ToString() },
                                    Sucursal = new Sucursal() { Id = (int)odr["IdSucursal"], Nombre = odr["Sucursal"].ToString() },
                                    Monto = decimal.Parse(odr["Monto"].ToString()),
                                    Fecha = Convert.ToDateTime(odr["Fecha"].ToString())
                                };
                                loOrdenPago.Add(oOrdenPago);
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
            return loOrdenPago;
        }
    }
}
