using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RelatedInterface.Scripts
{
    public class Menu : MonoBehaviour
    {
        private List<ObjectMenu> _listObjects;
        private RectTransform _rectTransform;
        private Toggle _hideMenuToggle;
        private Toggle _selectAllToggle;
        private Toggle _hideObjectsToggle;
        private Button _transparency10;
        private Button _transparency30;
        private Button _transparency50;
        private Button _transparency75;
        private Button _transparency100;
        private GameObject _content;


        public void Awake()
        {
            _listObjects = new List<ObjectMenu>();
            GetAllComponents();
            AddAllListeners();
            foreach (Transform child in _content.transform)
            {
                if (child.TryGetComponent<ObjectMenu>(out var obj))
                    _listObjects.Add(obj);
            }
        }

        private void GetAllComponents()
        {
            _rectTransform = GetComponent<RectTransform>();
            var toggles = GetComponentsInChildren<Toggle>();
            _hideMenuToggle = toggles[0];
            _selectAllToggle = toggles[1];
            _hideObjectsToggle = toggles[2];
            var buttons = GetComponentsInChildren<Button>();
            _transparency10 = buttons[0];
            _transparency30 = buttons[1];
            _transparency50 = buttons[2];
            _transparency75 = buttons[3];
            _transparency100 = buttons[4];
            var scroll = GetComponentInChildren<ScrollRect>();
            var viewPort = scroll.GetComponentInChildren<CanvasRenderer>();
            _content = viewPort.GetComponentInChildren<ContentSizeFitter>().gameObject;
        }

        private void AddAllListeners()
        {
            _hideMenuToggle.onValueChanged.AddListener(delegate { SwitchShow();});
            _selectAllToggle.onValueChanged.AddListener(delegate { SelectAll();});
            _hideObjectsToggle.onValueChanged.AddListener(delegate { HideObjects();});
            _transparency10.onClick.AddListener(delegate { SetAlphaSelected(0.10f);});
            _transparency30.onClick.AddListener(delegate { SetAlphaSelected(0.30f);});
            _transparency50.onClick.AddListener(delegate { SetAlphaSelected(0.50f);});
            _transparency75.onClick.AddListener(delegate { SetAlphaSelected(0.75f);});
            _transparency100.onClick.AddListener(delegate { SetAlphaSelected(1.00f);});
        }
    
        private void SwitchShow()
        {
            var vector = _rectTransform.anchoredPosition;
            vector.x = -vector.x;
            _rectTransform.anchoredPosition = vector;
        }

        private void SelectAll()
        {
            foreach (var objectMenu in _listObjects)
            {
                objectMenu.SetSelected(_selectAllToggle.isOn);
            }
        }

        private void HideObjects()
        {
            foreach (var objectMenu in _listObjects)
            {
                if (objectMenu.Selected)
                    objectMenu.SetShowed(_hideObjectsToggle.isOn);
            }
        }

        private void SetAlphaSelected(float value)
        {
            foreach (var objectMenu in _listObjects)
            {
                if (objectMenu.Selected)
                    objectMenu.SetAlpha(value);
            }
        }
    }
}
