using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practica02.DTOs;
using Practica02.Models;

namespace Practica02.Interfaces
{
    public interface IAplicacion
    {
        List<Articulo> ObtenerTodos();
        Articulo ObtenerPorId(int id);
        void Agregar(CrearArticuloDto articulo);
        void Editar(int id, EditarArticuloDto articulo);
        void Eliminar(int id);
    }
}