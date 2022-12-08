using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using obras_service.Dto;
using obras_service.Models;
using obras_service.Services;
using obras_service.ShareKernel;
using System;
using System.Collections.Generic;

namespace obras_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasController : ControllerBase
    {
        private readonly IObraService obraService;

        public ObrasController(IObraService obraService)
        {
            this.obraService = obraService;
        }
        [HttpPost]
        [Route("solicitar")]
        public IActionResult Registrar([FromBody] ObrasSolicitudDto request)
        {
            Obras obras= new Obras()
            {
                Titulo = request.titulo,
                EstadoSolicitud="PENDIENTE",
                FechaSolicitud = DateTime.Now,
                Descripcion = request.descripcion                
            };
            obraService.CrearSolicitud(obras);
            
            return Ok(new Result(true, "Solicitud registrada correctamente"));
        }
        [HttpPost]
        [Route("actualizar")]
        public IActionResult Actualizar([FromBody] ObrasActualizarEstadoDto request)
        {           
           Obras obras= obraService.ActualizarSolicitud(request.IdSolicitud, request.IdSolicitudAlmacen);
            return Ok(obras);//new Result<Obras>(obras,true, "Solicitud actualizada correctamente"));
        }
        [HttpGet]
        [Route("listarSolicitudes")]
        public IActionResult ListarSolicitudes()
        {
           var solicitudes= obraService.ListarSolicitudes();
            return Ok(new Result<List<Obras>>(solicitudes,true, "Solicitudes listadas correctamente"));
        }
        [HttpGet]
        [Route("onbtenerSolicitudes")]
        public IActionResult ObtenerSolicitudes(int id)
        {
            var solicitudes = obraService.ObtenerSolicitud(id);
            return Ok(new Result<Obras>(solicitudes, true, "Solicitudes listadas correctamente"));
        }
    }
}
