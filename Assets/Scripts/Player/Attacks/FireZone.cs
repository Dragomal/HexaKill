using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireZone : MonoBehaviour
{
    [SerializeField] private PlayerAttack _playerAttack;
    private List<GameObject> _enemiesInRangeList = new List<GameObject>();
    void Start(){
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
