using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace FarmaPunto
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        MedicamentosService servicios = new MedicamentosService();
        public frmLogin()
        {         
            InitializeComponent();          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {
                      
        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {


            if (TxtContraseña.Text.Equals("1999") && TxtNombreDeUsuario.Text.Equals("alcides"))
            {
                ControlarCampos();
                this.Hide();
                MessageBox.Show("A Ingrsado Como Farmaceutico");
                new FrmFarmaceutico().ShowDialog();
            }

            if (TxtContraseña.Text.Equals("1999") && TxtNombreDeUsuario.Text.Equals("andres"))
            {
                ControlarCampos();
                this.Hide();
                MessageBox.Show("A Ingresado Como Administardor");
                new FrmAdministrador().ShowDialog();
            }
            Validar();
            this.Show();
        }

        public void ControlarCampos()
        {
            SprtorUsuario.LineColor = Color.DimGray;
            SeparadorContraseña.LineColor = Color.DimGray;
            TxtContraseña.Text = ("");
            TxtNombreDeUsuario.Text = ("");
        }

        public void Validar()
        {
            if (TxtContraseña.Text != ("1999") && TxtNombreDeUsuario.Text != ("alcides"))
            {
                SprtorUsuario.LineColor = Color.Red;
                SeparadorContraseña.LineColor = Color.Red;

            }

            if (TxtContraseña.Text.Equals("1999") && TxtNombreDeUsuario.Text != ("alcides"))
            {
                SprtorUsuario.LineColor = Color.Red;
                SeparadorContraseña.LineColor = Color.DimGray;

            }

            if (TxtContraseña.Text != ("1999") && TxtNombreDeUsuario.Text.Equals("alcides"))
            {
                SeparadorContraseña.LineColor = Color.Red;
                SprtorUsuario.LineColor = Color.DimGray;

            }

            else if (TxtContraseña.Text != ("1999") && TxtNombreDeUsuario.Text != ("andres"))
            {
                SprtorUsuario.LineColor = Color.Red;
                SeparadorContraseña.LineColor = Color.Red;
            }

            else if (TxtContraseña.Text.Equals("1999") && TxtNombreDeUsuario.Text != ("andres"))
            {
                SprtorUsuario.LineColor = Color.Red;
                SeparadorContraseña.LineColor = Color.DimGray;
            }

            else if (TxtContraseña.Text != ("1999") && TxtNombreDeUsuario.Text.Equals("andres"))
            {
                SeparadorContraseña.LineColor = Color.Red;
                SprtorUsuario.LineColor = Color.DimGray;
            }
        }


        private void ChxVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (TxtContraseña.UseSystemPasswordChar==true)
            {
                TxtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                TxtContraseña.UseSystemPasswordChar = true;
            }
            this.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
