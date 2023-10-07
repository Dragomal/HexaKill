using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] public List<GameObject> _enemiesInRangeList = new List<GameObject>();
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _instantationManager;    
    private float _attackSpeed;
    private float _timerToShoot;
    void Start(){
        PlayerStats _playerStats = GetComponent<PlayerStats>();
        _attackSpeed = _playerStats._attackSpeed;
        _timerToShoot = _attackSpeed;
    }
    void FixedUpdate(){
        _timerToShoot -= Time.fixedDeltaTime;
        if(_timerToShoot <= 0){
            SearchNearestEnemy();
            _timerToShoot = _attackSpeed;
        }
    }
    void SearchNearestEnemy(){
        if(_enemiesInRangeList.Count == 0) return;
        GameObject nearestEnemy = _enemiesInRangeList[0];
        foreach (GameObject enemy in _enemiesInRangeList){
            if(Vector2.Distance(enemy.transform.position, transform.position) < Vector2.Distance(nearestEnemy.transform.position, transform.position)){
                nearestEnemy = enemy;
            }
        }
        ShootToTarget(nearestEnemy.transform);
    }
    void ShootToTarget(Transform enemyToShoot){
        GameObject bulletInstantation = Instantiate(_bulletPrefab, transform.position, Quaternion.identity, _instantationManager);
        BulletBehaviour bulletBehaviour = bulletInstantation.GetComponent<BulletBehaviour>();
        bulletBehaviour.GoToEnemy(enemyToShoot);
    }
}
