using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Vector3 _movementDirection;
    [SerializeField] private float _speed;

    public Vector3 MovementDirection => _movementDirection;
    public float Speed => _speed;
}
