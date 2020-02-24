using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset;

    private void Awake()
    {
        offset = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position+offset, Time.deltaTime * 6);
    }
}
