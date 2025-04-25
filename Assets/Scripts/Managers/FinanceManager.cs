using UnityEngine;

namespace MiseEnPlace.Core.Managers
{
    public class FinanceManager : MonoBehaviour
    {
        private FinanceManager() { }

        public static FinanceManager Instance { get; private set; }

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