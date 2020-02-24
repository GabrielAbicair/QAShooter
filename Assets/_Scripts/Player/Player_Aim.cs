using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Aim : MonoBehaviour
{
    Camera mainCamera;
    Rigidbody rb;
    Health hp;
    [SerializeField] Transform weaponTransform;
    [SerializeField] LayerMask floorLayerMask;

    private void Awake()
    {
        hp = GetComponent<Health>();
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!hp.isAlive) return;

        AimToMouse();
    }

    void AimToMouse()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorLayerMask))
        {
            Quaternion rawCharacterRotation = Quaternion.LookRotation(hit.point - transform.position);
            Vector3 characterRotation = new Vector3(0, rawCharacterRotation.eulerAngles.y, 0);
            rb.MoveRotation(Quaternion.Euler(characterRotation));
            
            Quaternion rawWeaponRotation = Quaternion.LookRotation(hit.point - weaponTransform.position);
            Vector3 weaponRotation = new Vector3(0, rawWeaponRotation.eulerAngles.y, 0);
            weaponTransform.rotation = Quaternion.Euler(weaponRotation);
        }
    }
}
