using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField, Range(1, 500)] public int _maxHealth = 100;
    [SerializeField, Range(0, 5)] public float _attackSpeed = 0.75f;
    [SerializeField, Range(1, 50)] public float _movementSpeed = 10;
    [SerializeField, Range(0, 5)] public float _invincibleTime = 0.5f;
}
