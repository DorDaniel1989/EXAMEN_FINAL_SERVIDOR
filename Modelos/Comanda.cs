using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiExamen.Modelos
{
    public class Comanda
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int IdComanda { get; set; }
        public int NumMesa { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Pedido> Pedidos { get; set; }
    }
}
