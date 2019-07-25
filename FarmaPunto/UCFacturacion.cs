using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace FarmaPunto
{
    public partial class UCFacturacion : UserControl
    {
        MedicamentosService servicios = new MedicamentosService();
        FacturaService serviciosFactura = new FacturaService();
        public UCFacturacion()
        {
            InitializeComponent();
            LbelFechaderealizacion.Text = DateTime.Now.ToShortDateString();
            TxtCodigoFactura.Text = Convert.ToString(serviciosFactura.consultarContador());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CodProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {

            try
            {
                int unidades = Convert.ToInt32(TxtUnidad.Text);

                //
                string nombre = TxtNombre.Text;
                string codigo = Txtcodigo.Text;
                string detalle = TxtDetalle.Text;
                int cantidad = Convert.ToInt32(TxtCantidad.Text);
                decimal precioventa = Convert.ToDecimal(TxtPrecioVenta.Text);
                decimal valor = Convert.ToDecimal(TxtValor.Text);
                string proveedor = CboxProveedores.Text;
                decimal impuesto = Convert.ToDecimal(TxtImpuesto.Text);
                decimal iva = Convert.ToDecimal(TxtIva.Text);
                //

                decimal calculo = (unidades * precioventa);
                Txttota.Text = Convert.ToString(calculo);
                decimal parcial = Convert.ToDecimal(Txttota.Text);
               
                string fecha = LbelFechaderealizacion.Text;
                string codigofactura = TxtCodigoFactura.Text;
                int nuevacantidad = cantidad - unidades;

                Factura factura = new Factura(codigofactura, codigo, nombre,unidades,iva,parcial,fecha);
                Medicamentos medicamento = new Medicamentos(codigo, nombre, nuevacantidad, valor, detalle, proveedor, impuesto);
                string res = servicios.ModificarMedicamentos(medicamento);
                MessageBox.Show("Stock actualizado", "Resultado de Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string respuesta = serviciosFactura.GuardarFactura(factura);
                MessageBox.Show(respuesta);

                DtgElementosFactura.DataSource = serviciosFactura.ConsultarFacturacodigo(codigofactura);
                TxtTotalFactura.Text = Convert.ToString(serviciosFactura.Calcular(codigofactura).TotalCodigo);

            }
            catch (Exception E)
            {
                MessageBox.Show("Error !! " + E.ToString());
            }
        }

        private void UCFacturacion_Load(object sender, EventArgs e)
        {

        }

        private void TxtTotal_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal contador = serviciosFactura.consultarContador();
            contador++;
            serviciosFactura.GuardarContador(contador);
            TxtCodigoFactura.Text = Convert.ToString(contador);
            DtgElementosFactura.DataSource = null;
        
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Medicamentos medicamento = servicios.BuscarMedicamento(Txtcodigo1.Text);
            if (medicamento != null)
            {
                try
                {

                    Txtcodigo.Text = medicamento.CodigoMedicamento;
                    TxtCantidad.Text = Convert.ToString(medicamento.Cantidad);
                    TxtDetalle.Text = medicamento.Detalle;
                    TxtImpuesto.Text = Convert.ToString(medicamento.Impuesto);
                    TxtNombre.Text = medicamento.NombreMedicamento;
                    TxtPrecioVenta.Text = Convert.ToString(medicamento.PrecioVenta);
                    TxtValor.Text = Convert.ToString(medicamento.ValorUnitario);
                    CboxProveedores.Text = medicamento.Proveedor;
                    TxtIva.Text = Convert.ToString(medicamento.Iva);
                }
                catch (Exception E)
                {
                    MessageBox.Show("Error !! " + E);
                }
            }
            else
            {
                MessageBox.Show("No se encontro");
            }
        }

        private void bunifuSeparator7_Load(object sender, EventArgs e)
        {

        }

        private void TxtImpuesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
