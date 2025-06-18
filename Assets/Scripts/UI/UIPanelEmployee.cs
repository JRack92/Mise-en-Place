using MiseEnPlace.Core;
using MiseEnPlace.Data;
using MiseEnPlace.Utilities;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace MiseEnPlace.UI
{
    public class UIPanelEmployee : MonoBehaviour
    {
        [SerializeField] private BasicButton _btnExit;
        [SerializeField] private BasicButton _btnCookList; //Boton para mostrar la lista de cocineros
        [SerializeField] private BasicButton _btnWaiterList; //Boton para mostrar la lista de camareros
        [SerializeField] private Transform _listDataContainer;
        private BtnAboutEmployee _btnAboutEmployeePrefab;

        [SerializeField]
        private EmployeeDataUI _employeeDataUI; // UI para mostrar los detalles del empleado seleccionado

        private EmployeeRole _currentEmployeeRole = EmployeeRole.Cook; // Rol de empleado actual para mostrar

        private Action OnEmployeeListSelected;

        //lista para ser usada en un pool de objetos o para almacenar los botones de empleados
        private List<BtnAboutEmployee> _btnAboutEmployees = new List<BtnAboutEmployee>();

        private void OnEnable()
        {
            if (_btnAboutEmployeePrefab == null)
            {
                _btnAboutEmployeePrefab = Resources.Load<BtnAboutEmployee>("Prefabs/UI/BtnAboutEmployee");
            }
        }

        private void Awake()
        {
            _btnExit.AddEventClick(() =>
            {
                GameManager.Instance.UIManager.ClosePanelEmployee();
            });

            _btnCookList.AddEventClick(() =>
            {
                ShowListEmployee(EmployeeRole.Cook);
                UpdateRoleButtonColors(EmployeeRole.Cook);
            });

            _btnWaiterList.AddEventClick(() =>
            {
                ShowListEmployee(EmployeeRole.Waiter);
                UpdateRoleButtonColors(EmployeeRole.Waiter);
            });

            // Inicializar los botones de rol
            UpdateRoleButtonColors(_currentEmployeeRole);
        }

        void Start()
        {
            ShowListEmployee(EmployeeRole.Cook);
        }

        public void LoadDataEmployeeUI(EmployeeData employeeData)
        {
            if (employeeData == null)
            {
                Debug.LogError("Employee data is null.");
                return;
            }
            _employeeDataUI.gameObject.SetActive(true);
            _employeeDataUI.LoadEmployeeData(employeeData);
        }

        /// <summary>Displays a list of employees filtered by the specified role.
        /// </summary>
        /// <remarks>This method clears the current employee list before populating it with employees 
        /// whose roles match the specified <paramref name="employeeRole"/>.</remarks>
        /// <param name="employeeRole">The role of employees to display. Only employees matching this role will be shown.</param>
        public void ShowListEmployee(EmployeeRole employeeRole)
        {
            _currentEmployeeRole = employeeRole;

            ClearEmployeeList();

            foreach (EmployeeData employeeData in GameManager.Instance.State.employees)
            {
                if (employeeData.role == employeeRole)
                {
                    InstanceBtnEmployee(employeeData);
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

        /// <summary>
        /// Cambia el color de los botones de rol para indicar cuál está seleccionado y cuál no.
        /// </summary>
        /// <param name="selectedRole">El rol actualmente seleccionado.</param>
        private void UpdateRoleButtonColors(EmployeeRole selectedRole)
        {
            Color selectedColor = new Color(0.2f, 0.6f, 1f, 1f); // Azul seleccionado
            Color unselectedColor = Color.white;

            if (_btnCookList != null)
                _btnCookList.GetComponent<UnityEngine.UI.Image>().color = (selectedRole == EmployeeRole.Cook) ? selectedColor : unselectedColor;

            if (_btnWaiterList != null)
                _btnWaiterList.GetComponent<UnityEngine.UI.Image>().color = (selectedRole == EmployeeRole.Waiter) ? selectedColor : unselectedColor;
        }

        /// <summary> Instantiates a new employee button and initializes it with the provided employee data.
        /// </summary>
        /// <remarks>This method creates a button for an employee, sets the employee's information on the
        /// button,  and attaches a click event to display the employee's details in the UI.</remarks>
        /// <param name="employeeData">The data representing the employee to be displayed on the button.</param>
        public void InstanceBtnEmployee(EmployeeData employeeData)
        {
            // Busca un botón inactivo en el pool
            BtnAboutEmployee btnAboutEmployee = _btnAboutEmployees.Find(b => !b.gameObject.activeSelf);

            if (btnAboutEmployee == null)
            {
                btnAboutEmployee = Instantiate(_btnAboutEmployeePrefab, _listDataContainer);
                _btnAboutEmployees.Add(btnAboutEmployee);

                //btnAboutEmployee.AddEventClick(() =>
                //{

                //});
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