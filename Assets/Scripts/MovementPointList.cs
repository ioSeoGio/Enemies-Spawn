using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementPointList: MonoBehaviour
{
    [SerializeField] private List<MovementPoint> _movementPoints = new List<MovementPoint>();

    public MovementPoint Next()
    {
        MovementPointsNotEmptyCheck();

        return Next(_movementPoints[_movementPoints.Count - 1]);
    }

    public MovementPoint Next(MovementPoint oldMovementPoint)
    {
        MovementPointsNotEmptyCheck();
        int currentPointKey = _movementPoints.IndexOf(oldMovementPoint);
        
        if (currentPointKey == _movementPoints.Count - 1)
        {
            return _movementPoints[0];
        }

        return _movementPoints[++currentPointKey];
    }

    private void MovementPointsNotEmptyCheck()
    {
        if (_movementPoints.Count == 0)
        {
            throw new System.Exception("You must set at least one movement point");
        }
    }

    #if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _movementPoints.Clear();
        _movementPoints.AddRange(GetComponentsInChildren<MovementPoint>());
    }
    #endif
}
