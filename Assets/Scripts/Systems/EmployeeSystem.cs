using MiseEnPlace.Core;
using UnityEngine;
using MiseEnPlace.Data;

namespace MiseEnPlace.Systems
{
    public class EmployeeSystem : MonoBehaviour
    {
        void Start()
        {
            // Example: hire a Novato chef
            var newEmp = new EmployeeData
            {
                id = System.Guid.NewGuid().ToString(),
                role = EmployeeRole.Cook,
                level = EmployeeLevel.Novice,
            };
            GameManager.Instance.State.employees.Add(newEmp);
            Debug.Log("Hired employee: " + newEmp.id);
        }
        // TODO: implement risks, firing, sabotage events
    }
}
