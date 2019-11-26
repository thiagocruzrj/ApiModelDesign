using ApiModel.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiModel.Api.Services
{
    public interface ICinemaService
    {
        Task Add(Cinema model);
        Task<IEnumerable<Cinema>> GetCinemas();
        Task<Cinema> GetById(int cinemaId);
    }
}
