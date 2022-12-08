using obras_service.Models;
using System.Collections.Generic;

namespace obras_service.Services
{
    public interface IObraService
    {

        Obras CrearSolicitud(Obras obras);
        List<Obras> ListarSolicitudes();
        Obras ObtenerSolicitud(int id);
        Obras ActualizarSolicitud(int id, int idSolicitudAlmacen);

        Obras Revertir(int id);
    }
}
