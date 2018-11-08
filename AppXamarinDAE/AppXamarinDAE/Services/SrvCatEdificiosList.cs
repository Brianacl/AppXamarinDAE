using System;
using System.Collections.Generic;
using AppXamarinDAE.Interfaces;
using AppXamarinDAE.Data;
using AppXamarinDAE.Models;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppXamarinDAE.Interfaces.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppXamarinDAE.Services
{
    public class SrvCatEdificiosList : IFicSrvCatEdificiosList
    {
        private readonly DBContext LoDBContext;
        

        public SrvCatEdificiosList()
        {
            LoDBContext = new DBContext(DependencyService.Get<IConfigSqlite>().FicGetDataBasePath());
        }

        public async Task<IEnumerable<Eva_cat_edificios>> FicMetGetListEdificios()
        {
            return await (from eva_cat_edificios in LoDBContext.eva_cat_edificios select eva_cat_edificios).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewEdificio(Eva_cat_edificios FicMetInsertEdificio)
        {
            try
            {   
                var FicSourceEdificioExist = await (
                       from edificios in LoDBContext.eva_cat_edificios
                       where edificios.IdEdificio ==  FicMetInsertEdificio.IdEdificio
                       select edificios
                        ).FirstOrDefaultAsync();

                if (FicSourceEdificioExist == null)
                {
                    await LoDBContext.AddAsync(FicMetInsertEdificio);

                }
                else
                {
                    FicMetInsertEdificio.IdEdificio = FicSourceEdificioExist.IdEdificio;
                    LoDBContext.Update(FicMetInsertEdificio);
                }

                await LoDBContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo

        public async Task FicMetDeleteEdificio(Eva_cat_edificios deleteEdificio)
        {
                using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
                {
                    try
                    {
                    if (await ExistEdificio(deleteEdificio))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO

                        LoDBContext.Remove(deleteEdificio);
                        await LoDBContext.SaveChangesAsync();

                        transaction.Commit(); //CONFIRMA/GUARDA
                        return;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        await new Page().DisplayAlert("ALERTA", ex.Message.ToString(), "OK");
                }
                }//ENTRA EN CONTEXTO DE TRANSACIONES
        }

        private async Task<bool> ExistEdificio(Eva_cat_edificios existEdificio)
        {
            return await (from edificio in LoDBContext.eva_cat_edificios
                          where edificio.IdEdificio == existEdificio.IdEdificio
                          select edificio).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO
    }
}
