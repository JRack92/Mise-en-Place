using MiseEnPlace.Data;
using UnityEngine;
using MiseEnPlace.Core;

namespace MiseEnPlace.UI
{
    public class UISystems : MonoBehaviour
    {
        [SerializeField] private BtnSystems _employeeBtnSystem;

        public BtnSystems EmployeeBtnSystem => _employeeBtnSystem;

        private void Start()
        {
            _employeeBtnSystem.AddEventClick(() =>
            {
                GameManager.Instance.UIManager.OpenPanelEmployee();
            });
        }

        public void AlertSabotage(EmployeeData employeeData)
        {
            if (employeeData == null) return;

            _employeeBtnSystem.ShowAlert();
        }
    }
}