using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_BackEnd.Models;

namespace Prueba_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly BdPruebaContext _context;

        public PacienteController(BdPruebaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //Thread.Sleep(2000); 
                var listPacientes = await _context.Pacientes.Include(p => p.Provincia).ToListAsync();
                return Ok(listPacientes);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetById(int id)
        {
            try
            {
                var paciente = await _context.Pacientes.FindAsync(id);
                var provincia = await _context.Provincias.FindAsync(paciente.ProvinciaId);
                paciente.Provincia = provincia;
                return Ok(paciente);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var paciente = await _context.Pacientes.FindAsync(id);
                if (paciente == null)
                {
                    return NotFound();
                }
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Paciente paciente)
        {
            try
            {
                paciente.FechaCreacion = DateTime.Now;
                //paciente.FechaNacimiento = DateTime.Now;

                var provincia = await _context.Provincias.FindAsync(paciente.Provincia.ProvinciaId);

                if (provincia == null)
                {
                    return BadRequest("Provincia no encontrada");
                }

                paciente.Provincia = provincia;

                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = paciente.CedulaPaciente}, paciente);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Paciente paciente)
        {
            try
            {
                if(id != paciente.CedulaPaciente)
                {
                    return BadRequest();
                }

                var pacienteTmp = await _context.Pacientes.FindAsync(id);

                if (pacienteTmp == null)
                {
                    return NotFound();
                }

                pacienteTmp.CedulaPaciente = paciente.CedulaPaciente;
                pacienteTmp.PrimerNombre = paciente.PrimerNombre;
                pacienteTmp.SegundoNombre = paciente.SegundoNombre;
                pacienteTmp.PrimerApellido = paciente.PrimerApellido;
                pacienteTmp.SegundoApellido = paciente.SegundoApellido;
                pacienteTmp.Correo = paciente.Correo;
                pacienteTmp.Genero = paciente.Genero;
                pacienteTmp.TelefonoPaciente = paciente.TelefonoPaciente;
                pacienteTmp.TelefonoContacto = paciente.TelefonoContacto;
                pacienteTmp.FechaNacimiento = paciente.FechaNacimiento;

                var provincia = await _context.Provincias.FindAsync(paciente.Provincia.ProvinciaId);
                pacienteTmp.Provincia = provincia;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
