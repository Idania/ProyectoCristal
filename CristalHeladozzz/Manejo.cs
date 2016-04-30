using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;

namespace CristalHeladozzz
{
    class Manejo
    {

        public class Cliente
        {
            public string NombreC { set; get; }
            public string AppC { set; get; }
            public string ApmC { set; get; }
            public string RFC { set; get; }
            public string Telefono { set; get; }
            public int IdCliente { set; get; }



            //CONSTRUCTOR~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~**************+

            public Cliente()
            {
                IdCliente = 0;
                NombreC = "";
                AppC = "";
                ApmC = "";
                RFC = "";
                Telefono = "";
            }

            public Cliente(int ID, string nom, string ap, string am, string rf, string te)
            {
                IdCliente = ID;
                NombreC = nom;
                AppC = ap;
                ApmC = am;
                RFC = rf;
                Telefono = te;
            }


            //******metodo para manipular la base de datos ~~~~~~~~~~~~~~~~~~~**********

            public int alta()
            {
                MySqlCommand Commando;
                Datos Insertar = new Datos();
                int regresa = 0;
                if (Insertar.AbrirConexion())
                {
                    string cad_comando = "Insert into Cliente(IdCliente,NombreC,AppC,ApmC,RFC,Telefono)" + "values(" + IdCliente + ",'" + NombreC + "','" + AppC + "','" + ApmC + "','" + RFC + "','" + Telefono + "')";
                    Commando = Insertar.construye_command(cad_comando);

                    if (Insertar.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    Insertar.desconectar();
                }
                else
                    regresa = -1;
                return regresa;
            }//fin alta
            public int eliminar()
            {
                MySqlCommand Commando;
                Datos Insertar = new Datos();
                int regresa = 0;
                if (Insertar.AbrirConexion())
                {
                    string cad_comando = "delete FROM `Cliente` WHERE `IdCliente` = " + IdCliente;
                    Commando = Insertar.construye_command(cad_comando);

                    if (Insertar.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    Insertar.desconectar();
                }
                else
                    regresa = -1;
                return regresa;
            }


        } // fin class Cliente


        public class Factura
        {
            public int IdFactura { set; get; }
            public int IdCliente { set; get; }
            public int IdVendedor { set; get; }
            public DateTime Fecha { get; set; }
            public double Subtotal { get; set; }
            public double Total { get; set; }



            //CONSTRUCTOR~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~**************+

            public int alta()
            {

                MySqlCommand Commando;
                Datos inserta = new Datos();
                int regresa = 0;
                if (inserta.AbrirConexion())
                {


                    string cad_comando = "INSERT INTO `eliarome35448DB`.`Factura` (`IdFactura`, `IdCliente`, `IdVendedor`, `Fecha`, `Subtotal`, `Total`) VALUES ('" + IdFactura + "," + IdCliente + "','" + IdVendedor + "','" + Fecha + "','" + Subtotal + "','" + Total + "')";
                    Commando = inserta.construye_command(cad_comando);

                    if (inserta.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    inserta.desconectar();
                }
                else
                    regresa = -1;
                return regresa;

            }
        }//fin clas Factura

        public class Insumos
        {
            public int IdInsumo { set; get; }
            public double PrePintura { get; set; }
            public double PreGancho { get; set; }
            public double PreCarton { get; set; }
            public int CanEsferas { get; set; }
            public int tamaño { get; set; }
            public String color { get; set; }

            public int alta()
            {
                MySqlCommand Commando;
                Datos inserta = new Datos();
                int regresa = 0;
                if (inserta.AbrirConexion())
                {
                    string cad_comando = "INSERT INTO `eliarome35448DB`.`Insumos` (`IdInsumo`, `Precio_pintura`, `Precio_carton`, `Precio_gancho`, `Cantidad_esferas`, `Tamaño_cm`, `Color`) VALUES ('" + IdInsumo + "','" + PrePintura + "','" + PreCarton + "','" + PreGancho + "','" + CanEsferas + "','" + tamaño + "','" + color + "')";
                    Commando = inserta.construye_command(cad_comando);

                    if (inserta.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    inserta.desconectar();
                }
                else
                    regresa = -1;
                return regresa;
            }
            public int eliminar()
            {
                MySqlCommand Commando;
                Datos inserta = new Datos();
                int regresa = 0;
                if (inserta.AbrirConexion())
                {
                    string cad_comando = "delete FROM `Insumos` WHERE `IdInsumo` = " + IdInsumo;
                    Commando = inserta.construye_command(cad_comando);

                    if (inserta.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    inserta.desconectar();
                }
                else
                    regresa = -1;
                return regresa;
            }


            ////

        }//fin clas Insumos

        public class Producto
        {
            public int Idesfera { set; get; }
            public int IdInsumo { set; get; }
            public int cantidad { set; get; }
            public double precio { set; get; }
            public string descripcion { set; get; }
            public double Caja { get; set; }


            public int alta()
            {
                MySqlCommand Commando;
                Datos inserta = new Datos();
                int regresa = 0;
                if (inserta.AbrirConexion())
                {
                    string cad_comando = "INSERT INTO `eliarome35448DB`.`Producto` (`Descripcion`, `IdInsumo`, `Cantidad`, `Precio`,`Caja`) VALUES ('" + descripcion + "','" + IdInsumo + "','" + cantidad + "','" + precio + "','" + Caja + "')";
                    Commando = inserta.construye_command(cad_comando);

                    if (inserta.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    inserta.desconectar();
                }
                else
                    regresa = -1;
                return regresa;

            }
            public int eliminar()
            {
                MySqlCommand Commando;
                Datos inserta = new Datos();
                int regresa = 0;
                if (inserta.AbrirConexion())
                {
                    string cad_comando = "delete FROM `Producto` WHERE `IdProducto` =" + Idesfera;
                    Commando = inserta.construye_command(cad_comando);

                    if (inserta.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    inserta.desconectar();
                }
                else
                    regresa = -1;
                return regresa;

            }
            public void disponibilidad(int id, int can)
            {
                               MySqlCommand Commando;
                Datos inserta = new Datos();
                int regresa = 0;
                if (inserta.AbrirConexion())
                {
                string cad_comando ="UPDATE `Producto` SET `Cantidad` = " + can + "  where `IdProducto` =" + id;
                    Commando = inserta.construye_command(cad_comando);

                    if (inserta.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    inserta.desconectar();
                }
                else
                    regresa = -1; 
            }

        }//fin clas Producto

        public class Vendedor
        {
            public int IdVendedor { set; get; }
            public string NombreV { set; get; }
            public string AppV { set; get; }
            public string Telefono { set; get; }


            public int alta()
            {
                MySqlCommand Commando;
                Datos inserta = new Datos();
                int regresa = 0;
                if (inserta.AbrirConexion())
                {
                    string cad_comando = "Insert into Vendedor(IdVendedor,NombreV,AppV,Telefono)" + "values(" + IdVendedor + ",'" + NombreV + "','" + AppV + "','" + Telefono + "')";
                    Commando = inserta.construye_command(cad_comando);

                    if (inserta.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    inserta.desconectar();
                }
                else
                    regresa = -1;
                return regresa;

            }
            public int Eliminar()
            {
                MySqlCommand Commando;
                Datos inserta = new Datos();
                int regresa = 0;
                if (inserta.AbrirConexion())
                {
                    string cad_comando = "delete FROM `Vendedor` WHERE `IdVendedor` = " + IdVendedor;
                    Commando = inserta.construye_command(cad_comando);

                    if (inserta.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    inserta.desconectar();
                }
                else
                    regresa = -1;
                return regresa;

            }
        }//fin clas tratamiento

        public class Venta
        {
            public int IdVenta { get; set; }
            public int IdEsfera { get; set; }
            public int idFactura { get; set; }
            public String Descripcion { get; set; }
            public double Subtotal { get; set; }
            public int Cantidad { get; set; }

            public Venta()
            {
            }

            public Venta(int idv, int ide, int idf, String des, double sub, int cant)
            {
                IdVenta = idv;
                IdEsfera = ide;
                idFactura = idf;
                Descripcion = des;
                Subtotal = sub;
                Cantidad = cant;
            }

            public int alta()
            {
                MySqlCommand Commando;
                Datos inserta = new Datos();
                int regresa = 0;
                if (inserta.AbrirConexion())
                {
                    string cad_comando = "INSERT INTO `eliarome35448DB`.`Venta` (`IdFactura`, `IdProducto`, `Cantidad`, `Costo`, `Descripcion`) VALUES ('" + idFactura + "','" + IdEsfera + "','" + Cantidad + "','" + Subtotal + "','" + Descripcion + "')";
                    Commando = inserta.construye_command(cad_comando);

                    if (inserta.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    inserta.desconectar();
                }
                else
                    regresa = -1;
                return regresa;
            }

            public int Eliminar()
            {
                MySqlCommand Commando;
                Datos inserta = new Datos();
                int regresa = 0;
                if (inserta.AbrirConexion())
                {
                    string cad_comando = "delete FROM `Venta` WHERE `IdVenta` =" + IdVenta;
                    Commando = inserta.construye_command(cad_comando);

                    if (inserta.ejecutanonquery() != 0)
                        regresa = 1;
                    else
                        regresa = 0;
                    Commando.Connection.Close();
                    inserta.desconectar();
                }
                else
                    regresa = -1;
                return regresa;
            }

            public static MySqlConnection ObtenerConexion()
            {
                MySqlConnection conectar = new MySqlConnection("Server=74.63.196.2; Database=eliarome35448DB; uid=eliarome35448; pwd=4lnS6eodR3Ei;");
                conectar.Open();
                return conectar;
            }

            public void person(TextBox fa, Label l1)
            {
                string a = "", b = "", c = "";
                MySqlCommand _comando = new MySqlCommand(String.Format(
                "SELECT `Name_c`,`App_c`,`Apm_c` FROM `Cliente` WHERE `Id_Cliente` = {0}", fa.Text), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    a = _reader.GetString(0);
                    b = _reader.GetString(1);
                    c = _reader.GetString(2);
                }
                l1.Text = a + " " + b + " " + c;
            }
            public void suma(TextBox fa, Label l1, Label l2, Label l3)
            {
                double sum = 0;
                MySqlCommand _comando = new MySqlCommand(String.Format(
                "SELECT sum(`Costo`) FROM `Venta` WHERE `IdFactura` = {0}", fa.Text), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    sum = _reader.GetDouble(0);
                }
                l1.Text = Convert.ToString(sum);
                double st = sum * .16;
                l2.Text = Convert.ToString(st);
                l3.Text = Convert.ToString(sum + st);
            }
            public void Cancelar(TextBox fa)
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
                "delete FROM `Venta` WHERE `IdFactura` = " + fa.Text), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                _reader.Read();

            }
            public static List<Venta> carrito(TextBox id_ven)
            {
                List<Venta> _lista = new List<Venta>();
                MySqlCommand _comando = new MySqlCommand(String.Format("SELECT *FROM  `Venta` WHERE  `IdFactura` = {0}", id_ven.Text), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Venta pin = new Venta();
                    pin.IdVenta = _reader.GetInt32(0);
                    pin.idFactura = _reader.GetInt32(1);
                    pin.IdEsfera = _reader.GetInt32(2);
                    pin.Cantidad = _reader.GetInt32(3);
                    pin.Subtotal = _reader.GetDouble(4);
                    pin.Descripcion = _reader.GetString(5);
                    _lista.Add(pin);
                }
                return _lista;
            }
        }

    }
}