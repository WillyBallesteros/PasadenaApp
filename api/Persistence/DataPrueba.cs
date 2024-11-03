using System;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace Persistence
{
    public class DataPrueba
    {
        public static async Task InsertarData(PasadenaAppContext context, UserManager<Usuarios> usuarioManager)
        {
            if (!usuarioManager.Users.Any())
            {
                var usuario = new Usuarios
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombres = "William",
                    Apellidos = "Ballesteros",
                    Activo = true,
                    Email = "ballesteroswilliam@gmail.com",
                    UserName = "wballesteros",
                };

                await usuarioManager.CreateAsync(usuario, "Pwd$12874");

            }
        }
    }
}
