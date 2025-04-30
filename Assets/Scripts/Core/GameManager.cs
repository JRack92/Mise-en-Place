using UnityEngine;
using MiseEnPlace.Data;
using MiseEnPlace.Utilities;

namespace MiseEnPlace.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public GameState State { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
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

        void OnApplicationQuit()
        {
            SaveSystem.Save(State);
        }
    }
}
