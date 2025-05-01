using UnityEngine;
using MiseEnPlace.Data;
using MiseEnPlace.Utilities;
using MiseEnPlace.Systems;

namespace MiseEnPlace.Core
{
    public class GameManager : MonoBehaviour
    {
        private EmployeeSystem _employeeSystem;
        private MachineSystem _machineSystem;
        private SabotageSystem _sabotageSystem;

        public static GameManager Instance { get; private set; }

        public GameState State { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                AddSystems();

                DontDestroyOnLoad(gameObject);
                // Load state
                State = SaveSystem.Load();

                if (State.machines.Count == 0)
                {
                    State.machines.Add(new MachineData { id = System.Guid.NewGuid().ToString(), baseFailRate = 0.05f });
                }
            }
            else Destroy(gameObject);
        }

        private void AddSystems()
        {
            _employeeSystem = gameObject.AddComponent<EmployeeSystem>();
            _machineSystem = gameObject.AddComponent<MachineSystem>();
            _sabotageSystem = gameObject.AddComponent<SabotageSystem>();
        }

        void OnApplicationQuit()
        {
            SaveSystem.Save(State);
        }
    }
}
