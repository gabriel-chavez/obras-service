using obras_service.Models;
using obras_service.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace obras_service.Services
{
    public class ObraService : IObraService
    {
        private readonly ContextDatabase _contextDatabase;

        public ObraService(ContextDatabase contextDatabase)
        {
            this._contextDatabase = contextDatabase;
        }

        public Obras ActualizarSolicitud(int id, int idSolicitudAlmacen)
        {
            var obras = _contextDatabase.Obras.Where(x => x.IdSolicitud == id).FirstOrDefault();
            obras.EstadoSolicitud = "ENTREGADO";
            obras.IdSolicitudAlmacen= idSolicitudAlmacen;            
            _contextDatabase.Obras.Update(obras);
            _contextDatabase.SaveChanges();
            return obras;
        }
     

        public int CrearSolicitud(Obras obras)
        {
            _contextDatabase.Obras.Add(obras);
            _contextDatabase.SaveChanges();
            return obras.IdSolicitud;
        }

        public List<Obras> ListarSolicitudes()
        {
            return _contextDatabase.Obras.ToList();
        }

        public Obras ObtenerSolicitud(int id)
        {
            return _contextDatabase.Obras.Where(x => x.IdSolicitud == id).FirstOrDefault();
        }
    }
}
