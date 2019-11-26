using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiModel.Api.Model
{
    public class Ticket
    {
        public int CinemaId { get; set; }
        public int Filme { get; set; }
        public int Audiencia { get; set; }
    }
}
