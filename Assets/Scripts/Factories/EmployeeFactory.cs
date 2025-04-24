using MiseEnPlace.Core.Employees;
using MiseEnPlace.Core.Entities;
using MiseEnPlace.Core.Interfaces;
using MiseEnPlace.Core.Enum;
using UnityEngine;

namespace MiseEnPlace.Core.Factories
{
    public class EmployeeFactory : MonoBehaviour
    {
        public static Employee Create(EmployeeType type, string name, ExperienceLevel experienceLevel, ISalaryStrategy salaryStrategy, IEfficiencyStrategy efficiencyStrategy)
        {
            Employee employee = null;
            switch (type)
            {
                case EmployeeType.Cook:
                    employee = new Cook(name, experienceLevel, salaryStrategy, efficiencyStrategy);
                    break;
                case EmployeeType.Waiter:
                    employee = new Waiter(name, experienceLevel, salaryStrategy, efficiencyStrategy);
                    break;
                default:
                    Debug.LogError("Invalid employee type");
                    break;
            }
            return employee;
        }
    }
}
