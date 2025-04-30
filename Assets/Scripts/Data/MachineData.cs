using System;
using UnityEngine;

namespace MiseEnPlace.Data
{
    [Serializable]

    public class MachineData
    {
        public string id;
        public float usageHours;   // Horas acumuladas
        public float baseFailRate; // Ej. 0.05 (5%)
        public bool isFunctional = true;
    }
}