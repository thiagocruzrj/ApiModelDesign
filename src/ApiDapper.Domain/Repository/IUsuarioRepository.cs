﻿using ApiDapper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDapper.Domain.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> FindAll();
        int Add(Usuario item);
        void Remove(int id);
        void Update(Usuario item);
        Usuario FindByID(int id);
        IEnumerable<Usuario> GetAll();
        bool ExistsID(int id);
    }
}
