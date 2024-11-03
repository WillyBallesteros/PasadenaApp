using System;

namespace Core.Dtos
{
    public class DocumentoDto
    {
        public Guid? DocumentoId { get; set; }
        public Guid? ObjetoReferencia { get; set; }
        public string Data { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
    }
}
