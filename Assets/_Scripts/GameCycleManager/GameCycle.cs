using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] int baseEnemyCount;
    [SerializeField] float increaseFactor;
    [SerializeField] int startingWave;
    int enemiesRemaining;
    int currentWave;

    [Header("Reference")]
    [SerializeField] EnemyCounter enemyCounter;

    EnemySpawner spawner;
    
    //TODO: If the wave is not killed fast enough the enemies "enrage" and start chasing the player

    private void Awake()
    {
        spawner = EnemySpawner.instance;

        if (spawner == null) Debug.LogError("Missing a EnemySpawner on the scene");
    }

    private void Start()
    {
        currentWave = startingWave;

        SpawnWave();
    }

    private void SpawnWave()
    {
        enemiesRemaining = waveEnemyCount(currentWave);

        for (int i = 0; i < enemiesRemaining; i++)
        {
            GameObject g = spawner.Spawn();
            g.GetComponent<Health>().OnDeath += EnemyDies;
        }

        UpdateCounter();
    }

    public void EnemyDies()
    {
        enemiesRemaining--;

        if(enemiesRemaining == 0)
        {
            currentWave++;
            SpawnWave();
        }

        UpdateCounter();
    }

    private int waveEnemyCount(int waveNumber)
    {
        return Mathf.RoundToInt(baseEnemyCount + increaseFactor * Mathf.Sqrt(waveNumber));
    }

    void UpdateCounter()
    {
        if (enemyCounter == null) return;

        enemyCounter.UpdateEnemyCount(enemiesRemaining, waveEnemyCount(currentWave));
    }
}
