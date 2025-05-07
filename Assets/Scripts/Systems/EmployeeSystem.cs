using MiseEnPlace.Core;
using MiseEnPlace.Data;
using MiseEnPlace.Gameplay;
using MiseEnPlace.Utilities;

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace MiseEnPlace.Systems
{
    public class EmployeeSystem : GSystem
    {
        void Start()
        {
            if (GameManager.Instance.State.employees.Count == 0)
            {
                // Hire a Initial employee
                HireInitialEmployee();
            }
        }

        private void HireInitialEmployee()
        {
            // Example: hire a Novato Cook and an Intermedio Waiter
            EmployeeData newCook = new EmployeeData
            {
                id = System.Guid.NewGuid().ToString(),
                role = EmployeeRole.Cook,
                level = EmployeeLevel.Novice,
                isSaboteur = true,
                sabotageChance = 0.05f,
                suspicion = 0f
            };

            EmployeeData newWaiter = new EmployeeData
            {
                id = System.Guid.NewGuid().ToString(),
                role = EmployeeRole.Waiter,
                level = EmployeeLevel.Intermediate,
                isSaboteur = false,
                sabotageChance = 0.05f,
                suspicion = 0f
            };

            GameManager.Instance.State.employees.Add(newCook);
            GameManager.Instance.State.employees.Add(newWaiter);

            Debug.Log("Hired employee: " + newCook.id);
            Debug.Log("Hired employee: " + newWaiter.id);
        }

        // TODO: implement risks, firing, sabotage events

        public void FireEmployee(string employeeId)
        {
            List<EmployeeData> employees = GameManager.Instance.State.employees;
            EmployeeData employee = employees.Find(e => e.id == employeeId);
            if (employee != null)
            {
                employees.Remove(employee);
                Debug.Log($"Empleado {employee.id} ha sido despedido.");
                //TODO: Implementar efectos de despido
            }
        }

        public void OnMachineSabotaged(string machineId, string saboteurId)
        {
            // Increment suspicion for employees when sabotage occurs
            var state = GameManager.Instance.State;
            foreach (var emp in state.employees)
            {
                if (emp.id == saboteurId) emp.suspicion += 1f;
                else emp.suspicion += 0.1f; // others gain small suspicion
            }
            Debug.Log($"Updated suspicion scores after sabotage on machine {machineId} by {saboteurId}.");
        }

        public EmployeeData IdentifyTopSuspect()
        {
            // Return the employee with highest suspicion
            return GameManager.Instance.State.employees
                .OrderByDescending(e => e.suspicion)
                .FirstOrDefault();
        }
    }
}
