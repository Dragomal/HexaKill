using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _backGrounds = new List<GameObject>();
    [SerializeField] private GameObject _backgroundPrefab;
    [SerializeField] private Transform _backgroundParent;
    private float backgroundsScale;
    void Start(){
        _backgroundParent = transform;
        backgroundsScale = _backgroundPrefab.transform.localScale.x;
        InstantiateBackgrounds(transform);
    }
    public void InstantiateBackgrounds(Transform originTransform){
        Vector2 originPosition = new Vector2(originTransform.position.x, originTransform.position.y);
        for (float y = originPosition.y + backgroundsScale; y >= originPosition.y - backgroundsScale - 1; y -= backgroundsScale){
            for (float x = originPosition.x - backgroundsScale; x <= originPosition.x + backgroundsScale + 1; x += backgroundsScale){
                if(CheckBackgrounds(new Vector2(x, y)))
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
    public void ExitBackground(GameObject backgroundGameobject){
        _backGrounds.Remove(backgroundGameobject);
        backgroundGameobject.SetActive(false);
    }
}
