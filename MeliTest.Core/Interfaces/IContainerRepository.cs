using MeliTest.Core.Entities;
using MeliTest.Core.DTOs;

namespace MeliTest.Core.Interface
{
    public interface IContainerRepository
    {
        Task<IEnumerable<TbContenedores>> GetAll();
        Task<IEnumerable<TbContenedores>> GetStats();
        Task<bool> Insert(TbContenedores contenedores);
    }
}