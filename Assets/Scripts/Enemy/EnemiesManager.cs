using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField, Range(1,10)]private float _timeEnemySpawn;
    [SerializeField] private List<GameObject> _enemiesList = new List<GameObject>();
    [SerializeField] public GameObject _player;
    [SerializeField] private BoxCollider2D _interBoxSpawn, _outerBoxSpawn;
    private float _timerSpawnReset;
    void Start(){
        _timerSpawnReset = _timeEnemySpawn;
        InstantiateEnemy();
    }
    void InstantiateEnemy(){
        float xMinPosOuter = _player.transform.position.x - (_outerBoxSpawn.size.x / 2);
        float xMaxPosOuter = _player.transform.position.x + (_outerBoxSpawn.size.x / 2);
        float yMinPosOuter = _player.transform.position.y - (_outerBoxSpawn.size.y / 2);
        float yMaxPosOuter = _player.transform.position.y + (_outerBoxSpawn.size.y / 2);

        float xPosInter = _player.transform.position.x + (_interBoxSpawn.size.x / 2);
        float yPosInter = _player.transform.position.y + (_interBoxSpawn.size.y / 2);   

        float xPosSpawn = Random.Range(xMinPosOuter, xMaxPosOuter);
        float yPosSpawn = Random.Range(yMinPosOuter, yMaxPosOuter);

        while(!(xPosSpawn <= -xPosInter || xPosSpawn >= xPosInter || yPosSpawn >= yPosInter || yPosSpawn <= -yPosInter)){
            xPosSpawn = Random.Range(xMinPosOuter, xMaxPosOuter);
            yPosSpawn = Random.Range(yMinPosOuter, yMaxPosOuter);
        }

        Vector2 enemySpawnPosition = new Vector2(xPosSpawn, yPosSpawn);
        GameObject enemyInstantiate = Instantiate(_enemiesList[0], enemySpawnPosition, Quaternion.identity, transform);
    }
    void Update(){
        _timerSpawnReset -= Time.deltaTime;
        if(_timerSpawnReset <= 0){
            InstantiateEnemy();
            _timerSpawnReset = _timeEnemySpawn;
        }
    }
}
