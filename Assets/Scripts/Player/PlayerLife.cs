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
    private int _maxHealth;
    private float _invincibleTime;
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
    void Start(){
        PlayerStats _playerStats = GetComponent<PlayerStats>();
        _maxHealth = _playerStats._maxHealth;
        _invincibleTime =  _playerStats._invincibleTime;
        _LifePoints = _maxHealth;
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
        yield return new WaitForSeconds(_invincibleTime);
        _isInvincible = false;
    }
}
