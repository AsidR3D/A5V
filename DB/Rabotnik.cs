using System;
using System.Collections.Generic;

namespace A5V.DB;

public partial class Rabotnik
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public string? Position { get; set; }
}
