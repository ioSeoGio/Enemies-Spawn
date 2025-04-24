using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Coroutine _coroutine;

    public void Move(Vector3 direction, float speed)
    {
        _coroutine = StartCoroutine(MoveCoroutine(direction, speed));
    }

    public IEnumerator MoveCoroutine(Vector3 direction, float speed)
    {
        WaitForFixedUpdate wait = new WaitForFixedUpdate();

        while (enabled)
        {
            transform.Translate(Math.Abs(speed) * Time.deltaTime * direction);
            
            yield return wait;
        }
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }
}
