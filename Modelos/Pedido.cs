using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiExamen.Modelos
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        [ForeignKey("Comanda")]
        public int ComandaId { get; set; }
        [ForeignKey("Pintxo")]
        public int PintxoId { get; set; }
        public int Cantidad { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Comanda Comanda { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]       
        public Pintxo Pintxo { get; set; }

    }
}
