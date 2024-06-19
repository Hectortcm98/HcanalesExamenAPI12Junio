using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public byte Edad { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string Email { get; set; } = null!;

    public string? Sexo { get; set; }
}
