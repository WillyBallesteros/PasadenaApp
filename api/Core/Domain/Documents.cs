using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Documents
    {
        [Key]
        public Guid DocumentId { get; set; }
        public Guid ObjetoReferencia { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public byte[] Contenido { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
