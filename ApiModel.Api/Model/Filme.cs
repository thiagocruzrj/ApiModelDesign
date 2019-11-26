using System;

namespace ApiModel.Api.Model
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CinemaId { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
