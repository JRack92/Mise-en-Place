
using System;

namespace MiseEnPlace.Utilities
{
    public enum EmployeeLevel
    {
        Novice = 1,
        Intermediate = 2,
        Advanced = 3,
        Expert = 4,
        Master = 5
    }

    public static class EmployeeLevelExtensions
    {
        public static string ToFriendlyString(this EmployeeLevel type)
        {
            return type switch
            {
                EmployeeLevel.Novice => "Novice",
                EmployeeLevel.Intermediate => "Intermediate",
                EmployeeLevel.Advanced => "Advanced",
                EmployeeLevel.Expert => "Expert",
                EmployeeLevel.Master => "Master",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
