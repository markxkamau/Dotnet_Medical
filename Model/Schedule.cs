using System;
using System.Collections.Generic;

namespace MedicalTrack.Model;

public partial class Schedule
{
    public int? ScheduleDay { get; set; }

    public TimeOnly ScheduleTime { get; set; }

    public bool[]? ScheduleConfirm { get; set; }

    public int SchedulePatientId { get; set; }

    public int ScheduleDrugId { get; set; }

    public int ScheduleId { get; set; }

    public virtual Drug ScheduleDrug { get; set; } = null!;

    public virtual Patient SchedulePatient { get; set; } = null!;
}
