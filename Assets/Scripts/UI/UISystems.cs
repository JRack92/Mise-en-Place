using MiseEnPlace.Data;
using UnityEngine;

namespace MiseEnPlace.UI
{
    public class UISystems : MonoBehaviour
    {
        [SerializeField] private CookBtnSystem _cookBtnSystem;
        [SerializeField] private WaiterBtnSystem _waiterBtnSystem;

        public CookBtnSystem CookBtnSystem => _cookBtnSystem;
        public WaiterBtnSystem WaiterBtnSystem => _waiterBtnSystem;

        public void AlertSabotage(EmployeeData employeeData)
        {
            if (employeeData == null) return;

            if (employeeData.role == Utilities.EmployeeRole.Cook)
                _cookBtnSystem.ShowAlert();
            else
                _waiterBtnSystem.ShowAlert();
        }
    }
}