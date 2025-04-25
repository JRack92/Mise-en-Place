using UnityEngine;

namespace MiseEnPlace.Core.Managers
{
    public class DecorManager : MonoBehaviour
    {
        private DecorManager() { }

        public static DecorManager Instance { get; private set; }

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