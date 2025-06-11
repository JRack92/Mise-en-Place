using MiseEnPlace.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace MiseEnPlace.UI
{
    public abstract class BtnUI : MonoBehaviour
    {
        [SerializeField] private AudioClip _clickSound;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();

            if (_button == null)
            {
                Debug.LogError("Button component not found on " + gameObject.name);
                return;
            }

            _button.onClick.AddListener(PlayClickSound);
        }

        public void AddEventClick(UnityAction eventClick)
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }

            _button.onClick.AddListener(eventClick);
        }

        public void PlayClickSound()
        {
            Debug.Log("Playing click sound for " + gameObject.name);
            if (_clickSound != null)
            {
                GameManager.Instance.SoundManager.PlaySound(_clickSound);
            }
        }
    }
}