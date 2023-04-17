using System;
using System.Collections.Generic;

namespace A5V.DB;

public partial class Medkomissiya
{
    public int Id { get; set; }

    public int? PriizvnikId { get; set; }

    public string? Height { get; set; }

    public string? Weight { get; set; }

    public string? BloodType { get; set; }

    public string? VisionLeft { get; set; }

    public string? VisionRight { get; set; }

    public string? HearingLeft { get; set; }

    public string? HearingRight { get; set; }

    public string? ChronicDiseases { get; set; }

    public string? MentalHealth { get; set; }

    public virtual Priizvnik? Priizvnik { get; set; }
}
