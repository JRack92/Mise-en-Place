using System;
using MiseEnPlace.Utilities;

namespace MiseEnPlace.Data
{
    [Serializable]
    public class EmployeeData
    {
        private const float BASE_SALARY = 100f;

        public string id;
        public EmployeeRole role;
        public EmployeeLevel level;
        public bool isSaboteur = false;  // Indica si el empleado es un saboteador
        public float sabotageChance = 0.05f; // Probabilidad base de sabotaje por hora
        public float suspicion = 0f; // Nivel de sospecha del empleado

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
