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

        private void frmPopupDoctor_Load(object sender, EventArgs e)
        {
            if (IidDoctor==0)
            {
                this.Text = "Agregando Doctor";
            }else
            {
                this.Text = "Editando Doctor";
            }
        }
    }
}
