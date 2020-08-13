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
    public partial class frmEditar : Form
    {
        Modelo.dsCRUDEmpleadosTableAdapters.EmpleadosTableAdapter ta =
         new Modelo.dsCRUDEmpleadosTableAdapters.EmpleadosTableAdapter();

        public frmEditar()
        {
            InitializeComponent();
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

        private string ObtenerCarnet()
        {
            try
            {
                return dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();

            }
            catch
            {
                return null;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? carnet = Convert.ToInt32(ObtenerCarnet()); 

            if (carnet != null)
            {
                dsCRUDEmpleados.EmpleadosDataTable dt = ta.GetDataByCarnet(Convert.ToInt32(ObtenerCarnet()));
                dsCRUDEmpleados.EmpleadosRow row = (dsCRUDEmpleados.EmpleadosRow) dt.Rows[0];

                txtNombre.Text = row.nombre;
                mtxtCarnet.Text = row.carnet.ToString();
                txtAñosLaborados.Text = row.añosLaborados.ToString();
                txtSalario.Text = row.salario.ToString();
                chkEstado.Checked = row.estado;

            }
        
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           

            int? carnet = General.ReemplazarMascara(ObtenerCarnet());


            if (carnet != null)
            {
                ta.UpdateEmpleado(txtNombre.Text.Trim(), Convert.ToDecimal(txtSalario.Text.Trim()), 
                    Convert.ToInt32(txtAñosLaborados.Text.Trim()), chkEstado.Checked, 
                        General.ReemplazarMascara(mtxtCarnet.Text));

            }

            CargarDatos();
            LimpiarCampos();
        }
    }
}
