using UnityEngine;
using MiseEnPlace.Core.Employees;
using MiseEnPlace.Core.Interfaces;

namespace MiseEnPlace.Core.Entities
{
    public abstract class Employee : MonoBehaviour
    {
        protected string _name;

        protected ExperienceLevel _level;

        protected ISalaryStrategy _salaryStrategy;

        protected IEfficiencyStrategy _efficiencyStrategy;

        protected virtual void Work()
        {
            // EfficiencyStrat.Apply(this);
        }
    }
}