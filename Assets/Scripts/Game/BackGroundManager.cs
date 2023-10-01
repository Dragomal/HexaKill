using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _backGrounds = new List<GameObject>();
    [SerializeField] private List<GameObject> _waitList = new List<GameObject>();
    [SerializeField] private GameObject _backgroundPrefab;
    [SerializeField] private Transform _backgroundParent;
    private float _backgroundsScale;
    void Start(){
        _backgroundParent = transform;
        _backgroundsScale = _backgroundPrefab.transform.localScale.x;
        MoveBackgrounds(transform);
    }
    public void MoveBackgrounds(Transform originTransform){
        Vector2 originPosition = new Vector2(originTransform.position.x, originTransform.position.y);
        for (float y = originPosition.y + _backgroundsScale; y >= originPosition.y - _backgroundsScale - 1; y -= _backgroundsScale){
            for (float x = originPosition.x - _backgroundsScale; x <= originPosition.x + _backgroundsScale + 1; x += _backgroundsScale){
                
                if(CheckBackgrounds(new Vector2(x, y)) && _waitList.Count != 0){
                    _waitList[0].transform.position = new Vector2(x, y);
                    _waitList[0].SetActive(true);
                    _backGrounds.Add(_waitList[0]);
                    _waitList.Remove(_waitList[0]);
                }
                else if(CheckBackgrounds(new Vector2(x, y)) && _waitList.Count == 0)
                    _backGrounds.Add(Instantiate(_backgroundPrefab, new Vector2(x, y), Quaternion.identity, _backgroundParent));
                
            }
        }
    }
    bool CheckBackgrounds(Vector2 backgroundPosition){
        foreach (GameObject item in _backGrounds){
            if(backgroundPosition == new Vector2(item.transform.position.x, item.transform.position.y)){
                return false;
            }
        }
        return true;
    }
    public void ExitZoneTest(Transform newZoneTransform){
        List<GameObject> itemsToRemove = new List<GameObject>();
        foreach (GameObject item in _backGrounds){
            float distance = Vector3.Distance(newZoneTransform.position, item.transform.position);
            if(distance >= _backgroundsScale * 2){
                itemsToRemove.Add(item);
            }
        }
        foreach (GameObject item in itemsToRemove){
            _waitList.Add(item);
            _backGrounds.Remove(item);
            item.SetActive(false);
        }
    }
}
