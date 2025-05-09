using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiseEnPlace.UI
{
    public abstract class BtnSystems : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _title;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TextMeshProUGUI _count;

        [SerializeField]
        private Image _alert;

        public void ShowAlert()
        {
            if (_alert != null)
            {
                _alert.gameObject.SetActive(true);
            }
        }

        public void ShowDashboard()
        {
        }

        public void UpdateCount(int count)
        {
            if (_count != null)
            {
                _count.text = count.ToString();
            }
        }
    }
}