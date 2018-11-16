using AppXamarinDAE.Data;
using AppXamarinDAE.Interfaces.ImportExportWebAPI;
using AppXamarinDAE.Interfaces.Sqlite;
using AppXamarinDAE.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
//Tengo dudas sobre estos using
using System.Linq;
using System.Collections.Generic;

namespace AppXamarinDAE.Services.ImportExportWebAPI
{
    public class SrvExportarWebApi : IFicSrvExportarWebApi
    {
        private readonly DBContext LoDBContext;
        private readonly HttpClient Cliente;

        public SrvExportarWebApi()
        {
            LoDBContext = new DBContext(DependencyService.Get<IConfigSqlite>().FicGetDataBasePath());
            Cliente = new HttpClient();
            Cliente.MaxResponseContentBufferSize = 256000;
        }//Constructor

        private async Task<string> PostListEdificios(List<Eva_cat_edificios> postEdificio)
        {
            string url = "http://localhost:2643/api/edificios/";
            int contar = 0;
            try
            {
                foreach (var edificio in postEdificio)
                {
                    var json = JsonConvert.SerializeObject(edificio);

                    if (contar > 0)
                    {
                        url = url.Substring(0, url.Length - 1);
                    }
                    url += edificio.IdEdificio;

                    //json = json.Substring(1, json.Length - 2);

                    System.Diagnostics.Debug.WriteLine(json);
                    System.Diagnostics.Debug.WriteLine(url);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await Cliente.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine(@"                Edificios successfully saved.");
                    }
                    else
                        System.Diagnostics.Debug.WriteLine("Estatus --> " + response.StatusCode);

                    contar++;
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA DEL POST", e.Message.ToString(), "OK");
                if (e.InnerException != null)
                    System.Diagnostics.Debug.WriteLine("Inner exception: {0}", e.InnerException);
                return null;
            }
            /*HttpResponseMessage respuesta = await Cliente.PostAsync(
                new Uri(string.Format(url, string.Empty)),
                new StringContent(JsonConvert.SerializeObject(postEdificio), 
                Encoding.UTF8, "application/json"));*/

            return "Ok";
        }//POST a edificios

        public async Task<string> PostExportEdificios()
        {
            try
            {
                return await PostListEdificios(
                    await (from a in LoDBContext.eva_cat_edificios select a)
                    .AsNoTracking()
                    .ToListAsync());
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA DEL POST", e.Message.ToString(), "OK");
                if (e.InnerException != null)
                    System.Diagnostics.Debug.WriteLine("Inner exception: {0}", e.InnerException);
                return null;
            }

            //return await LoDBContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL REGISTRAR";
        }//METODO DE EXPORT INVENTARIOS

    }//Fin clase
}
