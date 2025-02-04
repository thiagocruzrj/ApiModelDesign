﻿using System;
using System.Linq;
using ApiDapper.Domain.Entities;
using ApiDapper.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiDapper.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository UsuarioRepository;

        public UsuarioController(IUsuarioRepository UsuarioRepository)
        {
            this.UsuarioRepository = UsuarioRepository;
        }

        // GET: api/Usuario
        [HttpGet]
        public IActionResult Get()
        {
            var Usuario = UsuarioRepository.GetAll();

            if (Usuario.Count() == 0) return NoContent();

            return Ok(Usuario);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var usuario = UsuarioRepository.FindByID(id);

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Usuario Usuario)
        {
            ConvertDataMySQL(Usuario);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id < 1) return BadRequest();

            var usuario = UsuarioRepository.FindByID(id);
            if (usuario == null) return NotFound();

            Usuario.Id = usuario.Id;

            try
            {
                UsuarioRepository.Update(Usuario);
                return Ok(Usuario);
            }
            catch (Exception ex)
            {
                string.Format("Erro Update/Put no cliente Nº {0}, erro Exception{1}", Usuario.Id, ex);
            }
            return NoContent();
        }

        // POST: api/Usuario
        [HttpPost]
        public IActionResult Post([FromBody] Usuario Usuario)
        {
            ConvertDataMySQL(Usuario);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                Usuario.Id = UsuarioRepository.Add(Usuario);
            }
            catch (Exception ex)
            {
                string.Format("Erro Post/Adicionar cliente Nº {0}, erro Exception{1}", Usuario.Id, ex);
                return NotFound();
            }
            return CreatedAtAction("Get", new { id = Usuario.Id }, Usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var usuario = UsuarioRepository.FindByID(id);
            if (usuario == null) return NotFound();
            try
            {
                UsuarioRepository.Remove(id);
            }
            catch (Exception ex)
            {
                string.Format("Erro Delete cliente Nº {0}, erro Exception{1}", usuario.Id, ex);
            }
            return Ok(usuario);
        }

        private static void ConvertDataMySQL(Usuario Usuario)
        {
            Usuario.DataNascimento = DateTime.Parse(Usuario.DataNascimento.ToString()).ToString("yyyy-MM-dd");
        }
    }
}