using MiseEnPlace.Core.Interfaces;
using MiseEnPlace.Core.Strategy;

namespace MiseEnPlace.Core.Entities
{
    public class Cook : Employee
    {
        // Constructor to initialize the Cook object with name, level, salary strategy, and efficiency strategy
        public Cook(string name, ExperienceLevel level, ISalaryStrategy salaryStrat, IEfficiencyStrategy efficiencyStrat)
        {
            _name = name;
            _level = level;
            _salaryStrategy = salaryStrat;
            _efficiencyStrategy = efficiencyStrat;
        }
    }

}
