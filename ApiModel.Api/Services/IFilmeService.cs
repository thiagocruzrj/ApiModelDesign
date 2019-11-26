using ApiModel.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiModel.Api.Services
{
    public interface IFilmeService
    {
        Task Add(Filme model);
        Task<IEnumerable<Filme>> GetByCinema(int cinemaId);
        Task<Filme> GetById(int id);
        Task Update(Filme movie);
        Task Patch(Filme movie);
        Task Delete(int id);
    }
}
