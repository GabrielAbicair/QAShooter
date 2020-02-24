using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwayLookToCamera : MonoBehaviour
{
    Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        transform.rotation = cameraTransform.rotation;
    }
}
