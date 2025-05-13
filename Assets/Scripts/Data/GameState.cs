using UnityEngine;
using System.Collections.Generic;
using System;
using MiseEnPlace.Utilities;

namespace MiseEnPlace.Data
{
    [Serializable]
    public class GameState
    {
        public List<EmployeeData> employees = new List<EmployeeData>();
        public List<MachineData> machines = new List<MachineData>();

        public int reputation;
        public float balance;

        public int GetCountEmployees()
        {
            return employees.Count;
        }

        public int GetCountCookEmployees()
        {
            return employees.FindAll(e => e.role == EmployeeRole.Cook).Count;
        }

        public int GetCountWaiterEmployees()
        {
            return employees.FindAll(e => e.role == EmployeeRole.Waiter).Count;
        }

        public float GetTotalSalary()
        {
            float totalSalary = 0f;
            foreach (EmployeeData employee in employees)
            {
                totalSalary += employee.GetSalary();
            }
            return totalSalary;
        }

        public float GetTotalProductivity()
        {
            float totalProductivity = 0f;
            foreach (EmployeeData employee in employees)
            {
                totalProductivity += employee.GetProductivity();
            }
            return totalProductivity;
        }

        public float GetTotalSabotageChance()
        {
            float totalSabotageChance = 0f;
            foreach (EmployeeData employee in employees)
            {
                if (employee.isSaboteur)
                {
                    totalSabotageChance += employee.sabotageChance;
                }
            }
            return totalSabotageChance;
        }

        public float GetTotalSuspicion()
        {
            float totalSuspicion = 0f;
            foreach (EmployeeData employee in employees)
            {
                totalSuspicion += employee.suspicion;
            }
            return totalSuspicion;
        }
    }
}
