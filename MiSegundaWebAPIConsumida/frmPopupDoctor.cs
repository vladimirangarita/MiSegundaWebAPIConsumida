using MiSegundaWebAPIConsumida.CapaDatos;
using MiSegundaWebAPIConsumida.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiSegundaWebAPIConsumida
{
   
    public partial class frmPopupDoctor : Form
    {
        DoctorCLS oDoctorCLS;
        public int IidDoctor { get; set; }
        public frmPopupDoctor()
        {
            InitializeComponent();
        }
        string nombreArchivo;
        private void txtApPaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {

        }
     

        private async void frmPopupDoctor_Load(object sender, EventArgs e)
        {
          

            if (IidDoctor==0)
            {
                RbMascu.Checked = true;
                this.Text = "Agregando Doctor";
            }else
            {
                this.Text = "Editando Doctor";
                DoctorDAL oDoctorDAL = new DoctorDAL();
                 oDoctorCLS = await oDoctorDAL.RecuperarDoctor(IidDoctor);
                txtIdDoctor.Text = oDoctorCLS.iidDoctor.ToString();
                txtNombre.Text = oDoctorCLS.Nombre;
                txtApPaterno.Text = oDoctorCLS.ApPaterno;
                txtApMaterno.Text = oDoctorCLS.ApMaterno;
                txtEmail.Text = oDoctorCLS.Email;
                dtpFechaContrato.Value = oDoctorCLS.FechaContrato;
                //cboEspecialidad.SelectedValue = oDoctorCLS.iidEspecialidad;
                //cboClinica.SelectedValue = oDoctorCLS.iidClinica;
                txtSueldo.Text =  oDoctorCLS.Sueldo.ToString();
                txtTelefonoCelular.Text = oDoctorCLS.TelefonoCelular==null ? "" : oDoctorCLS.TelefonoCelular.ToString();
                if (oDoctorCLS.iidSexo==1)
                {
                    RbMascu.Checked = true;
                }
                else
                {
                    RbFeme.Checked = true;
                }
                //txtIdDoctor.Text = oDoctorCLS.iidDoctor;
                string foto = oDoctorCLS.archivo;
                nombreArchivo = oDoctorCLS.NombreArchivo;

                if (foto!=null && foto != "")
                {


                    //var data = this.dgvArticulos.Item(2, this.dgvArticulos.SelectedCells.Item(0).RowIndex).Value as byte[];
                    //var stream = new MemoryStream(data);
                    //PictureBox1.Image = Image.FromStream(stream);

                    //var data = oDoctorCLS.archivo;
                    //byte[] fotoArray2 = Convert.FromBase64String(data);
                    //var strem = new MemoryStream(Convert.FromBase64String(fotoArray2));
                    //pbFoto.Image = Image.FromStream(strem);

                    string extension = Path.GetExtension(nombreArchivo).Substring(1);
                    foto = foto.Replace("data:image/" + extension + ";base64,", "")+"=";

                    

                    byte[] fotoArray = Convert.FromBase64String(foto);

                    //byte[] fotoArray = ImageToByteArray(pbFoto.Image);

                    using (MemoryStream ms=new MemoryStream(fotoArray))
                    {
                        pbFoto.Image = Image.FromStream(ms);
                    }
                }

            }

            

            await Task.Run(() =>

            {
                LlenarCombo();
            });
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
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

                if (IidDoctor != 0)
                {

                    cboClinica.DataSource = ListaClinica;
                    cboClinica.DisplayMember = "NombreClinica";
                    cboClinica.ValueMember = "iidClinica";
                    cboClinica.SelectedValue = oDoctorCLS.iidClinica;
                }
                    if (IidDoctor!=0)
                {

             
                cboEspecialidad.DataSource = ListaEspecialidad;
                cboEspecialidad.DisplayMember = "nombreEspecialidad";
                cboEspecialidad.ValueMember = "iiEspecialidad";
                cboEspecialidad.SelectedValue = oDoctorCLS.iidEspecialidad;
                }
            }));

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivo de image | *.jpg;*.png";
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                nombreArchivo = Path.GetFileName(ofd.FileName);
                byte[] buffer = File.ReadAllBytes(ofd.FileName);

                using (MemoryStream ms=new MemoryStream(buffer))
                {
                    pbFoto.Image = Image.FromStream(ms);
                }

            }
        }
    }
}
