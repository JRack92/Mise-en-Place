using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MiseEnPlace.Data;
using Mono.Cecil;
using MiseEnPlace.Utilities;
using MiseEnPlace.Core;
using System.IO;

namespace MiseEnPlace.UI
{
    public class UIEmployeeData : MonoBehaviour
    {
        private Image _employeePicture;

        private BasicButton _btnExit; // Botón para cerrar el panel de empleados

        private TextMeshProUGUI _employeeRoleText; // Texto que muestra el rol del empleado
        private TextMeshProUGUI _employeeLevelText; // Texto que muestra el nivel del empleado
        private TextMeshProUGUI _employeeSabotageText; // Texto que muestra la probabilidad de sabotaje del empleado
        private TextMeshProUGUI _employeeSalaryText; //Texto que muestra el salario del empleado

        private EmployeeData _currentEmployeeData; // Datos del empleado actual

        private BasicButton _btnCurrentState; // Botón para mostrar el estado actual del empleado (contratado/Por Contratar)

        private const string PICTURE_DEFAUT_PATH = "Sprites/Employee/CookPicturePH"; // Ruta base de las imágenes de los empleados

        private void Awake()
        {
            _employeePicture = this.transform.Find("EmployeePicture").GetComponent<Image>();
            _employeeRoleText = this.transform.Find("EmployeeData_Info/DataInfo_Role/Info").GetComponent<TextMeshProUGUI>();
            _employeeLevelText = this.transform.Find("EmployeeData_Info/DataInfo_Level/Info").GetComponent<TextMeshProUGUI>();
            _employeeSabotageText = this.transform.Find("EmployeeData_Info/DataInfo_Sabotage/Info").GetComponent<TextMeshProUGUI>();
            _employeeSalaryText = this.transform.Find("EmployeeData_Info/DataInfo_Salary/Info").GetComponent<TextMeshProUGUI>();
            _btnExit = this.transform.Find("ExitButton").GetComponent<BasicButton>();
            _btnCurrentState = this.transform.Find("CurrentState").GetComponent<BasicButton>();

            _btnExit.AddEventClick(() =>
            {
                this.gameObject.SetActive(false);
                GameManager.Instance.UIManager.UIPanelEmployee.ShowUIControllers(true);
            });

            _btnCurrentState.AddEventClick(() =>
            {
                //Cael estado del empleado entre contratado y por contratar
            });
        }

        //Cargar los datos del empleado en la UI
        public void LoadEmployeeData(EmployeeData employeeData)
        {
            Debug.Log($"Loading employee data for: {employeeData.id}");

            _currentEmployeeData = employeeData;

            if (_currentEmployeeData == null)
            {
                Debug.LogError("Employee data is null.");
                return;
            }

            _btnCurrentState.GetComponentInChildren<TextMeshProUGUI>().text = _currentEmployeeData.isHired ? "Contratado" : "Por Contratar";

            _btnCurrentState.GetComponent<Image>().color = _currentEmployeeData.isHired ? Color.green : Color.red;

            string picturePath = string.IsNullOrEmpty(employeeData.picturePath) ? PICTURE_DEFAUT_PATH : employeeData.picturePath;

            _employeePicture.sprite = Resources.Load<Sprite>(picturePath);
            _employeeRoleText.text = _currentEmployeeData.role.ToFriendlyString();
            _employeeLevelText.text = _currentEmployeeData.level.ToFriendlyString();
            _employeeSabotageText.text = _currentEmployeeData.GetSabogageChance().ToString();
            _employeeSalaryText.text = _currentEmployeeData.GetSalary().ToString("C2"); // Formato de moneda
        }
    }
}