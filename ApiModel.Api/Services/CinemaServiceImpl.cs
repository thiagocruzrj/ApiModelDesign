using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiModel.Api.Model;

namespace ApiModel.Api.Services
{
    public class CinemaServiceImpl : ICinemaService
    {
        public Task Add(Cinema model)
        {
            return Task.CompletedTask;
        }

        public async Task<Cinema> GetById(int cinemaId)
        {
            using (var ctx = new Data.DbContext())
            {
                return await ctx.CinemaCollection.GetById(cinemaId);
            }
        }

        public async Task<IEnumerable<Cinema>> GetCinemas()
        {
            using (var ctx = new Data.DbContext())
            {
                return await ctx.CinemaCollection.GetAll();
            }
        }
    }
}
