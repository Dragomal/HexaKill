using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField, Range(1,10)] private float _timeEnemySpawn;
    [SerializeField] private List<GameObject> _enemiesTypeList = new List<GameObject>(); 
    [SerializeField] public GameObject _player;
    [SerializeField] private BoxCollider2D _interBoxSpawn, _outerBoxSpawn;
    private List<List<GameObject>> _enemyWaitTypeList = new List<List<GameObject>>();
    private List<List<GameObject>> _enemyAliveTypeList = new List<List<GameObject>>();
    private List<GameObject> _enemyList = new List<GameObject>();
    private float _timerSpawnReset;
    void Start(){
        _timerSpawnReset = _timeEnemySpawn;
        for (int i = 0; i < _enemiesTypeList.Count; i++){
            _enemyWaitTypeList.Add(_enemyList);
            _enemyAliveTypeList.Add(_enemyList);
        }
        InstantiateEnemy(0);
    }
    void InstantiateEnemy(int enemyTypeIndex){
        //Génère une poisition aléatoire pour l'enemy
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

        //Choisi entre prendre un enemi qui est en attente ou en créer un nouveau
        if(_enemyWaitTypeList[enemyTypeIndex].Count == 0){
            //Créer un enemi et l'ajoute a la liste des enemies en vie
            GameObject enemyInstantiate = Instantiate(_enemiesTypeList[enemyTypeIndex], enemySpawnPosition, Quaternion.identity, transform);
            _enemyAliveTypeList[enemyTypeIndex].Add(enemyInstantiate);
            //! Si je Debug.Log() le count de _enemyWaitTypeList[enemyTypeIndex], cela me renvoie 1 alors 
            //! que je n'ajoute qu'à la liste _enemyAliveTypeList[enemyTypeIndex]
        }
        else{
            //Prend un enemi qui est en attente et le remet "en vie"
            GameObject enemyToRevive = _enemyWaitTypeList[enemyTypeIndex][0];
            _enemyAliveTypeList[enemyTypeIndex].Add(enemyToRevive);
            _enemyWaitTypeList[enemyTypeIndex].Remove(enemyToRevive);
            enemyToRevive.transform.position = enemySpawnPosition;
            enemyToRevive.SetActive(true);
        }
        
    }
    public void EnemyDeath(GameObject enemy){
        EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
        _enemyWaitTypeList[enemyStats.enemyType].Add(enemy);
        _enemyAliveTypeList[enemyStats.enemyType].Remove(enemy);
    }
    void Update(){
        _timerSpawnReset -= Time.deltaTime;
        if(_timerSpawnReset <= 0){
            InstantiateEnemy(0);
            _timerSpawnReset = _timeEnemySpawn;
        }
    }
}
