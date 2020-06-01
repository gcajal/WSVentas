using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVentas.Models;
using WSVentas.Models.Response;
using WSVentas.Models.Request;

namespace WSVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    var lst = db.Cliente.OrderByDescending(d => d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
;                    //return Ok(lst);
                }
            }
            catch(Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
            
        }
        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.Nombre;
                    db.Add(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
                    
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Update(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Cliente.Find(oModel.Id);
                    oCliente.Nombre = oModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }



        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Cliente.Find(Id);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
    }
}