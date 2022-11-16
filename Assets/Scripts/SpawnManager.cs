using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private float _enemySpawnDelay = 5.0f;
    [SerializeField]
    private float _tripleShotSpanwDelay = 15.0f;
    [SerializeField]
    private GameObject _tripleShotPowerup; 

    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTripleeShotRoutine());
    }

    void Update()
    {

    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_enemySpawnDelay);
        }
    }

    IEnumerator SpawnTripleeShotRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 6.5f, 0);
            GameObject powerup = Instantiate(_tripleShotPowerup, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(_tripleShotSpanwDelay);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
