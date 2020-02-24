using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    Animator anim;
    Health hp;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        hp = GetComponent<Health>();
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

    private void Update()
    {
        MovementAnimation();
    }

    void Restart()
    {
        anim.SetBool("isDead", false);
    }

    void MovementAnimation()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));

        movement = transform.InverseTransformDirection(movement);

        anim.SetFloat("MoveSpeedHorizontal", movement.x);
        anim.SetFloat("MoveSpeedVertical", movement.z);
    }

    void dieAnimation()
    {
        anim.SetBool("isDead", true);
    }
}
