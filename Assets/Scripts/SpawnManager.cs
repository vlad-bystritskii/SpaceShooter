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
    private GameObject _tripleShotPowerup; 
    [SerializeField]
    private GameObject _speedPowerup; 

    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTripleeShotRoutine());
        StartCoroutine(SpawnSpeedRoutine());
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
        yield return new WaitForSeconds(Random.Range(3, 7));    
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 6.5f, 0);
            GameObject powerup = Instantiate(_tripleShotPowerup, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }

    IEnumerator SpawnSpeedRoutine()
        {
        yield return new WaitForSeconds(Random.Range(3, 7));    
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 6.5f, 0);
            GameObject powerup = Instantiate(_speedPowerup, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
