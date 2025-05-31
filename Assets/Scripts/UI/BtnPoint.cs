using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiseEnPlace.UI
{
    public class BtnPoint : BtnUI
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private TextMeshProUGUI _titleText;

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

        public void SetTitle(string title)
        {
            if (_titleText != null)
            {
                _titleText.text = title;
            }
        }
    }
}