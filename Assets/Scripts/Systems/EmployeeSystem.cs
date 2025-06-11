using MiseEnPlace.Core;
using MiseEnPlace.Data;
using MiseEnPlace.Gameplay;
using MiseEnPlace.Utilities;

using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Design;

namespace MiseEnPlace.Systems
{
    public class EmployeeSystem : GSystem
    {
        [SerializeField] private Cook _cookPrefab;
        [SerializeField] private Waiter _waiterPrefab;

        [SerializeField] private GameObject _employeeContainer;

        private List<Cook> _cooks = new List<Cook>();
        private List<Waiter> _waiters = new List<Waiter>();


        private void Awake()
        {
            _employeeContainer = GameObject.Find("EmployessContainer");
            _cookPrefab = Resources.Load<Cook>("Prefabs/Employee/Cook");
            _waiterPrefab = Resources.Load<Waiter>("Prefabs/Employee/Waiter");
        }

        void Start()
        {

            //TODO: Start Game
            if (GameManager.Instance.State.employees.Count == 0)
            {
                // Hire a Initial employee
                HireInitialEmployee_Test();
            }
            else
            {
                LoadEmployee();
            }

            Debug.Log("Total employees: " + GameManager.Instance.State.GetCountEmployees());

            GameManager.Instance.UIManager.UISystems.EmployeeBtnSystem.UpdateCount(GameManager.Instance.State.GetCountEmployees());
        }

        private void LoadEmployee()
        {
            // Load employees from the game state
            foreach (EmployeeData employeeData in GameManager.Instance.State.employees)
            {
                InstanceEmployee(employeeData);
            }
        }

        /// <summary>
        /// Test method to hire initial employees
        /// </summary>
        private void HireInitialEmployee_Test()
        {
            // Example: hire a Novato Cook and an Intermedio Waiter
            EmployeeData newCook = new EmployeeData
            {
                id = System.Guid.NewGuid().ToString(),
                role = EmployeeRole.Cook,
                level = EmployeeLevel.Novice,
                isSaboteur = false,
                sabotageChance = 0.05f,
                suspicion = 0f,
                position = new SerializableVector3(Vector3.zero) // Set initial position
            };

            EmployeeData newWaiter = new EmployeeData
            {
                id = System.Guid.NewGuid().ToString(),
                role = EmployeeRole.Waiter,
                level = EmployeeLevel.Novice,
                isSaboteur = false,
                sabotageChance = 0.05f,
                suspicion = 0f,
                position = new SerializableVector3(Vector3.zero) // Set initial position

            };

            GameManager.Instance.State.employees.Add(newCook);
            InstanceEmployee(newCook);
            //GameManager.Instance.UIManager.UISystems.CookBtnSystem.UpdateCount(GameManager.Instance.State.GetCountCookEmployees());
            Debug.Log("Hired employee: " + newCook.id);

            GameManager.Instance.State.employees.Add(newWaiter);
            InstanceEmployee(newWaiter);
            //GameManager.Instance.UIManager.UISystems.WaiterBtnSystem.UpdateCount(GameManager.Instance.State.GetCountWaiterEmployees());
            Debug.Log("Hired employee: " + newWaiter.id);
        }

        public void InstanceEmployee(EmployeeData employeeData)
        {
            GameObject employeePrefab = null;

            employeePrefab = employeeData.role == EmployeeRole.Cook ? _cookPrefab.gameObject : _waiterPrefab.gameObject;

            if (employeePrefab != null)
            {
                GameObject newEmployee = Instantiate(employeePrefab, _employeeContainer.transform);
                newEmployee.name = employeeData.id;
                newEmployee.transform.localPosition = employeeData.position.ToVector3();
                // Set the employee data
                Employee employeeComponent = newEmployee.GetComponent<Employee>();
                if (employeeComponent != null)
                {
                    employeeComponent.SetEmployeeData(employeeData);
                }
            }
        }

        // TODO: implement risks, firing, sabotage events

        /// <summary>
        /// Despide un empleado
        /// </summary>
        /// <param name="employeeId"></param>
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
            GameState state = GameManager.Instance.State;
            foreach (EmployeeData emp in state.employees)
            {
                if (emp.id == saboteurId)
                {
                    emp.suspicion += 1f;
                    GameManager.Instance.UIManager.UISystems.AlertSabotage(emp);
                }
                else emp.suspicion += 0.1f; // others gain small suspicion
            }

            GameManager.Instance.UIManager.UIPoints.UpdateCountSabotage();

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
