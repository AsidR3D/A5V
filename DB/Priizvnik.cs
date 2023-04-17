using System;
using System.Collections.Generic;

namespace A5V.DB;

public partial class Priizvnik
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public string? Birthdate { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Education { get; set; }

    public string? Profession { get; set; }

    public string? MaritalStatus { get; set; }

    public string? CriminalRecord { get; set; }

    public virtual ICollection<Medkomissiya> Medkomissiyas { get; set; } = new List<Medkomissiya>();
}
