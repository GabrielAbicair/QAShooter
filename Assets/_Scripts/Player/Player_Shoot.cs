using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] int damage;
    [Header("Reference")]
    [SerializeField] Transform muzzle;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] GameObject prefab_BulletTrail;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Ray ray = new Ray (muzzle.position, muzzle.forward);
        Vector3 endTrailPosition = muzzle.position + ray.direction * 45;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyLayerMask))
        {
            endTrailPosition = hit.point;

            hit.collider.GetComponent<Health>().Damage(damage);
        }
        
        Instantiate(prefab_BulletTrail).GetComponent<BulletTrail>().Initialize(muzzle.position, endTrailPosition);
    }
}
