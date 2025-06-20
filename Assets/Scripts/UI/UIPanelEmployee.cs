using MiseEnPlace.Core;
using MiseEnPlace.Data;
using MiseEnPlace.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace MiseEnPlace.UI
{
    public class UIPanelEmployee : MonoBehaviour
    {
        private RectTransform _containerLIstBtnAboutEmployee; // Contenedor de los botones de empleados

        private BasicButton _btnExit; // Botón para cerrar el panel de empleados
        private BasicButton _btnCookList; //Boton para mostrar la lista de cocineros
        private BasicButton _btnWaiterList; //Boton para mostrar la lista de camareros
        private BtnAboutEmployee _btnAboutEmployeePrefab; // Prefab del botón que muestra información sobre el empleado

        private RectTransform _panelListEmployees; // Panel que contiene la lista de empleados y sus detalles
        private UIEmployeeData _employeeDataUI; // UI para mostrar los detalles del empleado seleccionado

        private EmployeeRole _currentEmployeeRole = EmployeeRole.Cook; // Rol de empleado actual para mostrar

        private Action OnEmployeeListSelected;

        private List<BtnAboutEmployee> _btnAboutEmployees = new List<BtnAboutEmployee>(); //lista para ser usada en un pool de objetos o para almacenar los botones de empleados

        private void LoadElementsUI()
        {
            if (_btnExit == null)
                _btnExit = this.transform.Find("PanelListEmployees/ExitButton").GetComponent<BasicButton>();

            if (_btnCookList == null)
                _btnCookList = this.transform.Find("PanelListEmployees/PanelMenu/Cook").GetComponent<BasicButton>();

            if (_btnWaiterList == null)
                _btnWaiterList = this.transform.Find("PanelListEmployees/PanelMenu/Waiter").GetComponent<BasicButton>();

            if (_panelListEmployees == null)
                _panelListEmployees = this.transform.Find("PanelListEmployees").GetComponent<RectTransform>();

            if (_containerLIstBtnAboutEmployee == null)
                _containerLIstBtnAboutEmployee = this.transform.Find("PanelListEmployees/ListBtnAboutEmployee").GetComponent<RectTransform>();

            if (_employeeDataUI == null)
                _employeeDataUI = this.transform.Find("EmployeeDataUI").GetComponent<UIEmployeeData>();

            if (_btnAboutEmployeePrefab == null)
                _btnAboutEmployeePrefab = Resources.Load<BtnAboutEmployee>("Prefabs/UI/BtnAboutEmployee");
        }

        private void Awake()
        {
            LoadElementsUI();

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

        public void ShowUIControllers(bool value)
        {
            _panelListEmployees.gameObject.SetActive(value);
        }

        public void LoadDataEmployeeUI(EmployeeData employeeData)
        {
            if (employeeData == null)
            {
                Debug.LogError("Employee data is null.");
                return;
            }
            _employeeDataUI.gameObject.SetActive(true);
            ShowUIControllers(false);
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
                btnAboutEmployee = Instantiate(_btnAboutEmployeePrefab, _containerLIstBtnAboutEmployee);
                _btnAboutEmployees.Add(btnAboutEmployee);

                //btnAboutEmployee.AddEventClick(() =>
                //{

                //});
            }
            else
            {
                btnAboutEmployee.transform.SetParent(_containerLIstBtnAboutEmployee, false);
            }

            btnAboutEmployee.gameObject.SetActive(true);
            btnAboutEmployee.SetEmployeeInfo(employeeData, null);
        }
    }
}