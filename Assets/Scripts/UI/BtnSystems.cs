using MiseEnPlace.Data;
using MiseEnPlace.Utilities;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiseEnPlace.UI
{
    public class BtnSystems : BtnUI
    {
        private TextMeshProUGUI _title;
        private Image _icon;
        private TextMeshProUGUI _count;
        private Image _alert;

        [SerializeField] private BtnSystemType _btnSystemType;

        private void Awake()
        {
            //load all components
            _title = transform.Find("Title").GetComponent<TextMeshProUGUI>();
            _icon = transform.Find("Icon").GetComponent<Image>();
            _count = transform.Find("Icon/Count").GetComponent<TextMeshProUGUI>();
            _alert = transform.Find("Icon/Alert").GetComponent<Image>();
        }

        public void ShowAlert()
        {
            if (_alert != null)
            {
                _alert.gameObject.SetActive(true);
            }
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