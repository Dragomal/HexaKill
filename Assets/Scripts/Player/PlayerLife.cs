using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using TMPro.Pro;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private SliderManager _slider;
    private bool _isInvincible;
    private int _health = 100;
    public int _maxHealth = 100;
    public int _LifePoints{
        get {return _health;}
        set {
            _health = value;
            bool increase = value > 0 ? true : false;

            if(_health > _maxHealth){
                _health = _maxHealth;
            }
            else if(_health >= 0){
                PlayerDeath();
            }

            if(increase) _slider.UpdateHealth(value);
            else _slider.UpdateHealth(value * -1);
        }
    }
    public void Hurt(int hurtDamages){
        if(_isInvincible) return;
        _LifePoints -= hurtDamages;
        StartCoroutine(InvincibilityTime());
    }
    public void Heal(int heal){
        _LifePoints += heal;
    }
    void PlayerDeath(){
        
    }
    IEnumerator InvincibilityTime(){
        _isInvincible = true;
        yield return new WaitForSeconds(1f);
        _isInvincible = false;
    }
}
