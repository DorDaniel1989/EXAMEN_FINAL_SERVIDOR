using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiExamen.Modelos;

namespace Final1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly ApiContext _context;

        public PedidosController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }
        [HttpGet("TotalImportes")]
        public async Task<ActionResult> TotalImporte()
        {
           
            var pedido = await _context.Comandas.SelectMany(p=>p.Pedidos ,(com,ped)=>new{
                                                                                comanda =com.IdComanda,
                                                                                totalLinea =ped.Cantidad * ped.Pintxo.precio
            })
                                                .GroupBy(c=>c.comanda).Select(s=>new{
                                                    Comanda=s.Key,
                                                    total = s.Sum(b=>b.totalLinea)
                                                }).ToListAsync();


             return Ok(new {
                Total ="Total importe por comanda",
                data = pedido
             }) ;
        }


         [HttpGet("TotalImportes/{id}")]
        public async Task<ActionResult> TotalImporteDeComanda(int id)
        {
           
            var pedido = await _context.Comandas.Where(a=>a.IdComanda==id)
                                                .SelectMany(p=>p.Pedidos ,(com,ped)=>new{
                                                                                comanda =com.IdComanda,
                                                                                totalLinea =ped.Cantidad *ped.Pintxo.precio
            })
                                                .GroupBy(c=>c.comanda).Select(s=>new{
                                                    Comanda=s.Key,
                                                    total = s.Sum(b=>b.totalLinea)
                                                }).ToListAsync();


             return Ok(new {
                Total ="Total importe de la comanda",
                data = pedido
             }) ;
        }
        


        
         [HttpGet("TotalImportesMesas")]
        public async Task<ActionResult> TotalImporteDeMesas()
        {
           
            var pedido = await _context.Comandas.SelectMany(p=>p.Pedidos ,(com,ped)=>new{

                                                mesa =com.NumMesa,
                                                Pintxo =ped.Pintxo.nombre,
                                                precioPintxo =ped.Pintxo.precio,
                      
                                                })
                                                .GroupBy(c=>c.mesa).Select(s=>new{
                                                    Mesa=s.Key,
                                                    total = s.Sum(b=>b.precioPintxo)
                                                }).ToListAsync();

             return Ok(new {
                Total ="Total importe de las Mesas",
                data = pedido
             }) ;
        }

              [HttpGet("TotalImportesMesas/{id}")]
        public async Task<ActionResult> TotalImporteDeMesa(int id)
        {
           
            var pedido = await _context.Comandas.Where(a=>a.NumMesa==id)
                                                .SelectMany(p=>p.Pedidos ,(com,ped)=>new{

                                                            mesa =com.NumMesa,
                                                            Pintxo =ped.Pintxo.nombre,
                                                            precioPintxo =ped.Pintxo.precio,

                                                })
                                                .GroupBy(c=>c.mesa).Select(s=>new{
                                                    Mesa=s.Key,
                                                    total = s.Sum(b=>b.precioPintxo)
                                                }).ToListAsync();


             return Ok(new {
                Total ="Total importe de la Mesa",
                data = pedido
             }) ;
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.PedidoId }, pedido);
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.PedidoId == id);
        }
    }
}
