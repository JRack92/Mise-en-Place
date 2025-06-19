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
    public class EmployeeDataUI : MonoBehaviour
    {
        private Image _employeePicture;

        private TextMeshProUGUI _employeeRoleText;
        private TextMeshProUGUI _employeeLevelText;
        private TextMeshProUGUI _employeeSabotageText;
        private TextMeshProUGUI _employeeSalaryText;

        private EmployeeData _currentEmployeeData; // Datos del empleado actual

        private const string PICTURE_DEFAUT_PATH = "Sprites/Employee/CookPicturePH"; // Ruta base de las imágenes de los empleados

        private void Awake()
        {
            _employeePicture = this.transform.Find("EmployeePicture").GetComponent<Image>();
            _employeeRoleText = this.transform.Find("EmployeeData_Info/DataInfo_Role/Info").GetComponent<TextMeshProUGUI>();
            _employeeLevelText = this.transform.Find("EmployeeData_Info/DataInfo_Level/Info").GetComponent<TextMeshProUGUI>();
            _employeeSabotageText = this.transform.Find("EmployeeData_Info/DataInfo_Sabotage/Info").GetComponent<TextMeshProUGUI>();
            _employeeSalaryText = this.transform.Find("EmployeeData_Info/DataInfo_Salary/Info").GetComponent<TextMeshProUGUI>();
        }

        //Cargar los datos del empleado en la UI
        public void LoadEmployeeData(EmployeeData employeeData)
        {
            Debug.Log($"Loading employee data for: {employeeData.id}");

            _currentEmployeeData = employeeData;

            if (employeeData == null)
            {
                Debug.LogError("Employee data is null.");
                return;
            }

            string picturePath = string.IsNullOrEmpty(employeeData.picturePath) ? PICTURE_DEFAUT_PATH : employeeData.picturePath;

            _employeePicture.sprite = Resources.Load<Sprite>(picturePath);
            _employeeRoleText.text = employeeData.role.ToFriendlyString();
            _employeeLevelText.text = employeeData.level.ToFriendlyString();
            _employeeSabotageText.text = employeeData.GetSabogageChance().ToString();
            _employeeSalaryText.text = employeeData.GetSalary().ToString("C2"); // Formato de moneda
        }
    }
}