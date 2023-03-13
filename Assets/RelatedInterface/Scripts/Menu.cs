using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

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
