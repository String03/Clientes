using System;
using System.Collections.Generic;

namespace Clientes.DAO;

public partial class Cliente
{
    public long Id { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateTime? FechaDeNacimiento { get; set; }

    public string? Cuit { get; set; }

    public string? Domicilio { get; set; }

    public string? TelefonoCelular { get; set; }

    public string? Email { get; set; }
}
