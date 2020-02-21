using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent nav;
    Transform playerTransform;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        nav.SetDestination(playerTransform.position);
    }


}
