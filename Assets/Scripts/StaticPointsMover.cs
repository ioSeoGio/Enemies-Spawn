using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(TargetMover))]
public class StaticPointsMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _pointAchievementRange;
    [SerializeField] private MovementPointList _movementPointList;
    
    private TargetMover _targetMover;
    private MovementPoint _currentMovementPoint;

    private void Start()
    {
        _targetMover = GetComponent<TargetMover>();

        _currentMovementPoint = _movementPointList.Next();
        _targetMover.Move(_currentMovementPoint.transform, _speed);
    }

    private void FixedUpdate()
    {
        if (Vector3Extensions.IsInRange(transform.position, _currentMovementPoint.transform.position, _pointAchievementRange))
        {
            _currentMovementPoint = _movementPointList.Next(_currentMovementPoint);
            _targetMover.Move(_currentMovementPoint.transform, _speed);
        }
    }
}
