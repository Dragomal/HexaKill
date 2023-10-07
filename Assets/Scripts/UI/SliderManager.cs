using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerStats _playerStats;
    void Start(){
        _slider.value = _playerStats._maxHealth;
    }
    public void UpdateHealth(int healthValue){
        _slider.value = healthValue;
    }
}
