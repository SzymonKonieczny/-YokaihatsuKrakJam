using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HappinessSlider : MonoBehaviour
    {
        private Slider _slider;


        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void Set(float value)
        {
            _slider.value = value;
        }
    }
}
