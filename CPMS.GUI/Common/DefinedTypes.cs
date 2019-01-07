using System;
using System.Collections.Generic;
using System.Text;

namespace CPMS.DAL.Common
{
    public enum Points
    {
        VeryLow = 1,
        Low = 3,
        Intermediate = 5,
        Hard = 7,
        VeryHard = 9
    }

    public enum TaskType
    {
        Feature,
        Error
    }

    public enum Status
    {
        Active,
        Delayed,
        Done
    }

    public enum Role
    {
        Tester,
        Developer,
        Manager
    }
}
