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
            string url = "http://192.168.250.10:8081/api/Doctor";
            HttpResponseMessage Response = await Cliente.GetAsync(url);
            List<DoctorCLS> ListaDoctor = new List<DoctorCLS>();
            if (Response!=null)
            {
                rpta = await Response.Content.ReadAsStringAsync();
                ListaDoctor = JsonConvert.DeserializeObject<List<DoctorCLS>>(rpta);
            }
            return ListaDoctor;
        } 




    }
}
