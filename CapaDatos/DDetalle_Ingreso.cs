﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        private int _IdDetalle_Ingreso;
        private int _Idingreso;
        private int _Idarticulo;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private DateTime _Fecha_Produccion;
        private DateTime _Fecha_Vencimiento;

        public int IdDetalle_Ingreso { get => _IdDetalle_Ingreso; set => _IdDetalle_Ingreso = value; }
        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public decimal Precio_Compra { get => _Precio_Compra; set => _Precio_Compra = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public int Stock_Inicial { get => _Stock_Inicial; set => _Stock_Inicial = value; }
        public int Stock_Actual { get => _Stock_Actual; set => _Stock_Actual = value; }
        public DateTime Fecha_Produccion { get => _Fecha_Produccion; set => _Fecha_Produccion = value; }
        public DateTime Fecha_Vencimiento { get => _Fecha_Vencimiento; set => _Fecha_Vencimiento = value; }

        public DDetalle_Ingreso()
        {

        }

        public DDetalle_Ingreso(int iddetalle_ingreso, int idingreso, int idarticulo, decimal precio_compra, decimal precio_venta, int stock_inicial, int stock_actual, DateTime fecha_produccion, DateTime fecha_vencimiento)
        {
            this.IdDetalle_Ingreso = iddetalle_ingreso;
            this.Idingreso = idingreso;
            this.Idarticulo = idarticulo;
            this.Precio_Compra = precio_compra;
            this.Precio_Venta = precio_venta;
            this.Stock_Inicial = stock_inicial;
            this.Stock_Actual = stock_actual;
            this.Fecha_Produccion = fecha_produccion;
            this.Fecha_Vencimiento = fecha_vencimiento;
        }

        //MANTENIMIENTO INSERTAR
        public string Insertar(DDetalle_Ingreso Detalle_Ingreso, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            
            try
            {
                //
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddtealle_Ingreso = new SqlParameter
                {
                    ParameterName = "@iddetalle_ingreso",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(ParIddtealle_Ingreso);

                SqlParameter ParIdingreso = new SqlParameter
                {
                    ParameterName = "@idingreso",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalle_Ingreso.Idingreso
                };
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdarticulo = new SqlParameter
                {
                    ParameterName = "@idarticulo",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalle_Ingreso.Idarticulo
                };
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParPrecio_Compra = new SqlParameter
                {
                    ParameterName = "@precio_compra",
                    SqlDbType = SqlDbType.Money,
                    Value = Detalle_Ingreso.Precio_Compra
                };
                SqlCmd.Parameters.Add(ParPrecio_Compra);

                SqlParameter ParPrecio_Venta = new SqlParameter
                {
                    ParameterName = "@precio_venta",
                    SqlDbType = SqlDbType.Money,
                    Value = Detalle_Ingreso.Precio_Venta
                };
                SqlCmd.Parameters.Add(ParPrecio_Venta);

                SqlParameter ParStock_Actual = new SqlParameter
                {
                    ParameterName = "@stock_actual",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalle_Ingreso.Stock_Actual
                };
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParStock_Inicial = new SqlParameter
                {
                    ParameterName = "@stock_inicial",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalle_Ingreso.Stock_Inicial
                };
                SqlCmd.Parameters.Add(ParStock_Inicial);

                SqlParameter ParFecha_Produccion = new SqlParameter
                {
                    ParameterName = "@fecha_produccion",
                    SqlDbType = SqlDbType.Date,
                    Value = Detalle_Ingreso.Fecha_Produccion
                };
                SqlCmd.Parameters.Add(ParFecha_Produccion);

                SqlParameter ParFecha_Vencimiento = new SqlParameter
                {
                    ParameterName = "@fecha_vencimiento",
                    SqlDbType = SqlDbType.Date,
                    Value = Detalle_Ingreso.Fecha_Vencimiento
                };
                SqlCmd.Parameters.Add(ParFecha_Vencimiento);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }
    }
}
