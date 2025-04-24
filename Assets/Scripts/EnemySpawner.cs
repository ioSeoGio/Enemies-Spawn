using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _objectParent;
    [SerializeField] private Mover _prefab;
    [SerializeField] private float _spawnDelay = 2;

    private Coroutine _coroutine;
    private ObjectSpawner _objectSpawner = new();

    private void OnEnable()
    {
        _coroutine = StartCoroutine(SpawnEnemiesCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            SpawnEnemy();
            yield return wait;
        }
    }

    private void SpawnEnemy()
    {
        SpawnPoint spawnPoint = PickRandomSpawnPoint();
        Mover enemy = _objectSpawner.Spawn(_prefab, spawnPoint.transform.position, _objectParent);
        enemy.Move(spawnPoint.MovementDirection, spawnPoint.Speed);
    }

    private SpawnPoint PickRandomSpawnPoint()
    {
        SpawnPoint[] spawnPoints = GetComponentsInChildren<SpawnPoint>();

        return spawnPoints[RandomHelper.GetRandomNumber(0, spawnPoints.Length)];
    }
}
