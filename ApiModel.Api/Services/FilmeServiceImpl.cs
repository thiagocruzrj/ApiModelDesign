using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiModel.Api.Model;

namespace ApiModel.Api.Services
{
    public class FilmeServiceImpl : IFilmeService
    {
        public async Task Add(Filme model)
        {
            using (var ctx = new Data.DbContext())
            {
                await ctx.MovieCollection.Add(model);
            }
        }

        public async Task Delete(int id)
        {
            using (var ctx = new Data.DbContext())
            {
                await ctx.MovieCollection.Delete(id);
            }
        }

        public async Task<IEnumerable<Filme>> GetByCinema(int cinemaId)
        {
            using (var ctx = new Data.DbContext())
            {
                return await ctx.MovieCollection.GetMoviesByCinemaId(cinemaId);
            }
        }

        public async Task<Filme> GetById(int id)
        {
            using (var ctx = new Data.DbContext())
            {
                return await ctx.MovieCollection.GetById(id);
            }
        }

        public async Task Patch(Filme movie)
        {
            using (var ctx = new Data.DbContext())
            {
                await ctx.MovieCollection.Patch(movie);
            }
        }

        public async Task Update(Filme movie)
        {
            using (var ctx = new Data.DbContext())
            {
                await ctx.MovieCollection.Update(movie);
            }
        }
    }
}
