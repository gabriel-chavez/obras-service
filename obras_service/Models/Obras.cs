using System;
using System.ComponentModel.DataAnnotations;

namespace obras_service.Models
{
    public class Obras
    {
        [Key]
        public int IdSolicitud { get; set; }
        public string Titulo { get; set; }
        public string EstadoSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int IdSolicitudAlmacen { get; set; }
        public string Descripcion { get; set; }
    }
}
