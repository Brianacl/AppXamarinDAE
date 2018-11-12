using System.Threading.Tasks;

namespace AppXamarinDAE.Interfaces.ImportExportWebAPI
{
    public interface IFicSrvImportarWebApi
    {
        Task<string> FicGetImportEdificios(int id = 0);
        //Task<string> FicGetImportCatalogos();
    }
}
