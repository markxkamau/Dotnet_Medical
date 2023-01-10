using System;
using System.Collections.Generic;

namespace MedicalTrack.Model;

public partial class Drug
{
    public int DrugId { get; set; }

    public Dictionary<string, string>? DrugInfo { get; set; }

    public int? DrugCount { get; set; }

    public Dictionary<string, string>? DrugPurpose { get; set; }

    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();
}
