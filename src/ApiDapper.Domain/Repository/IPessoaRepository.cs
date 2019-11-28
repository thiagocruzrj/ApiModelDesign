using ApiDapper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDapper.Domain.Repository
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> GetAll();
    }
}
