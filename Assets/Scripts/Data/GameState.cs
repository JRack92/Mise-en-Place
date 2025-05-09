using UnityEngine;
using System.Collections.Generic;
using System;
using MiseEnPlace.Utilities;

namespace MiseEnPlace.Data
{
    [Serializable]
    public class GameState
    {
        public List<EmployeeData>  employees = new List<EmployeeData>();
        public List<MachineData> machines = new List<MachineData>();

        public int reputation;
        public float balance;

        public int GetCountCookEmployees()
        {
            return employees.FindAll(e => e.role == EmployeeRole.Cook).Count;
        }

        public int GetCountWaiterEmployees()
        {
            return employees.FindAll(e => e.role == EmployeeRole.Waiter).Count;
        }
    }
}
