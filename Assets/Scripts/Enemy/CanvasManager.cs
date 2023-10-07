using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Slider _lifeSlider;
    private int _health;
    void Awake(){
        EnemyStats enemyStats = GetComponent<EnemyStats>();
        _health = enemyStats._health;
        _lifeSlider.maxValue = _health;
        _lifeSlider.gameObject.SetActive(false);
    }
    public void ModifySlider(int enemyHealth){
        if(!_lifeSlider.IsActive()) _lifeSlider.gameObject.SetActive(true);
        _lifeSlider.value = enemyHealth;
    }
}
