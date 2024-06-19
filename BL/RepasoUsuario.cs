using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    static class RepasoUsuario
    {
       
        public static (bool, string, List<ML.Usuario> usuarios, Exception) GetAll()
        {
            try
            {
                using(DL.HcanalesExamenApijunio12Context context = new DL.HcanalesExamenApijunio12Context())
                {
                    var getUsuario = (from User in context.Usuarios
                                      select new
                                      {
                                          IdUsuario = User.IdUsuario,
                                          Nombre = User.Nombre,
                                          Edad = User.Edad,
                                          FechaNacimiento = User.FechaNacimiento,
                                          Email = User.Email,
                                          Sexo = User.Sexo
                                      });

                    if(getUsuario != null)
                    {
                        List<ML.Usuario> usuarios = new List<ML.Usuario>();
                        foreach(var usuarioObj in getUsuario)
                        {
                            ML.Usuario usuario1 = new ML.Usuario
                            {
                                IdUsuario = usuarioObj.IdUsuario,
                                Nombre = usuarioObj.Nombre,
                                Edad = usuarioObj.Edad,
                                FechaNacimiento = usuarioObj.FechaNacimiento,
                                Email = usuarioObj.Email
                            };

                            usuarios.Add(usuario1);
                        }
                        return (true, "No hay registros", usuarios, null);
                    }
                    return (false, null, null, null);
                }
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, ex);
            }
        }


        public static (bool, string, Exception) Add(ML.Usuario usuario)
        {
            try
            {
                using(DL.HcanalesExamenApijunio12Context context = new DL.HcanalesExamenApijunio12Context())
                {
                    DL.Usuario usuarioObj = new DL.Usuario
                    {
                        IdUsuario = usuario.IdUsuario,
                        Nombre = usuario.Nombre,
                        Edad = usuario.Edad,

                    };

                    context.Usuarios.Add(usuarioObj);

                    int rowAffected = context.SaveChanges();
                    if(rowAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, "No se ha agregado correctamente ", null);
                    }
                }
            }
            catch (Exception ex)
            {

                return (false, ex.Message, ex);
            }
        }
    }
}
