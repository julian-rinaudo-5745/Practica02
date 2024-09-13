using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practica02.DTOs;
using Practica02.Interfaces;
using Practica02.Models;
using Practica02.Repository;

namespace Practica02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private IAplicacion articuloRepository;
        public ArticulosController()
        {
            articuloRepository = new ArticuloRepository();
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {
                List<Articulo> articulos = articuloRepository.ObtenerTodos();

                return Ok(articulos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error inesperado al obtener todos los articulos. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Agregar([FromBody] CrearArticuloDto articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                articuloRepository.Agregar(articulo);

                return Ok("Articulo agregado exitosamente");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error inesperado al crea un articulo. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Editar([FromBody] EditarArticuloDto articulo, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Articulo articuloAEditar = articuloRepository.ObtenerPorId(id);


                if (articuloAEditar.Id == 0)
                {
                    return NotFound("El articulo a editar no existe");
                }

                articuloRepository.Editar(id, articulo);

                return Ok("Articulo editado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error inesperado al editar un articulo. Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar([FromRoute] int id)
        {
            if (id < 1)
            {
                return BadRequest("Se requiere el id del articulo");
            }
            try
            {
                Articulo articuloAEliminar = articuloRepository.ObtenerPorId(id);

                if (articuloAEliminar.Id == 0)
                {
                    return NotFound("El articulo a eliminar no existe");
                }

                articuloRepository.Eliminar(id);

                return Ok("Articulo eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error inesperado al eliminar un articulo. Error: {ex.Message}");
            }
        }

    }
}