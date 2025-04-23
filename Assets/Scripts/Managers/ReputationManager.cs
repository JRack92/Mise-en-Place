using System.Collections;
using UnityEngine;

namespace MiseEnPlace.Core.Managers
{
    public class ReputationManager : MonoBehaviour
    {

        private ReputationManager() { }

        public static ReputationManager Instance { get; private set; }

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