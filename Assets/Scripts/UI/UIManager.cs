using UnityEngine;

namespace MiseEnPlace.UI
{
    public class UIManager : MonoBehaviour
    {
        public UISystems UISystems { get; private set; }
        public UIPoints UIPoints { get; private set; }

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            UISystems = FindAnyObjectByType<UISystems>();
            if (UISystems == null)
            {
                Debug.LogError("UISystems not found in the scene.");
                return;
            }

            UIPoints = FindAnyObjectByType<UIPoints>();
            if (UIPoints == null)
            {
                Debug.LogError("UIPoints not found in the scene.");
                return;
            }
        }
    }
}
