using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField, Range(1, 50)] public float _speed; 
    [SerializeField, Range(10, 1000)] public int _health;
    [SerializeField, Range(1, 100)] public int _damages;
    [SerializeField] public int enemyType;
    void Start(){
        
    }
}
