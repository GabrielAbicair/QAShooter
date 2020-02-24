using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody rb;
    Health hp;
    public float moveSpeed = 6;

    private void Awake()
    {
        hp = GetComponent<Health>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!hp.isAlive)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        Movement_WASD();
    }

    void Movement_WASD()
    {
        var direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        rb.MovePosition(transform.position + direction * Time.deltaTime * moveSpeed);
    }
}
