using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    static public EnemySpawner instance;

    [SerializeField] GameObject [] enemiesAvailable;

    Transform [] spawnPoints;

    private void Awake()
    {
        instance = this;
        spawnPoints = transform.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) Spawn(enemiesAvailable[Random.Range(0, enemiesAvailable.Length)]);
    }

    public GameObject Spawn(GameObject obj = null)
    {
        if (obj == null) obj = enemiesAvailable[Random.Range(0, enemiesAvailable.Length)];

        var g = ObjectPool.instance.GetObject(obj);
        g.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        g.SetActive(true);
        return g;
    }
    
}
