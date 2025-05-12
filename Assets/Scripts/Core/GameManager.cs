using UnityEngine;
using MiseEnPlace.Data;
using MiseEnPlace.Utilities;
using MiseEnPlace.Systems;
using MiseEnPlace.UI;

namespace MiseEnPlace.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public EmployeeSystem EmployeeSystem { get; private set; }
        public MachineSystem MachineSystem { get; private set; }
        public SabotageSystem SabotageSystem { get; private set; }
        public UIManager UIManager { get; private set; }

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
            EmployeeSystem = gameObject.AddComponent<EmployeeSystem>();
            MachineSystem = gameObject.AddComponent<MachineSystem>();
            SabotageSystem = gameObject.AddComponent<SabotageSystem>();
            UIManager = FindAnyObjectByType<UIManager>();
        }

        void OnApplicationQuit()
        {
            SaveSystem.Save(State);
        }
    }
}
