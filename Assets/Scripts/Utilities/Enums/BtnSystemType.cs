using System;

namespace MiseEnPlace.Utilities
{
    public enum BtnSystemType
    {
        Employee,
        Machine,
        Environment,
        Other
    }
    public static class BtnSystemTypeExtensions
    {
        public static string ToFriendlyString(this BtnSystemType type)
        {
            return type switch
            {
                BtnSystemType.Employee => "Employee",
                BtnSystemType.Machine => "Machine",
                BtnSystemType.Environment => "Environment",
                BtnSystemType.Other => "Other",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}