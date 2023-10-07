using System.Collections;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField, Range(1, 20)] private int _bulletSpeed = 5;
    [SerializeField, Range(1, 1000)] private int _bulletDamages = 50;
    private Transform _enemyTransform;
    private Vector3 _directionToEnemy;
    void Awake(){
        StartCoroutine(BulletLife());
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            EnemyLife enemyLife = other.gameObject.GetComponent<EnemyLife>();
            enemyLife.GetHurt(_bulletDamages);
            Destroy(this.gameObject);
        }
    }
    public void GoToEnemy(Transform enemyToGo){
        _enemyTransform = enemyToGo;
        _directionToEnemy = _enemyTransform.position - transform.position;
    }
    void Update(){
        transform.position += _directionToEnemy * _bulletSpeed * Time.deltaTime;
    }
    IEnumerator BulletLife(){
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
