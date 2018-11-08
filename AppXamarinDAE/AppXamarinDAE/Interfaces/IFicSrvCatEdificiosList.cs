using AppXamarinDAE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppXamarinDAE.Interfaces
{
    public interface IFicSrvCatEdificiosList
    {
        Task<IEnumerable<Eva_cat_edificios>> FicMetGetListEdificios();
        Task FicMetInsertNewEdificio(Eva_cat_edificios FicPaEva_cat_edificio);
        Task FicMetDeleteEdificio(Eva_cat_edificios FicPaEva_cat_edificio);
        //Aquí va el método para consultar detalle
        //Todos los metodos de la view :v
    }
}