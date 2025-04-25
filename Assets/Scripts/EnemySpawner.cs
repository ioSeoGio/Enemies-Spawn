using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _objectParent;
    [SerializeField] private float _spawnDelay = 2;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    
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
        TargetMover enemy = _objectSpawner.Spawn(spawnPoint.Prefab, spawnPoint.transform.position, _objectParent);
        enemy.Move(spawnPoint.Target, spawnPoint.Speed);
    }

    private SpawnPoint PickRandomSpawnPoint()
    {
        return _spawnPoints[RandomHelper.GetRandomNumber(0, _spawnPoints.Count)];
    }

    #if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _spawnPoints.Clear();
        _spawnPoints.AddRange(GetComponentsInChildren<SpawnPoint>());
    }
    #endif
}
