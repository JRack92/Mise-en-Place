using UnityEngine;

namespace MiseEnPlace.Core.Managers
{
    public class EmployeeManager : MonoBehaviour
    {
        private EmployeeManager() { }

        public static EmployeeManager Instance { get; private set; }

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