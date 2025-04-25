using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private TargetMover _prefab;

    public Transform Target => _target;
    public float Speed => _speed;
    public TargetMover Prefab => _prefab;
}
