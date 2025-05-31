using MiseEnPlace.Data;

namespace MiseEnPlace.Gameplay
{
    public class Employee : Character
    {
        private EmployeeData _employeeData;

        void Update()
        {
            _employeeData.position = new SerializableVector3(transform.position);
        }


        public void SetEmployeeData(EmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
    }
}