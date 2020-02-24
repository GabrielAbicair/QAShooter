using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] int damage;
    [SerializeField] float fireInterval;
    float timeToShoot;
    [SerializeField] float fireSpread;

    [Header("Reference")]
    [SerializeField] Transform muzzle;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] GameObject prefab_BulletTrail;
    Health hp;

    //TODO: Ammo
    //TODO: Reload time
    //TODO: Weapon variant

    private void Awake()
    {
        hp = GetComponent<Health>();
    }

    private void Update()
    {
        if (!hp.isAlive) return;

        if (Input.GetMouseButton(0) && timeToShoot <= 0)
        {
            Shoot();
            timeToShoot = fireInterval;
        }

        timeToShoot -= Time.deltaTime;
    }

    void Shoot()
    {
        RaycastHit hit;
        Ray ray = new Ray (muzzle.position, muzzle.TransformVector(new Vector3(Random.Range(.05f,-.05f),0,1)));
        Vector3 endTrailPosition = muzzle.position + ray.direction * 45;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyLayerMask))
        {
            endTrailPosition = hit.point;

            hit.collider.GetComponent<Health>().Damage(damage);
        }
        
        Instantiate(prefab_BulletTrail).GetComponent<BulletTrail>().Initialize(muzzle.position, endTrailPosition);
    }
}
