using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Animation : MonoBehaviour
{
    NavMeshAgent nav;
    Animator anim;
    Health hp;

    private void Awake()
    {
        hp = GetComponent<Health>();
        anim = GetComponentInChildren<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        Restart();
        hp.OnDeath += dieAnimation;
    }

    private void OnDisable()
    {
        hp.OnDeath -= dieAnimation;
    }

    void Update()
    {
        anim.SetFloat("MoveSpeed", nav.velocity.magnitude);
    }

    void Restart()
    {
        anim.SetBool("isDead", false);
    }

    public void attackAnimation()
    {
        anim.Play("Attack", 0);
    }

    void dieAnimation()
    {
        anim.SetBool("isDead", true);
        anim.Play("Die", 0);
        StartCoroutine(die_Vanish());
    }

    IEnumerator die_Vanish()
    {
        Vector3 initialPosition = transform.position;

        yield return new WaitForSeconds(1);

        
        while (transform.position.y > initialPosition.y - 2)
        {
            transform.Translate(new Vector3(0,-.01f,0));
            yield return new WaitForFixedUpdate();
        }

        gameObject.SetActive(false);
    }

    public float getCurrentAnymationLenght()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length;
    }
}
