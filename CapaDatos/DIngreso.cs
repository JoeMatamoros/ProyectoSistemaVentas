﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DIngreso
    {
        private int _Idingreso;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        public DIngreso()
        {

        }

        public DIngreso(int idingreso, int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, string estado)
        {
            this.Idingreso = idingreso;
            this.Idtrabajador = idtrabajador;
            this.Idproveedor = idproveedor;
            this.Fecha = fecha;
            this.Tipo_Comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;
        }

        //METODOS
        public string Insertar(DIngreso Ingreso, List<DDetalle_Ingreso> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //ESTABLECER TRANSACCION
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter
                {
                    ParameterName = "@idingreso",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdtrabajador = new SqlParameter
                {
                    ParameterName = "@idtrabajador",
                    SqlDbType = SqlDbType.Int,
                    Value = Ingreso.Idtrabajador
                };
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParIdproveedor = new SqlParameter
                {
                    ParameterName = "@idproveedor",
                    SqlDbType = SqlDbType.Int,
                    Value = Ingreso.Idproveedor
                };
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter ParFecha = new SqlParameter
                {
                    ParameterName = "@fecha",
                    SqlDbType = SqlDbType.Date,
                    Value = Ingreso.Fecha
                };
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipo_Comprobante = new SqlParameter
                {
                    ParameterName = "@tipo_comprobante",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Ingreso.Tipo_Comprobante
                };
                SqlCmd.Parameters.Add(ParTipo_Comprobante);

                SqlParameter ParSerie = new SqlParameter
                {
                    ParameterName = "@serie",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Ingreso.Serie
                };
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter
                {
                    ParameterName = "@correlativo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Ingreso.Correlativo
                };
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIgv = new SqlParameter
                {
                    ParameterName = "@igv",
                    SqlDbType = SqlDbType.Decimal,
                    Precision = 4,
                    Scale = 2,
                    Value = Ingreso.Igv
                };
                SqlCmd.Parameters.Add(ParIgv);

                SqlParameter ParEstado = new SqlParameter
                {
                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 7,
                    Value = Ingreso.Estado
                };
                SqlCmd.Parameters.Add(ParEstado);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

                if (rpta.Equals("OK"))
                {
                    //OBTENER CODIGO DEL INGRESO GENERADO
                    this.Idingreso = Convert.ToInt32(SqlCmd.Parameters["@idingreso"].Value);
                    foreach(DDetalle_Ingreso det in Detalle)
                    {
                        det.Idingreso = this.Idingreso;
                        //LLAMADO AL METODO INSERTAR DE LA CLASE DETALLE DE INGRESO
                        rpta = det.Insertar(det,ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }

                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;

        }

        public string Anular(DIngreso Ingreso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spanular_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter
                {
                    ParameterName = "@idingreso",
                    SqlDbType = SqlDbType.Int,
                    Value = Ingreso.Idingreso
                };
                SqlCmd.Parameters.Add(ParIdingreso);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;

        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;

        }

        //BUSCAR POR FECHAS
        public DataTable BuscarFechas(string TextoBuscar, string TextoBuscar2)
        {

            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_ingreso_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = TextoBuscar
                };
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter
                {
                    ParameterName = "@textobuscar2",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = TextoBuscar2
                };
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;

        }

        public DataTable MostrarDetalle(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);
            
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;

        }

    }
}
