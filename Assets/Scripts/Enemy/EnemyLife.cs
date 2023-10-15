using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private int _health;
    private CanvasManager _canvasManager;
    void Awake(){
        EnemyStats enemyStats = GetComponent<EnemyStats>();
        _health = enemyStats._health;
        _canvasManager = GetComponent<CanvasManager>();
    }
    public void GetHurt(int amountDamages){
        _health -= amountDamages;
        _canvasManager.ModifySlider(_health);
        if(_health <= 0){
            Death();
        }
    }
    void Death(){
        EnemiesManager enemiesManager = GetComponentInParent<EnemiesManager>();
        enemiesManager.EnemyDeath(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
