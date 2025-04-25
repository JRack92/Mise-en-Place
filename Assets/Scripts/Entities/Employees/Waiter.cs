using UnityEngine;
using MiseEnPlace.Core.Interfaces;
using MiseEnPlace.Core.Strategy;

namespace MiseEnPlace.Core.Entities
{
    public class Waiter : Employee
    {
        // Constructor to initialize the Waiter object with name, level, salary strategy, and efficiency strategy
        public Waiter(string name, ExperienceLevel level, ISalaryStrategy salaryStrat, IEfficiencyStrategy efficiencyStrat)
        {
            _name = name;
            _level = level;
            _salaryStrategy = salaryStrat;
            _efficiencyStrategy = efficiencyStrat;
        }
    }

}
