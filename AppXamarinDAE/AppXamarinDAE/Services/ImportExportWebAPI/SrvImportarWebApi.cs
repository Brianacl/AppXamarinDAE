using AppXamarinDAE.Data;
using AppXamarinDAE.Interfaces.ImportExportWebAPI;
using AppXamarinDAE.Interfaces.Sqlite;
using AppXamarinDAE.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
//Tengo duda de estos import
using System.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace AppXamarinDAE.Services.ImportExportWebAPI
{
    public class SrvImportarWebApi : IFicSrvImportarWebApi
    {
        private readonly DBContext LoDBContext;
        private readonly HttpClient Cliente;

        public SrvImportarWebApi()
        {
            LoDBContext = new DBContext(DependencyService.Get<IConfigSqlite>().FicGetDataBasePath());
            Cliente = new HttpClient();
            Cliente.MaxResponseContentBufferSize = 256000;
        }//CONSTRUCTOR

        private async Task<List<Eva_cat_edificios>> GetListEdificiosActualiza(int id = 0)
        {
            try
            {
                string url = "http://localhost:2643/api/edificios";
                if (id != 0) url = "http://localhost:2643/api/edificios/" + id;

                var res = await Cliente.GetAsync(url);
                System.Diagnostics.Debug.WriteLine("Petición hecha --> "+res.StatusCode);

                if (res.IsSuccessStatusCode && id != 0)
                {
                     var edificio = (Eva_cat_edificios) JsonConvert.DeserializeObject<Eva_cat_edificios>
                     (await res.Content.ReadAsStringAsync());

                    List<Eva_cat_edificios> lista = new List<Eva_cat_edificios>();
                    lista.Add(edificio);

                    return lista;
                }
                if (res.IsSuccessStatusCode)
                    return  JsonConvert
                        .DeserializeObject<List<Eva_cat_edificios>>
                        (await res.Content.ReadAsStringAsync());

                return null;

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA DEL GET", e.Message.ToString(), "OK");
                if (e.InnerException != null)
                    System.Diagnostics.Debug.WriteLine("Inner exception: {0}", e.InnerException);
                return null;
            }
        }//GET: A EDIFICIOS

        private async Task<Eva_cat_edificios> FicExistEdificio(int id)
        {
            return await (
                       from edificios in LoDBContext.eva_cat_edificios
                       where edificios.IdEdificio == id
                       select edificios
                        ).FirstOrDefaultAsync();
        }//buscar en local

        public async Task<string> FicGetImportEdificios(int id = 0)
        {
            string mensaje = "";
            try
            {
                mensaje = "IMPORTACION: \n";
                List<Eva_cat_edificios> GetResultREST;

                if (id != 0) GetResultREST = await GetListEdificiosActualiza(id);
                else GetResultREST = await GetListEdificiosActualiza();

                if (GetResultREST != null)
                {
                    mensaje += "IMPORTANDO: Eva_cat_edificios \n";
                    foreach (Eva_cat_edificios edificios in GetResultREST)
                    {
                        var respuesta = await FicExistEdificio(edificios.IdEdificio);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.IdEdificio = edificios.IdEdificio;
                                respuesta.Alias = edificios.Alias;
                                respuesta.DesEdificio = edificios.DesEdificio;
                                respuesta.Prioridad = edificios.Prioridad;
                                respuesta.Clave = edificios.Clave;
                                respuesta.FechaReg = edificios.FechaReg;
                                respuesta.FechaUltMod = edificios.FechaUltMod;
                                respuesta.UsuarioReg = edificios.UsuarioReg;
                                respuesta.UsuarioMod = edificios.UsuarioMod;
                                respuesta.Activo = edificios.Activo;
                                respuesta.Borrado = edificios.Borrado;
                                // FicLoBDContext.Update(respuesta);

                                mensaje += await LoDBContext.SaveChangesAsync() > 0 ? "UPDATE-> IdInventario: " + edificios.IdEdificio + " \n" : "-NO NECESITO ACTUALIZAR->  IdEdificio: " + edificios.IdEdificio + " \n";
                            }
                            catch (Exception e)
                            {
                                mensaje += "ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                LoDBContext.Add(edificios);
                                mensaje += await LoDBContext.SaveChangesAsync() > 0 ? "-INSERT-> IdEdificio: " + edificios.IdEdificio + " \n" : "-ERROR EN INSERT-> IdEdificio: " + edificios.IdEdificio + " \n";
                            }
                            catch (Exception e)
                            {
                                mensaje += "-ALERTA-> " + e.Message.ToString() + " \n";
                            }
                        }
                    }
                }
                else mensaje += "-> SIN DATOS. \n";
            }
            catch (Exception e)
            {
                mensaje += "ALERTA: " + e.Message.ToString() + "\n";
            }

            return mensaje;
        }//get import edificios
    }
}
