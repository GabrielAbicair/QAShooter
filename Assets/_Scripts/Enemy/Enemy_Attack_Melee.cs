using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class Enemy_Attack_Melee : MonoBehaviour
{
    [Header("Attribute")]
    public int damage;
    public float range;

    [Header("Reference")]
    [SerializeField] DamageArea hitBox;

    Enemy_Animation anim;
    NavMeshAgent nav;
    Transform playerTransform;
    Health hp;

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform; //TODO: Save a global reference for the player transform to prevent the use of "Find" functions
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Enemy_Animation>();
        hp = GetComponent<Health>();
    }

    private void OnDrawGizmos()
    {
        Handles.color = new Color(1f, .2f, .2f);
        Handles.DrawWireDisc(transform.position, Vector3.up, range);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < range
            && hp.isAlive)
        {
            Attack();
        }
    }

    public void Attack()
    {
        anim.attackAnimation();
        StartCoroutine(StopMovingWhileAttacking());
    }

    public void AttackFrame()
    {
        hitBox.doDamage(damage);
    }

    IEnumerator StopMovingWhileAttacking()
    {
        nav.enabled = false;
        yield return new WaitForSeconds(anim.getCurrentAnymationLenght());
        nav.enabled = true;
    }
}
