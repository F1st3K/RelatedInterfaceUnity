using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RelatedInterface.Scripts
{
    public class ObjectMenu : MonoBehaviour
    {
        [SerializeField] private GameObject someObject;
        
        private TMP_Text _nameObject;
        private Toggle _selected;
        private Toggle _showed;

        public bool Selected => _selected.isOn;

        public void Awake()
        {
            _nameObject = GetComponentInChildren<TMP_Text>();
            _showed = GetComponentInChildren<Toggle>();
            _selected = GetComponentInChildren<Toggle>();
            
            _nameObject.text = someObject.name;
            _showed.onValueChanged.AddListener(delegate {SwitchShow();});
        }

        public void SetAlpha(byte value)
        {
            
        }

        public void SetSelected(bool value)
        {
            
        }

        public void SetShowed(bool value)
        {
            
        }

        private void SwitchShow()
        {
            someObject.SetActive(_selected.isOn);
        }
    }
}