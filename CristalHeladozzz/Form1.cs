using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CristalHeladozzz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clienteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eliarome35448DBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'eliarome35448DBDataSet1.Producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.eliarome35448DBDataSet1.Producto);
            // TODO: esta línea de código carga datos en la tabla 'eliarome35448DBDataSet.Producto' Puede moverla o quitarla según sea necesario.
           // this.productoTableAdapter.Fill(this.eliarome35448DBDataSet.Producto);
            // TODO: esta línea de código carga datos en la tabla 'eliarome35448DBDataSet.Insumos' Puede moverla o quitarla según sea necesario.
            this.insumosTableAdapter.Fill(this.eliarome35448DBDataSet.Insumos);
            // TODO: esta línea de código carga datos en la tabla 'eliarome35448DBDataSet.Vendedor' Puede moverla o quitarla según sea necesario.
            this.vendedorTableAdapter.Fill(this.eliarome35448DBDataSet.Vendedor);
            // TODO: esta línea de código carga datos en la tabla 'eliarome35448DBDataSet.Cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.eliarome35448DBDataSet.Cliente);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        Manejo.Cliente C1 = new Manejo.Cliente();
        private void btnAgregar_Click(object sender, EventArgs e)
        {



            if (txtapm.Text != "" && txtapp.Text != "" && txtId.Text != "" && txtnom.Text != "" && txtrfc.Text != "" && txttel.Text != "")
            {
                C1.IdCliente = +Convert.ToInt32(txtId.Text);
                C1.NombreC = txtnom.Text;
                C1.AppC = txtapp.Text;
                C1.ApmC = txtapm.Text;
                C1.RFC = txtrfc.Text;
                C1.Telefono = txttel.Text;

                if (C1.alta() == 1)
                {
                    MessageBox.Show("El registro ha sido completado con éxito");
                    this.clienteTableAdapter.Fill(this.eliarome35448DBDataSet.Cliente);
                }
                else
                    MessageBox.Show("No se pudo realizar el registro. Revise su conexión con la base de datos");
            }
            else
                MessageBox.Show("Ingrese todos los datos porque alguna caja esta vacia");



            txtapm.Clear();
            txtapp.Clear();
            txtId.Clear();
            txtnom.Clear();
            txtrfc.Clear();
            txttel.Clear();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            C1.IdCliente = +Convert.ToInt32(txtId.Text);
            if (C1.eliminar() == 1)
            {
                MessageBox.Show("La Eliminacion ha sido completado con éxito");
                this.clienteTableAdapter.Fill(this.eliarome35448DBDataSet.Cliente);
            }
            else
                MessageBox.Show("No se pudo realizar la Eliminacion. Revise su conexión con la base de datos");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        Manejo.Producto ES = new Manejo.Producto();
        Manejo.Vendedor P1 = new Manejo.Vendedor();
        Manejo.Insumos lote = new Manejo.Insumos();
        private void btnAgregar5_Click(object sender, EventArgs e)
        {

            if (txtapp2.Text != "" && txtId2.Text != "" && txtnom2.Text != "" && txttel2.Text != "")
            {

                P1.IdVendedor = +Convert.ToInt32(txtId2.Text);
                P1.NombreV = txtnom2.Text;
                P1.AppV = txtapp2.Text;
                P1.Telefono = txttel2.Text;


                if (P1.alta() == 1)
                {
                    MessageBox.Show("El registro ha sido completado con éxito");
                    this.vendedorTableAdapter.Fill(this.eliarome35448DBDataSet.Vendedor);
                }
                else
                    MessageBox.Show("No se pudo realizar el registro. Revise su conexión con la base ");
            }
            else MessageBox.Show("Llene las casillas");

        }

        private void btnSeleccionar5_Click(object sender, EventArgs e)
        {
            if (txtId2.Text != "")
            {
                P1.IdVendedor = +Convert.ToInt32(txtId2.Text);
                if (P1.Eliminar() == 1)
                {
                    MessageBox.Show("El registro ha sido completado con éxito");
                    this.vendedorTableAdapter.Fill(this.eliarome35448DBDataSet.Vendedor);
                }
                else
                    MessageBox.Show("No se pudo realizar el registro. Revise su conexión con la base ");
            }
            else
                MessageBox.Show("Falta llenar id_vendedor");
        }

        double precio;
        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            double pre1 = Convert.ToDouble(txtprecio_pint.Text);
            double pre2 = Convert.ToDouble(txtpre_carto.Text);
            double pre3 = Convert.ToDouble(txtpre_ganc.Text);
            int tam = Convert.ToInt32(txttamaño.Text);

            lote.IdInsumo = Convert.ToInt32(textBox1.Text);
            lote.tamaño = Convert.ToInt32(txttamaño.Text);
            lote.PrePintura = Convert.ToDouble(txtprecio_pint.Text);
            lote.PreCarton = Convert.ToDouble(txtpre_carto.Text);
            lote.PreGancho = Convert.ToDouble(txtpre_ganc.Text);

            if (tam == 3)
            {
                lote.CanEsferas = 300;
                precio = (pre1 + pre2 + pre3) / 300;
                ES.cantidad = 300;

                ES.Caja=pre2/300;
            }

            else
            {
                lote.CanEsferas = 265;
                precio = (pre1 + pre2 + pre3) / 265;
                ES.cantidad = 265;

                ES.Caja = pre2 / 265;
            }

            lote.color = txtcolor.Text;

            if (lote.alta() == 1)
            {
                MessageBox.Show("El registro de Lote ha sido completado con éxito");
                this.insumosTableAdapter.Fill(this.eliarome35448DBDataSet.Insumos);
                string des = "Esfera Tamaño " + Convert.ToInt32(txttamaño.Text) + "cm Color " + txtcolor.Text;
                //precio = (pre1 + pre2 + pre3) / Convert.ToDouble(txtcantidad1.Text);
                ES.IdInsumo = Convert.ToInt32(textBox1.Text);
                //ES.cantidad = Convert.ToInt32(txtcantidad1.Text);
                ES.descripcion = des;
                ES.precio = precio;

                if (ES.alta() == 1)
                {
                    MessageBox.Show("El registro de Esfera ha sido completado con éxito");
                    this.productoTableAdapter.Fill(this.eliarome35448DBDataSet1.Producto);
                    this.vendedorTableAdapter.Fill(this.eliarome35448DBDataSet.Vendedor);
                }
                else
                    MessageBox.Show("No se pudo realizar el registro. Revise su conexión con la base ");
            }
            else
                MessageBox.Show("No se pudo realizar el registro. Revise su conexión con la base ");
        }

        private void btnSeleccionar2_Click(object sender, EventArgs e)
        {
            lote.IdInsumo = Convert.ToInt32(textBox1.Text);
            if (lote.eliminar() == 1)
            {
                MessageBox.Show("El registro ha sido completado con éxito");
                this.insumosTableAdapter.Fill(this.eliarome35448DBDataSet.Insumos);
            }
            else
                MessageBox.Show("No se pudo realizar el registro. Revise su conexión con la base ");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            Manejo.Producto Prod = new Manejo.Producto();
            Prod.Idesfera = Convert.ToInt32(txtIdProducto1.Text);
            if (Prod.eliminar() == 1)
            {
                MessageBox.Show("El registro ha sido completado con éxito");
                //this.productoTableAdapter.Fill(this.eliarome35448DBDataSet.Producto);
            }
            else
                MessageBox.Show("No se pudo realizar el registro. Revise su conexión con la base ");
        }
        string descrip = "";
        int nue_canti=0;
        public double Cantid_valid()
        {
            double pre_unita = Convert.ToDouble(precioLabel1.Text);
            double Subtotal = 0;
            if (comboBox1.Text=="6")
            {
                descrip = "Caja 6 " + descripcionLabel1.Text;
                Subtotal = (pre_unita+ Convert.ToDouble(cajaLabel1.Text)) * (Convert.ToDouble(txtcantidad2.Text) * 6);
                nue_canti = Convert.ToInt32(cantidadLabel1.Text)- Convert.ToInt32(txtcantidad2.Text) * 6;
            }
            else
            if (comboBox1.Text == "12")
            {
                descrip = "Caja 12 " + descripcionLabel1.Text;
                Subtotal = (pre_unita + Convert.ToDouble(cajaLabel1.Text)) * (Convert.ToDouble(txtcantidad2.Text) * 12);
                nue_canti = Convert.ToInt32(cantidadLabel1.Text) - Convert.ToInt32(txtcantidad2.Text) * 12;
            }
            else
            if (comboBox1.Text == "24")
            {
                descrip = "Caja 24 " + descripcionLabel1.Text;
                Subtotal = (pre_unita + Convert.ToDouble(cajaLabel1.Text)) * (Convert.ToDouble(txtcantidad2.Text) * 24);
                nue_canti = Convert.ToInt32(cantidadLabel1.Text) - Convert.ToInt32(txtcantidad2.Text) * 24;
            }
            else
            {
                descrip = descripcionLabel1.Text;
                Subtotal = pre_unita * (Convert.ToDouble(txtcantidad2.Text));
                nue_canti = Convert.ToInt32(cantidadLabel1.Text) - Convert.ToInt32(txtcantidad2.Text);
            }

            return Subtotal;

        }

        Manejo.Venta obj1 = new Manejo.Venta();
        private void btnAgregar4_Click(object sender, EventArgs e)
        {
            int cant = Convert.ToInt32(txtcantidad2.Text);
            int exis = Convert.ToInt32(cantidadLabel1.Text);

            if (cant > exis)
                MessageBox.Show("No hay suficentes esferas");

            else
            {

                obj1.idFactura = Convert.ToInt32(txtidventa.Text);
                obj1.IdEsfera = Convert.ToInt32(idProductoLabel1.Text);
                obj1.Cantidad = Convert.ToInt32(txtcantidad2.Text);
                obj1.Subtotal = Cantid_valid();
                obj1.Descripcion = descrip;

                if (obj1.alta() == 1)
                {
                    MessageBox.Show("El registro ha sido completado con éxito");
                    dataGridView1.DataSource = Manejo.Venta.carrito(txtidventa);
                    ES.disponibilidad(Convert.ToInt32(idProductoLabel1.Text), nue_canti);
                 //   this.productoTableAdapter.Fill(this.eliarome35448DBDataSet.Producto);
                }
                else
                    MessageBox.Show("No se pudo realizar el registro. Revise su conexión con la base ");

                lblFactura.Text = txtidventa.Text;
                lblCliente.Text = nombreCLabel1.Text + " " + appCLabel1.Text + " " + apmCLabel1.Text;
                lblFecha.Text = dateTimePicker2.Value.ToShortDateString();
                lblVendedor.Text = nombreVLabel1.Text + " " + appVLabel1.Text;

                lblClienteN.Text = nombreCLabel1.Text + " " + appCLabel1.Text + " " + apmCLabel1.Text;
                lblFechaN.Text = dateTimePicker2.Value.ToShortDateString();
                lblVendedorN.Text = nombreVLabel1.Text + " " + appVLabel1.Text;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Manejo.Venta.carrito(txtidventa);
            obj1.suma(txtidventa,txtsubtotal,txtiva,txttotal);

            tabControl1.SelectTab(tabPage7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtidventa.Text != "")
            {
                obj1.Cancelar(txtidventa);
            }

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = Manejo.Venta.carrito(txtidventa);
            label32.Text = txtsubtotal.Text;

            tabControl1.SelectTab(tabPage4);
        }

        private void insumosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
