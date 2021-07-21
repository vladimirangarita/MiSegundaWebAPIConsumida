using MiSegundaWebAPIConsumida.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MiSegundaWebAPIConsumida.CapaDatos
{
   public class DoctorDAL
    {

        public async Task<List<DoctorCLS>> ListarDoctor()

        {
            string rpta = "";
            HttpClient Cliente = new HttpClient();
            string url = "http://192.168.0.104:8081/api/Doctor";
            HttpResponseMessage Response = await Cliente.GetAsync(url);
            List<DoctorCLS> ListaDoctor = new List<DoctorCLS>();
            if (Response!=null)
            {
                rpta = await Response.Content.ReadAsStringAsync();
                ListaDoctor = JsonConvert.DeserializeObject<List<DoctorCLS>>(rpta);
            }
            return ListaDoctor;
        } 

        public async Task<List<EspecialidadCLS>> ListarEspecialidad()
        {
            string rpta = "";
            HttpClient Cliente = new HttpClient();
            string url = "http://192.168.0.104:8081/api/Especialidad";
            HttpResponseMessage Response = await Cliente.GetAsync(url);
            List<EspecialidadCLS> ListaEspecialidad = new List<EspecialidadCLS>();
            if (Response != null)
            {
                rpta = await Response.Content.ReadAsStringAsync();
                ListaEspecialidad = JsonConvert.DeserializeObject<List<EspecialidadCLS>>(rpta);
            }

            return ListaEspecialidad;
        }

        public async Task<List<ClinicaCLS>> ListarClinica()
        {
            string rpta = "";
            HttpClient Cliente = new HttpClient();
            string url = "http://192.168.0.104:8081/api/Clinica";
            HttpResponseMessage Response = await Cliente.GetAsync(url);
            List<ClinicaCLS> ListaClinica = new List<ClinicaCLS>();
            if (Response != null)
            {
                rpta = await Response.Content.ReadAsStringAsync();
                ListaClinica = JsonConvert.DeserializeObject<List<ClinicaCLS>>(rpta);
            }

            return ListaClinica;
        }
    }
}
