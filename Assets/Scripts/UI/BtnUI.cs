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

        private static Color DefaultSelectedColor = new Color(0.2f, 0.6f, 1f, 1f); // Azul seleccionado
        private static Color DefaultUnselectedColor = Color.white; // Color no seleccionado

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

        //como defino una variable opcional para una funcion.

        public void SelectedButton(Color selectedColor)
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            // Cambia el color del botón a seleccionado
            _button.GetComponent<Image>().color = selectedColor;
        }

        public void SelectedButton()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            // Cambia el color del botón a seleccionado
            _button.GetComponent<Image>().color = DefaultUnselectedColor;
        }

        public void UnselectedButton(Color UnselectedColor)
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            // Cambia el color del botón a seleccionado
            _button.GetComponent<Image>().color = UnselectedColor;
        }

        public void UnselectedButton()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            // Cambia el color del botón a seleccionado
            _button.GetComponent<Image>().color = DefaultSelectedColor;
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