using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    Dictionary<GameObject, List<GameObject>> pool;
    static public ObjectPool instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        pool = new Dictionary<GameObject, List<GameObject>>();
    }

    private void Start()
    {
        foreach (GameObject g in objects)
        {
            pool.Add(g, new List<GameObject>());
            CreateObject(g);
        }
    }

    public GameObject GetObject(GameObject obj)
    {
        if (pool[obj] == null)
        {
            Debug.Log("ERROR: Object pool not found");
            return null;
        }

        List<GameObject> list = pool[obj];

        foreach (GameObject g in list)
            if (g.activeSelf == false) return g;

        return CreateObject(obj);
    }

    GameObject CreateObject(GameObject g)
    {
        var obj = Instantiate(g);
        pool[g].Add(obj);
        obj.SetActive(false);
        return obj;
    }
}
