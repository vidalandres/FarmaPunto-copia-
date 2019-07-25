using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaPunto
{
    public partial class FrmFarmaceutico : MetroFramework.Forms.MetroForm
    {
        UCFacturacion uCFacturacion = new UCFacturacion();
        UCDetallesDeProductos detallesDeProductos = new UCDetallesDeProductos();
        public FrmFarmaceutico()
        {
            InitializeComponent();
            Timer.Enabled = true;
        }

        private void FrmFarmaceutico_Load(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LbelHora.Text = DateTime.Now.ToString();
        }

        private void BtnFacturacion_Click(object sender, EventArgs e)
        {
            CambiarColor(BtnFacturacion);
            MostrarControl(uCFacturacion);
            CambiarColor(BtnProductos);
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            CambiarColor(BtnProductos);
            MostrarControl(detallesDeProductos);
            CambiarColor(BtnFacturacion);
        }
        public void MostrarControl(UserControl control)
        {
            if (!PnelEjecucion.Controls.Contains(control))
            {
                PnelEjecucion.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                control.BringToFront();
            }
            else
            {
                control.BringToFront();
            }
        }

        public void CambiarColor(Button button)
        {
            if (button.Focused)
            {
                button.BackColor = Color.DimGray;
            }
            else
            {
                button.BackColor = Color.Crimson;
             
            }
        }

        private void PnelEjecucion_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
