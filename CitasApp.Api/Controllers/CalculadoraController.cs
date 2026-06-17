using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("sumar")]
        public IActionResult Sumar(int a, int b)
        {
            return Ok(new { operacion = "suma", a, b, resultado = a + b });
        }

        [HttpGet("restar")]
        public IActionResult Restar(int a, int b)
        {
            return Ok(new { operacion = "resta", a, b, resultado = a - b });
        }

        [HttpGet("multiplicar")]
        public IActionResult Multiplicar(int a, int b)
        {
            return Ok(new { operacion = "multiplicacion", a, b, resultado = a * b });
        }

        [HttpGet("dividir")]
        public IActionResult Dividir(int a, int b)
        {
            if (b == 0)
                return BadRequest("No se puede dividir entre 0");

            return Ok(new { operacion = "division", a, b, resultado = (double)a / b });
        }
    }
}