using MiSegundaWebAPIConsumida.CapaDatos;
using MiSegundaWebAPIConsumida.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiSegundaWebAPIConsumida
{
    public partial class frmPopupDoctor : Form
    {
        public int IidDoctor { get; set; }
        public frmPopupDoctor()
        {
            InitializeComponent();
        }

        private void txtApPaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {

        }

        private async void frmPopupDoctor_Load(object sender, EventArgs e)
        {
            RbMascu.Checked = true;

            await Task.Run(() =>

            {
                LlenarCombo();
            });

            if (IidDoctor==0)
            {
                this.Text = "Agregando Doctor";
            }else
            {
                this.Text = "Editando Doctor";
            }
        }

        private async void LlenarCombo()
        {
            DoctorDAL oDoctorDAL = new DoctorDAL();

            List<ClinicaCLS> ListaClinica = await oDoctorDAL.ListarClinica();
            List<EspecialidadCLS> ListaEspecialidad = await oDoctorDAL.ListarEspecialidad();
            ListaClinica.Insert(0, new ClinicaCLS { iidClinica = 0, NombreClinica = "--Seleccionar" });
            ListaEspecialidad.Insert(0, new EspecialidadCLS { iiEspecialidad = 0, nombreEspecialidad = "-Seleccionar" });

            this.Invoke(new MethodInvoker(() =>
            {
                cboClinica.DataSource = ListaClinica;
                cboClinica.DisplayMember = "NombreClinica";
                cboClinica.ValueMember = "iidClinica";


                cboEspecialidad.DataSource = ListaEspecialidad;
                cboEspecialidad.DisplayMember = "nombreEspecialidad";
                cboEspecialidad.ValueMember = "iiEspecialidad";

            }));

        }
    }
}
