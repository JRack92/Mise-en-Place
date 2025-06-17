using System;

namespace MiseEnPlace.Utilities
{
    public enum EmployeeRole
    {
        Cook, 
        Waiter
    }

    public static class EmployeeRoleExtensions
    {
        public static string ToFriendlyString(this EmployeeRole role)
        {
            return role switch
            {
                EmployeeRole.Cook => "Cook",
                EmployeeRole.Waiter => "Waiter",
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
            };
        }
    }
}
