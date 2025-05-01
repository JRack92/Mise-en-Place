using MiseEnPlace.Core;
using MiseEnPlace.Data;
using MiseEnPlace.Gameplay;
using MiseEnPlace.Utilities;

using UnityEngine;
using System.Collections.Generic;

namespace MiseEnPlace.Systems
{
    public class EmployeeSystem : GSystem
    {
        void Start()
        {
            // Example: hire a Novato chef
            EmployeeData newCook = new EmployeeData
            {
                id = System.Guid.NewGuid().ToString(),
                role = EmployeeRole.Cook,
                level = EmployeeLevel.Novice,
            };

            EmployeeData newWaiter = new EmployeeData
            {
                id = System.Guid.NewGuid().ToString(),
                role = EmployeeRole.Waiter,
                level = EmployeeLevel.Intermediate,
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
    }
}
