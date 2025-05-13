using MiseEnPlace.Core;
using UnityEngine;

namespace MiseEnPlace.UI
{
    public class UIPoints : MonoBehaviour
    {
        [SerializeField] private BtnPoint _countMoneyUI;
        [SerializeField] private BtnPoint _countReputacionUI;
        [SerializeField] private BtnPoint _countSabotageUI;

        public BtnPoint CountMoneyUI => _countMoneyUI;
        public BtnPoint CountReputacionUI => _countReputacionUI;
        public BtnPoint CountSabotageUI => _countSabotageUI;

        public void UpdateCountMoney(int count)
        {
            if (_countMoneyUI != null)
            {
                _countMoneyUI.UpdateCount(count);
            }
        }

        public void UpdateCountReputacion(int count)
        {
            if (_countReputacionUI != null)
            {
                _countReputacionUI.UpdateCount(count);
            }
        }

        public void UpdateCountSabotage()
        {
            _countSabotageUI.UpdateCount(GameManager.Instance.State.GetTotalSuspicion());
        }
    }
}