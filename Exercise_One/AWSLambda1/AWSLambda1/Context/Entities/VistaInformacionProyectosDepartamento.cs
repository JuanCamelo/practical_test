using System;
using System.Collections.Generic;

namespace POO.Infraestructure.Entities;

public partial class VistaInformacionProyectosDepartamento
{
    public string? Department { get; set; }

    public string? Project { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? Budget { get; set; }
}
