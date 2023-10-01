using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerLife _player;
    void Start(){
        _slider.value = _player._maxHealth;
    }
    public void UpdateHealth(int healthValue){
        _slider.value = healthValue;
    }
}
