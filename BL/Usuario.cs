using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static (bool, string, List<ML.Usuario> usaurio, Exception) GetAll()
        {
			try
			{
				using (DL.HcanalesExamenApijunio12Context context =  new DL.HcanalesExamenApijunio12Context())
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
									  }
									  );
					if( getUsuario != null )
					{
						List<ML.Usuario> usuarios = new List<ML.Usuario>();
						foreach (var UsuarioObj in getUsuario )
						{
							ML.Usuario usuario1 = new ML.Usuario
							{
								IdUsuario = UsuarioObj.IdUsuario,
								Nombre = UsuarioObj.Nombre,
								Edad = UsuarioObj.Edad,
								FechaNacimiento = UsuarioObj.FechaNacimiento,
								Email = UsuarioObj.Email,
								Sexo = UsuarioObj.Sexo
							};
							usuarios.Add( usuario1 );
						}
						return(true, null, usuarios, null);
					}
					return (false, "No hay ningun registro", null, null);
				}
			}
			catch (Exception ex )
			{

				return (false, "No hay registro", null, null);
			}
        }

		public static (bool, string,Exception) Add(ML.Usuario Usuario)
		{
			try
			{
				using(DL.HcanalesExamenApijunio12Context context =  new DL.HcanalesExamenApijunio12Context())
				{
					DL.Usuario usuarioObj = new DL.Usuario
					{
						IdUsuario = Usuario.IdUsuario,
						Nombre = Usuario.Nombre,
						Edad = Usuario.Edad,
						FechaNacimiento = Usuario.FechaNacimiento,
						Email = Usuario.Email,
						Sexo = Usuario.Sexo
					};

					context.Usuarios.Add(usuarioObj);

					int rowAffected = context.SaveChanges();
					if (rowAffected > 0 )
					{
						return (true, null, null);
					}
					else
					{
						return (false, "No se Agrego , hubo un error", null);
					}
				}
			}
			catch (Exception ex)
			{

				return (false, ex.Message, null);
			}
		}

		public static (bool, string, ML.Usuario Usuario, Exception) GetById ( int IdUsuario)
		{
			try
			{
				using(DL.HcanalesExamenApijunio12Context context = new DL.HcanalesExamenApijunio12Context())
				{
					var getUsuario = (from User in context.Usuarios
									  where User.IdUsuario == IdUsuario
									  select new
									  {
										  IdUsuario = User.IdUsuario,
										  Nombre = User.Nombre,
										  Edad = User.Edad,
										  FechaNacimiento = User.FechaNacimiento,
										  Email = User.Email,
										  Sexo = User.Sexo,

									  }).SingleOrDefault();
					if (getUsuario != null)
					{
						ML.Usuario usuario = new ML.Usuario
						{
							IdUsuario = getUsuario.IdUsuario,
							Nombre = getUsuario.Nombre,
							Edad = getUsuario.Edad,
							FechaNacimiento = getUsuario.FechaNacimiento,
							Email = getUsuario.Email,
							Sexo = getUsuario.Sexo,

						};
						return(true,null,usuario,null);
					}
					return (false, "No se ha encontrado el idUsuario proprorcionado", null, null);
				}
			}
			catch (Exception ex)
			{

				return (false, ex.Message, null, null);
			}
		}

		public static (bool, string, Exception) Update(ML.Usuario usuario)
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
						FechaNacimiento = usuario.FechaNacimiento,
						Email = usuario.Email,
						Sexo = usuario.Sexo,
					};
					context.Usuarios.Update(usuarioObj);
					int rowAffected = context.SaveChanges();

					if(rowAffected > 0 )
					{
						return(true,null, null);
					}
					else
					{
						return(false,"Surgio un error, no se ha editado exitosamente ", null);
					}

				}
			}
			catch (Exception ex)
			{

				return (false, ex.Message, null);
			}
		}

		public static (bool, string, Exception) Delete (int idUsuario)
		{
			try
			{
				using(DL.HcanalesExamenApijunio12Context context = new DL.HcanalesExamenApijunio12Context())
				{
					context.Usuarios.Remove(new DL.Usuario
					{
						IdUsuario = idUsuario
					});

					int rowAffected = context.SaveChanges();
					if(rowAffected > 0 )
					{
						return(true,null, null);
					}
					else
					{
						return( false," no se ha elimnado correctamente", null);
					}
				}
			}
			catch (Exception ex)
			{

				return (false, ex.Message, null);
;			}
		}
    }
}
