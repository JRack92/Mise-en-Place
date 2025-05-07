using MiseEnPlace.Core;
using MiseEnPlace.Data;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace MiseEnPlace.Systems
{
    public class MachineSystem : GSystem
    {
        private float hoursAccumulator = 0f;

        void Update()
        {
            // TODO: check machine failure based on usage and employee levels
            GameState state = GameManager.Instance.State;
            if (state.machines.Count == 0) return;
            MachineData machine = state.machines[0];
            if (!machine.isFunctional) return;

            // Acumular horas de uso
            hoursAccumulator += Time.deltaTime;
            if (hoursAccumulator >= 1f)
            { // cada hora simulada
                machine.usageHours += 1f;
                hoursAccumulator = 0f;

                // Calcular probabilidad de fallo
                int level = state.employees.Count > 0 ? (int)state.employees[0].level : 1;
                // Ajusta failRate: base - (nivelEmpleado-1)*0.01 + usageHours*0.0005
                float failRate = machine.baseFailRate - (level - 1) * 0.01f + machine.usageHours * 0.0005f;
                if (Random.value < failRate)
                {
                    machine.isFunctional = false;
                    // Reducir reputación
                    state.reputation = Mathf.Max(0, state.reputation - 5);
                    Debug.Log("Machine " + machine.id + " ha fallado.");

                    // Notify sabotage logic if applicable
                    EmployeeData saboteur = state.employees.FirstOrDefault(e => e.isSaboteur);
                    if (saboteur != null)
                    {
                        GameManager.Instance.EmployeeSystem.OnMachineSabotaged(machine.id, saboteur.id);
                    }
                }
            }
        }
    }
}
