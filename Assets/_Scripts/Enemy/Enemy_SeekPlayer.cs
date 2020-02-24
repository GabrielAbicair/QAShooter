using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class Enemy_SeekPlayer : MonoBehaviour
{

    [Header("Attributes")]
    public float senseRadius;
    public bool chasePlayer;


    NavMeshAgent nav;
    Transform playerTransform;
    Vector3 startPosition;
    Health hp;
    

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindWithTag("Player").transform; //TODO: Save a global reference for the player transform to prevent the use of "Find" functions
        hp = GetComponent<Health>();
    }

    public void OnDrawGizmosSelected()
    {
        Handles.color = new Color(.2f,.2f,1);
        Handles.DrawWireDisc(transform.position,Vector3.up,senseRadius);
    }

    private void OnEnable()
    {
        Restart();
        hp.OnGetHit += toggleChaseON;
    }
    private void OnDisable()
    {
        hp.OnGetHit -= toggleChaseON;
    }

    void Update()
    {
        SeekPlayer();
    }

    void Restart()
    {
        nav.enabled = true;
        startPosition = transform.position;
        chasePlayer = false;
    }

    void toggleChaseON() { chasePlayer = true; }

    void SeekPlayer()
    {
        if (!hp.isAlive) nav.enabled = false;
        if (!nav.enabled) return;

        //TODO: add raycast to prevent seeking player through walls
        //TODO: enemy wander when not seeking the player

        if ((Vector3.Distance(transform.position, playerTransform.position) < senseRadius
            || chasePlayer))
        {
            nav.SetDestination(playerTransform.position);
        }
        else
        {
            nav.SetDestination(startPosition);
        }
    }
    
}
