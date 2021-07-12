using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiSegundaWebAPIConsumida.CapaDatos;
using MiSegundaWebAPIConsumida.Clases;

namespace MiSegundaWebAPIConsumida
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public async void ListarDoctor()
        {
            DoctorDAL oDoctorDAL = new DoctorDAL();
          List<DoctorCLS> ListaDoctor = await oDoctorDAL.ListarDoctor();
            dgvDoctor.DataSource = ListaDoctor;

            for (int i = 6; i < dgvDoctor.Columns.Count; i++)
            {
                dgvDoctor.Columns[i].Visible = false;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListarDoctor();
        }
    }
}
