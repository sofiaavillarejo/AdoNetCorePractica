using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNetCorePractica.Models;
using AdoNetCorePractica.Repositories;

namespace AdoNetCorePractica
{
    public partial class FormPractica : Form
    {
        private RepositoryPractica repo;
        public FormPractica()
        {
            InitializeComponent();
            this.repo = new RepositoryPractica();
            this.LoadHospitales();
        }
        private async Task LoadHospitales()
        {
            List<string> hospitales = await this.repo.GetHospitalesAsync();
            this.cmbHospitales.Items.Clear();
            foreach (string nombre in hospitales)
            {
                this.cmbHospitales.Items.Add(nombre);
            }
        }

        private async void cmbHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreHosp = this.cmbHospitales.SelectedItem.ToString();
            EmpleadosHospital empleados = await this.repo.MostrarEmpleadosAsync(nombreHosp);
            this.lstEmpleados.Items.Clear();
            foreach (string datos in empleados.DatosEmpleados)
            {
                this.lstEmpleados.Items.Add(datos);
            }
            this.txtSuma.Text = empleados.SumaSalarial.ToString();
            this.txtMedia.Text = empleados.MediaSalarial.ToString();
            this.txtPersonas.Text = empleados.Personas.ToString();
        }
    }
}
