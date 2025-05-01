using MiseEnPlace.Core;
using MiseEnPlace.Data;
using System.Collections.Generic;
using UnityEngine;

namespace MiseEnPlace.Systems
{
    public class SabotageSystem : GSystem
    {

        private float _sabotageTimer = 0f;
        private float _checkInterval = 60f; // Verifica cada 60 segundos

        void Update()
        {
            _sabotageTimer += Time.deltaTime;
            if (_sabotageTimer >= _checkInterval)
            {
                _sabotageTimer = 0f;
                CheckForSabotage();
            }
        }

        void CheckForSabotage()
        {
            List<EmployeeData> employees = GameManager.Instance.State.employees;
            foreach (EmployeeData emp in employees)
            {
                if (emp.isSaboteur && Random.value < emp.sabotageChance)
                {
                    TriggerSabotage(emp);
                    break; // Solo un sabotaje por verificación
                }
            }
        }

        void TriggerSabotage(EmployeeData saboteur)
        {
            List<MachineData> machines = GameManager.Instance.State.machines;
            if (machines.Count == 0) return;

            // Selecciona una máquina aleatoria funcional
            List<MachineData> functionalMachines = machines.FindAll(m => m.isFunctional);
            if (functionalMachines.Count == 0) return;

            MachineData targetMachine = functionalMachines[Random.Range(0, functionalMachines.Count)];
            targetMachine.isFunctional = false;

            // Reduce la reputación
            GameManager.Instance.State.reputation = Mathf.Max(0, GameManager.Instance.State.reputation - 10);

            Debug.Log($"¡Sabotaje! El empleado {saboteur.id} ha saboteado la máquina {targetMachine.id}.");
        }

    }
}