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
    
    public partial class frmEliminar : Form
    {
        Modelo.dsCRUDEmpleadosTableAdapters.EmpleadosTableAdapter ta =
         new Modelo.dsCRUDEmpleadosTableAdapters.EmpleadosTableAdapter();

        private int carnet; 
        public frmEliminar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { 
            dsCRUDEmpleados.EmpleadosDataTable dt = ta.GetDataByCarnet(General.ReemplazarMascara(mxtCarnet.Text));
            dataGridView1.DataSource = dt;

            dsCRUDEmpleados.EmpleadosRow row = (dsCRUDEmpleados.EmpleadosRow)dt.Rows[0];

            carnet = row.carnet;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ta.DeleteEmpleado(carnet);
        }

    }
}
