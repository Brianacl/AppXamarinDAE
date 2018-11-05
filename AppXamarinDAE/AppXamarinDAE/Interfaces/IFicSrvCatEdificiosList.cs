using AppXamarinDAE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppXamarinDAE.Interfaces
{
    public interface IFicSrvCatEdificiosList
    {
        Task<IEnumerable<Eva_cat_edificios>> FicMetGetListEdificios();
        //Aquí va el método para insertar edificio
        //Aquí va el método para consultar detalle
        //Todos los metodos de la view :v
    }
}