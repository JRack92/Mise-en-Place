using MiseEnPlace.Core;
using UnityEngine;
using MiseEnPlace.Data;
using MiseEnPlace.Utilities;
using System.Collections.Generic;


namespace MiseEnPlace.UI
{
    public class UIPanelEmployee : MonoBehaviour
    {
        [SerializeField] private BasicButton _btnExit;
        [SerializeField] private BasicButton _btnCookList;
        [SerializeField] private BasicButton _btnWaiterList;
        [SerializeField] private Transform _listDataContainer;
        [SerializeField] private BtnAboutEmployee _btnAboutEmployeePrefab;

        //lista para ser usada en un pool de objetos o para almacenar los botones de empleados
        private List<BtnAboutEmployee> _btnAboutEmployees = new List<BtnAboutEmployee>();

        private void Awake()
        {
            _btnExit.AddEventClick(() =>
          {
              GameManager.Instance.UIManager.ClosePanelEmployee();
          });
        }

        void Start()
        {
            ShowListEmployee(EmployeeRole.Cook);
        }

        /// <summary>Displays a list of employees filtered by the specified role.
        /// </summary>
        /// <remarks>This method clears the current employee list before populating it with employees 
        /// whose roles match the specified <paramref name="employeeRole"/>.</remarks>
        /// <param name="employeeRole">The role of employees to display. Only employees matching this role will be shown.</param>
        public void ShowListEmployee(EmployeeRole employeeRole)
        {
            ClearEmployeeList();

            foreach (EmployeeData employeeData in GameManager.Instance.State.employees)
            {
                if (employeeData.role == employeeRole)
                {
                    InstanceEmployee(employeeData);
                }
            }
        }

        /// <summary>Deactivates all employee-related UI elements in the list.
        /// </summary>
        /// <remarks>This method iterates through the collection of employee UI elements and sets their 
        /// active state to <see langword="false"/>. It is typically used to hide all employee-related  UI components
        /// from view.</remarks>
        private void ClearEmployeeList()
        {
            foreach (BtnAboutEmployee btnAbountEmployee in _btnAboutEmployees)
            {
                btnAbountEmployee.gameObject.SetActive(false);
            }
        }

        /// <summary> Instantiates a new employee button and initializes it with the provided employee data.
        /// </summary>
        /// <remarks>This method creates a button for an employee, sets the employee's information on the
        /// button,  and attaches a click event to display the employee's details in the UI.</remarks>
        /// <param name="employeeData">The data representing the employee to be displayed on the button.</param>
        public void InstanceEmployee(EmployeeData employeeData)
        {
            // Busca un botón inactivo en el pool
            BtnAboutEmployee btnAboutEmployee = _btnAboutEmployees.Find(b => !b.gameObject.activeSelf);

            if (btnAboutEmployee == null)
            {
                btnAboutEmployee = Instantiate(_btnAboutEmployeePrefab, _listDataContainer);
                _btnAboutEmployees.Add(btnAboutEmployee);

                btnAboutEmployee.AddEventClick(() =>
                {
                    // Mostrar detalles del empleado en la UI
                });
            }
            else
            {
                btnAboutEmployee.transform.SetParent(_listDataContainer, false);
            }

            btnAboutEmployee.gameObject.SetActive(true);
            btnAboutEmployee.SetEmployeeInfo(employeeData, null);
        }
    }
}