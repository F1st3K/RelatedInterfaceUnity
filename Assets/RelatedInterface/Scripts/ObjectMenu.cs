using System;
using TMPro;
using TMPro.Examples;
using UnityEngine;

namespace RelatedInterface.Scripts
{
    public class ObjectMenu : MonoBehaviour
    {
        [SerializeField] private GameObject gameObject;
        
        private TMP_Text _nameObject;

        public void Awake()
        {
            _nameObject = GetComponentInChildren<TMP_Text>();
            _nameObject.text = gameObject.name;
        }
    }
}