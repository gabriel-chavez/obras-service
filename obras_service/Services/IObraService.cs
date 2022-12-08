using obras_service.Models;
using System.Collections.Generic;

namespace obras_service.Services
{
    public interface IObraService
    {
        int CrearSolicitud(Obras obras);
        List<Obras> ListarSolicitudes();
        Obras ObtenerSolicitud(int id);
        bool ActualizarSolicitud(int id, int idSolicitudAlmacen);
    }
}
