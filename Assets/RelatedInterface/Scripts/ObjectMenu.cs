using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RelatedInterface.Scripts
{
    public class ObjectMenu : MonoBehaviour
    {
        [SerializeField] private GameObject someObject;
        [SerializeField] private GameObject prefab;
        
        private TMP_Text _nameObject;
        private Toggle _selected;
        private Toggle _showed;

        public bool Selected => _selected.isOn;
        public GameObject Prefab => prefab;

        public void Awake()
        {
            _nameObject = GetComponentInChildren<TMP_Text>();
            var toggles = GetComponentsInChildren<Toggle>();
            _showed = toggles[0];
            _selected = toggles[1];
            
            _nameObject.text = someObject.name;
            _showed.onValueChanged.AddListener(delegate {SwitchShow();});
        }

        public void SetAlpha(float value)
        {
            if (value is < 0 or > 1)
                throw new ArgumentException("Invalid alpha format");

            if (someObject.TryGetComponent(out Renderer component))
            {
                var material = component.material;
                var color = material.color;
                color.a = value;
                material.color = color;
            }
        }

        public void SetSelected(bool value)
        {
            _selected.isOn = value;
        }

        public void SetShowed(bool value)
        {
            _showed.isOn = value;
        }

        private void SwitchShow()
        {
            someObject.SetActive(_showed.isOn);
        }
    }
}