using System;
using MiseEnPlace.Utilities;

namespace MiseEnPlace.Data
{
    [Serializable]
    public class EmployeeData
    {
        private const float BASE_SALARY = 100f;

        public string id;
        public string picturePath; // Ruta de la imagen del empleado
        public EmployeeRole role; // Rol del empleado (Cocinero, Camarero, etc.)
        public EmployeeLevel level; // Nivel del empleado (1, 2, 3, etc.)
        public bool isSaboteur = false;  // Indica si el empleado es un saboteador
        public float sabotageChance = 0.05f; // Probabilidad base de sabotaje por hora
        public float suspicion = 0f; // Nivel de sospecha del empleado
        public bool isHired = false; // Indica si el empleado ha sido contratado

        public SerializableVector3 position; // Posición del empleado en el juego

        public float GetSabogageChance()
        {
            //TODO: Esto es una probabilidad base, posiblemente se deba ajustar según otros factores, ya que depende del nivel del empleado y otros factores
            return sabotageChance * (1 + 0.1f * ((int)level - 1));
        }

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
