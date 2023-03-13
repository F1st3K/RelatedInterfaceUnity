using UnityEngine;
using UnityEngine.UI;

namespace RelatedInterface.Scripts
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Toggle hideButton;

        public void Awake()
        {
            hideButton.onValueChanged.AddListener(delegate { SwitchShow();});
        }

        public void Update()
        {
        
        }

    
        private void SwitchShow()
        {
            var vector = rectTransform.anchoredPosition;
            vector.x = -vector.x;
            rectTransform.anchoredPosition = vector;
        }
    }
}
