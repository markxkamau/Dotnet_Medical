using System;
using System.Collections.Generic;

namespace MedicalTrack.src.Test.Model;

using MedicalTrack.src.Patient.Model;


public partial class Test
{
    public int TestId { get; set; }

    public int TestResultBp { get; set; }

    public int TestResultSugars { get; set; }

    public int TestResultWeight { get; set; }

    public int TestResultOxygen { get; set; }

    public int TestPatientId { get; set; }

    public virtual Patient TestPatient { get; set; } = null!;
}
