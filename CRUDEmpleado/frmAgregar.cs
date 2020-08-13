using CRUDEmpleado.Modelo;
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
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            //Conexíon a BD
            Modelo.dsCRUDEmpleadosTableAdapters.EmpleadosTableAdapter ta = 
                new Modelo.dsCRUDEmpleadosTableAdapters.EmpleadosTableAdapter();

            // Obtener Datos
            dsCRUDEmpleados.EmpleadosDataTable dt = ta.GetData();

            dataGridView1.DataSource = dt;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            mtxtCarnet.Text = string.Empty;
            txtSalario.Text = string.Empty;
            txtAñosLaborados.Text = string.Empty;
            chkEstado.Checked = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Modelo.dsCRUDEmpleadosTableAdapters.EmpleadosTableAdapter ta =
              new Modelo.dsCRUDEmpleadosTableAdapters.EmpleadosTableAdapter();

            ta.InsertEmpleado(txtNombre.Text.Trim(), Reemplazar.ReemplazarMascara(mtxtCarnet.Text.Trim()),
                Convert.ToDecimal(txtSalario.Text.Trim()), Convert.ToInt32(txtAñosLaborados.Text.Trim()), chkEstado.Checked);

            CargarDatos();
            LimpiarCampos();

        }
    }
}
