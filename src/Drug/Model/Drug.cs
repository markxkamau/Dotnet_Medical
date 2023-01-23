using System;
using System.Collections.Generic;

namespace MedicalTrack.src.Drug.Model;

using MedicalTrack.src.Schedule.Dtos;
using MedicalTrack.src.Schedule.Model;
public partial class Drug
{
    public int DrugId { get; set; }
    public Dictionary<string, string>? DrugInfo { get; set; }

    public int DrugCount { get; set; }

    public Dictionary<string, string>? DrugPurpose { get; set; }

    public virtual ICollection<ScheduleDto> Schedules { get; } = new List<ScheduleDto>();
}
