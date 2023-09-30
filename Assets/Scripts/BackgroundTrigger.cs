using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundTrigger : MonoBehaviour
{
    [SerializeField] private BackGroundManager _backgroundManager;
    void Awake(){
        _backgroundManager = GetComponentInParent<BackGroundManager>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("hitBackground");
            _backgroundManager.MoveBackgrounds(transform);
            _backgroundManager.ExitZoneTest(transform);
        }
    }
}
