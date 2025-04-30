using System;
using UnityEngine;
using MiseEnPlace.Systems;

namespace MiseEnPlace.Data
{
    [Serializable]
    public class EmployeeData
    {
        private const float BASE_SALARY = 100f;

        public string id;
        public EmployeeRole role;
        public EmployeeLevel level;

        public float GetSalary()
        {
            return BASE_SALARY * (1 + 0.5f * ((int)level - 1));
        }

        public float GetProductivity()
        {
            return 1 + 0.1f * ((int)level - 1);
        }
    }
}
