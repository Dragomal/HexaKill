using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireZone : MonoBehaviour
{
    private List<GameObject> _enemiesInRangeList = new List<GameObject>();
    private PlayerAttack _playerAttack;
    private CircleCollider2D _fireZone;
    private float _rangeAttack;
    void Start(){
        _playerAttack = GetComponentInParent<PlayerAttack>();
        _fireZone = GetComponent<CircleCollider2D>();
        PlayerStats _playerStats = GetComponentInParent<PlayerStats>();
        _rangeAttack = _playerStats._rangeAttack;
        _fireZone.radius = _rangeAttack;

        _enemiesInRangeList = _playerAttack._enemiesInRangeList;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            _enemiesInRangeList.Add(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            _enemiesInRangeList.Remove(other.gameObject);
        }
    }
}
