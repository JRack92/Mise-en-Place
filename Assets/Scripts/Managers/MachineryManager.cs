using System.Collections;
using UnityEngine;

namespace MiseEnPlace.Core.Managers
{
    public class MachineryManager : MonoBehaviour
    {
        private MachineryManager() { }

        public static MachineryManager Instance { get; private set; }

        private void Awake()
        {
            GetInstance();
        }

        private void GetInstance()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}