using UnityEngine;


namespace MiseEnPlace.UI
{
    public abstract class BtnUI : MonoBehaviour
    {
        [SerializeField] private AudioClip _clickSound;

        public virtual void OnClick()
        {
            if (_clickSound != null)
            {
                //AudioManager.Instance.PlaySound(_clickSound);
            }
        }
    }
}