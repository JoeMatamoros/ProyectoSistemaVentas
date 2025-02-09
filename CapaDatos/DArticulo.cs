﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DArticulo
    {
        private int _IdArticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _IdCategoria;
        private int _IdPresentacion;
        private string _TextoBuscar;

        public int IdArticulo { get => _IdArticulo; set => _IdArticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public int IdPresentacion { get => _IdPresentacion; set => _IdPresentacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DArticulo()
        {

        }

        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string textobuscar)
        {
            this.IdArticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.IdCategoria = idcategoria;
            this.IdPresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;

        }

        /*MANTENIMIENTOS CRUD*/
        public string Insertar(DArticulo Articulo)
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
                SqlCmd.CommandText = "spinsertar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdArticulo = new SqlParameter
                {
                    ParameterName = "@idarticulo",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParCodigo = new SqlParameter
                {
                    ParameterName = "@codigo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Articulo.Codigo
                };
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter
                {
                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = Articulo.Nombre
                };
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter
                {
                    ParameterName = "@descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 1024,
                    Value = Articulo.Descripcion
                };
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter
                {
                    ParameterName = "@imagen",
                    SqlDbType = SqlDbType.Image,
                    Value = Articulo.Imagen
                };
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdCategoria = new SqlParameter
                {
                    ParameterName = "@idcategoria",
                    SqlDbType = SqlDbType.Int,
                    Value = Articulo.IdCategoria
                };
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdPresentacion = new SqlParameter
                {
                    ParameterName = "@idpresentacion",
                    SqlDbType = SqlDbType.Int,
                    Value = Articulo.IdPresentacion
                };
                SqlCmd.Parameters.Add(ParIdPresentacion);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

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

        public string Editar(DArticulo Articulo)
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
                SqlCmd.CommandText = "speditar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdArticulo = new SqlParameter
                {
                    ParameterName = "@idarticulo",
                    SqlDbType = SqlDbType.Int,
                    Value = Articulo.IdArticulo
                };
                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParCodigo = new SqlParameter
                {
                    ParameterName = "@codigo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Articulo.Codigo
                };
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter
                {
                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = Articulo.Nombre
                };
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter
                {
                    ParameterName = "@descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 1024,
                    Value = Articulo.Descripcion
                };
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter
                {
                    ParameterName = "@imagen",
                    SqlDbType = SqlDbType.Image,
                    Value = Articulo.Imagen
                };
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdCategoria = new SqlParameter
                {
                    ParameterName = "@idcategoria",
                    SqlDbType = SqlDbType.Int,
                    Value = Articulo.IdCategoria
                };
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdPresentacion = new SqlParameter
                {
                    ParameterName = "@idpresentacion",
                    SqlDbType = SqlDbType.Int,
                    Value = Articulo.IdPresentacion
                };
                SqlCmd.Parameters.Add(ParIdPresentacion);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

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

        public string Eliminar(DArticulo Articulo)
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
                SqlCmd.CommandText = "speliminar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdArticulo = new SqlParameter
                {
                    ParameterName = "@idarticulo",
                    SqlDbType = SqlDbType.Int,
                    Value = Articulo.IdArticulo
                };
                SqlCmd.Parameters.Add(ParIdArticulo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";


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
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_articulo";
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

        public DataTable BuscarNombre(DArticulo Articulo)
        {

            DataTable DtResultado = new DataTable("articulo"); //Tal cual está en la base de datos.
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_articulo_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Articulo.TextoBuscar
                };
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
