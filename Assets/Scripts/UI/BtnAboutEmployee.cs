using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MiseEnPlace.UI
{
    public class BtnAboutEmployee : BtnUI
    {
        private Image _image;
        private TextMeshProUGUI _textLevel;
        private TextMeshProUGUI _textSalary;

        private string _employeeId;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _textLevel = transform.Find("TextLevel").GetComponent<TextMeshProUGUI>();
            _textSalary = transform.Find("TextSalary").GetComponent<TextMeshProUGUI>();

            if (_image == null || _textLevel == null || _textSalary == null)
            {
                Debug.LogError("Required components not found on " + gameObject.name);
            }
        }

        /// <summary>
        /// Sets the employee information for the button.
        /// </summary>
        /// <param name="sprite">Employee Picture</param>
        /// <param name="level">Employee Level</param>
        /// <param name="salary">Employee Salary</param>
        /// <param name="employeeId">Employee ID</param>
        public void SetEmployeeInfo(Sprite sprite, int level, int salary, string employeeId)
        {
            _employeeId = employeeId;

            if (_image != null)
            {
                _image.sprite = sprite;
            }
            if (_textLevel != null)
            {
                _textLevel.text = "Level: " + level;
            }
            if (_textSalary != null)
            {
                _textSalary.text = "Salary: $" + salary;
            }
        }
    }
}