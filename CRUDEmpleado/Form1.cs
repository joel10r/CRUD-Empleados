using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDEmpleado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            slidePanel.Height = btnAgregar.Height;
        }

       
        private Form formActivo = null;

        private void formHijo(Form formHijo)
        {
            if (formActivo != null)
            {
                formActivo.Close();
            }

            formActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlCentral.Controls.Add(formHijo);
            pnlCentral.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnAgregar.Height;
            slidePanel.Top = btnAgregar.Top;
            formHijo(new frmAgregar());
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnEditar.Height;
            slidePanel.Top = btnEditar.Top;
            formHijo(new frmEditar());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnEliminar.Height;
            slidePanel.Top = btnEliminar.Top;
            formHijo(new frmEliminar());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnReporte.Height;
            slidePanel.Top = btnReporte.Top;
            formHijo(new frmReporte());
        }

    }
}
