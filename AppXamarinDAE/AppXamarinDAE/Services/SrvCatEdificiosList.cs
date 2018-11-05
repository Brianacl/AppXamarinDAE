using System;
using System.Collections.Generic;
using System.Text;
using AppXamarinDAE.Interfaces;
using AppXamarinDAE.Data;
using AppXamarinDAE.Models;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppXamarinDAE.Interfaces.Sqlite;
using Microsoft.EntityFrameworkCore;

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
    }
}
