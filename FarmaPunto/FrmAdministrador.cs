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
    public partial class FrmAdministrador : MetroFramework.Forms.MetroForm
    {
        UCGestionDeUsuarios gestionDeUsuarios = new UCGestionDeUsuarios();
        UCRegistroDeProductos registroDeProductos = new UCRegistroDeProductos();
        UCHistorialDeVentas historialDeVentas = new UCHistorialDeVentas();
        CboxFlitro gestionDeFacturas = new CboxFlitro();
        UCGestionProveedores gestionProveedores = new UCGestionProveedores();

        public FrmAdministrador()
        {
            InitializeComponent();
            timer.Enabled = true;
        }

        private void FrmAdministrador_Load(object sender, EventArgs e)
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LbelHora.Text = DateTime.Now.ToString();
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

        public void Mostraycambiar(UserControl userControl)
        {
            CambiarColor(BtnUsuarios);
            CambiarColor(BtnFacturas);
            CambiarColor(BtnProducto);
            CambiarColor(BtnProveedor);
            CambiarColor(BtnGestiondeVentas);
            MostrarControl(userControl);
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Mostraycambiar(gestionDeUsuarios);
        }

        private void BtnFacturas_Click(object sender, EventArgs e)
        {
            Mostraycambiar(gestionDeFacturas);
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            Mostraycambiar(registroDeProductos);
        }

        private void BtnProveedor_Click(object sender, EventArgs e)
        {
            Mostraycambiar(gestionProveedores);
        }

        private void BtnGestiondeVentas_Click(object sender, EventArgs e)
        {
            Mostraycambiar(historialDeVentas);
        }
    }
}
