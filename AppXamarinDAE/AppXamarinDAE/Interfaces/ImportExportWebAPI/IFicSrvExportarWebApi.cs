using AppXamarinDAE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppXamarinDAE.Interfaces.ImportExportWebAPI
{
    public interface IFicSrvExportarWebApi
    {
        Task<string> PostExportEdificios();
    }
}
