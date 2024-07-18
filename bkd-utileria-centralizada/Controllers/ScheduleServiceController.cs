using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bkd_utileria_centralizada.Models;

namespace bkd_utileria_centralizada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleServiceController : ControllerBase
    {
        public readonly utileriadbContext _utileriadbContext;

        public ScheduleServiceController(utileriadbContext _utileriadbContex)
        {
            this._utileriadbContext = _utileriadbContex;
        }


        [HttpGet]
        [Route("lista")]
        public IActionResult GetLista()
        {
            List<CatCountry> lista = new List<CatCountry>();
            try {
                lista =  _utileriadbContext.CatCountries.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje= "OK", response = lista});
            
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message.ToString(), response = lista });
            }
        }
        [HttpGet]
        [Route("menu")]
        public IActionResult GetMenu()
        {
            List<MenuUtileriaCentralizacion> lista = new List<MenuUtileriaCentralizacion>();
            try
            {
                lista = _utileriadbContext.MenuUtileriaCentralizacions.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message.ToString(), response = lista });
            }
        }

        [HttpPost]
        [Route("menu")]
        public IActionResult saveMenu([FromBody] MenuUtileriaCentralizacion oMenu)
        {
            
            try
            {
                _utileriadbContext.Add(oMenu);
                _utileriadbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", response = oMenu });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message.ToString() });
            }
        }






    }
}
