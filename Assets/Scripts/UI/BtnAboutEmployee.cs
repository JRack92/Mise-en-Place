using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MiseEnPlace.Data;

using MiseEnPlace.Utilities;
using MiseEnPlace.Core;

namespace MiseEnPlace.UI
{
    public class BtnAboutEmployee : BtnUI
    {
        private Image _image;
        private TextMeshProUGUI _textLevel;
        private TextMeshProUGUI _textSalary;

        private EmployeeData _employeeData;

        void OnEnable()
        {
            _image = this.transform.Find("Pincture").GetComponent<Image>();
            _textLevel = this.transform.Find("Level/TextLevel").GetComponent<TextMeshProUGUI>();
            _textSalary = this.transform.Find("Salary/TextSalary").GetComponent<TextMeshProUGUI>();

            if (_image == null || _textLevel == null || _textSalary == null)
            {
                Debug.LogError("Required components not found on " + gameObject.name);
            }
        }

        private void Awake()
        {
            AddEventClick(() =>
            {
                GameManager.Instance.UIManager.UIPanelEmployee.LoadDataEmployeeUI(_employeeData);
            });
        }

        /// <summary>
        /// Sets the employee information for the button.
        /// </summary>
        /// <param name="sprite">Employee Picture</param>
        /// <param name="level">Employee Level</param>
        /// <param name="salary">Employee Salary</param>
        /// <param name="employeeId">Employee ID</param>
        public void SetEmployeeInfo(EmployeeData employeeData, Sprite sprite)
        {
            _employeeData = employeeData;

            if (sprite != null)
            {
                _image.sprite = sprite;
            }

            _textLevel.text = _employeeData.level.ToFriendlyString();
            _textSalary.text = _employeeData.GetSalary().ToString();
        }
    }
}