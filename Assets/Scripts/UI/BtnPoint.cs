using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiseEnPlace.UI
{
    public class BtnPoint : BtnUI
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _countText;

        public void UpdateCount(float count)
        {
            if (_countText != null)
            {
                _countText.text = count.ToString();
            }
        }

        public void SetIcon(Sprite icon)
        {
            if (_iconImage != null)
            {
                _iconImage.sprite = icon;
            }
        }
    }
}