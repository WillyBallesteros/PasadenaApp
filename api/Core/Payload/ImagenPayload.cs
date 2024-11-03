using System;

namespace Core.Payload
{
    public class ImagenPayload
    {
        public Guid? ObjetoReferencia { get; set; }
        public string Data { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
    }
}
