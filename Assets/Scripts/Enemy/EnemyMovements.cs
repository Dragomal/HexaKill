using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovements : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _enemyRigibody2D;
    private EnemyStats _enemyStats;
    private float _enemySpeed;
    void Start(){
        _player = GameObject.FindWithTag("Player");
        _enemyRigibody2D = GetComponent<Rigidbody2D>();
        _enemyStats = GetComponent<EnemyStats>();
        _enemySpeed = _enemyStats._speed;
    }
    void FixedUpdate(){
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        _enemyRigibody2D.velocity = new Vector2(direction.x, direction.y) * _enemySpeed;
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player")){
            PlayerLife playerLife = other.GetComponent<PlayerLife>();
            playerLife.Hurt(_enemyStats._damages);
        }
    }
}
