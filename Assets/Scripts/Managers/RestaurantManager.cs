using UnityEngine;

namespace MiseEnPlace.Core.Managers
{
    public class RestaurantManager : MonoBehaviour
    {
        private RestaurantManager() { }

        public static RestaurantManager Instance { get; private set; }
        public FinanceManager FinanceManager { get; private set; }
        public ReputationManager ReputationManager { get; private set; }
        public EmployeeManager EmployeeManager { get; private set; }
        public MachineryManager MachineryManager { get; private set; }
        public DecorManager DecorManager { get; private set; }

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