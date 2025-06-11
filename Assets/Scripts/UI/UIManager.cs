using UnityEngine;
using System.Collections.Generic;
using MiseEnPlace.Core;
using MiseEnPlace.Data;

namespace MiseEnPlace.UI
{
    public class UIManager : MonoBehaviour
    {
        public UISystems UISystems { get; private set; }
        public UIPoints UIPoints { get; private set; }
        public UIPanelEmployee UIPanelEmployee { get; private set; }

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

            UIPanelEmployee = FindAnyObjectByType<UIPanelEmployee>(FindObjectsInactive.Include);
            if (UIPanelEmployee == null)
            {
                Debug.LogError("UIPanelEmployee not found in the scene.");
                return;
            }
        }

        /// <summary>
        /// Cierra el panel de empleados y volverá al menú principal.
        /// </summary>
        public void ClosePanelEmployee()
        {
            if (UIPanelEmployee != null)
            {
                UIPanelEmployee.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("UIPanelEmployee is not set. Cannot close the panel.");
            }
        }

        //Open panel employee with the list of employees
        public void OpenPanelEmployee()
        {            
            UIPanelEmployee.gameObject.SetActive(true);
        }
    }
}
