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
            string url = "http://192.168.0.102:8081/api/Doctor";
            HttpResponseMessage Response = await Cliente.GetAsync(url);
            List<DoctorCLS> ListaDoctor = new List<DoctorCLS>();
            if (Response != null)
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
            string url = "http://192.168.0.102:8081/api/Especialidad";
            HttpResponseMessage Response = await Cliente.GetAsync(url);
            List<EspecialidadCLS> ListaEspecialidad = new List<EspecialidadCLS>();
            if (Response != null)
            {
                rpta = await Response.Content.ReadAsStringAsync();
                ListaEspecialidad = JsonConvert.DeserializeObject<List<EspecialidadCLS>>(rpta);
            }

            return ListaEspecialidad;
        }

        public async Task<int> EliminarDoctor(int iidDoctor)
        {
            int rpta = 0;
            HttpClient Cliente = new HttpClient();
            string url = "http://192.168.0.102:8081/api/Doctor/?iidDoctor=" + iidDoctor;
            DoctorCLS oDoctor = new DoctorCLS
            {
                iidDoctor = iidDoctor
            };

            var jsonRequest = JsonConvert.SerializeObject(oDoctor);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
          HttpResponseMessage response = await  Cliente.PutAsync(url, content);

            if (response !=null)
            {
            string rptaCadena =    await response.Content.ReadAsStringAsync();
                rpta = int.Parse(rptaCadena);
            }


            return rpta;
        }

        public async Task<DoctorCLS> RecuperarDoctor(int iidDoctor)
        {
            string rpta = "";
            HttpClient Cliente = new HttpClient();
            string url = "http://192.168.0.102:8081/api/Doctor/?iidDoctor=" + iidDoctor;
            HttpResponseMessage respon = await Cliente.GetAsync(url);
            DoctorCLS oDoctorCLS = new DoctorCLS();
            if (respon !=null)
            {
               rpta= await respon.Content.ReadAsStringAsync();
              oDoctorCLS =  JsonConvert.DeserializeObject<DoctorCLS>(rpta);

            }

            return oDoctorCLS;
        }
            public async Task<List<ClinicaCLS>> ListarClinica()
        {
            string rpta = "";
            HttpClient Cliente = new HttpClient();
            string url = "http://192.168.0.102:8081/api/Clinica";
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
