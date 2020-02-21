using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BulletTrail : MonoBehaviour
{
    const float TrailSpeed = 200;
    LineRenderer trail;

    Color trailStartColor;
    Color trailEndColor;


    private void Awake()
    {
        trail = GetComponent<LineRenderer>();

    }

    public void Initialize(Vector3 startPosition, Vector3 endPosition, float customSpeed = TrailSpeed)
    {
        gameObject.SetActive(true);

        trail.SetPosition(0, startPosition);
        trail.SetPosition(1, endPosition);

        StartCoroutine(routine_DissipateBulletTrail(customSpeed));
    }

    IEnumerator routine_DissipateBulletTrail(float speed)
    {
        Vector3 pos1 = trail.GetPosition(1);
        Vector3 pos0 = trail.GetPosition(0);

        while (Vector3.Distance(pos0,pos1) > 2)
        {
            yield return 1;

            pos0 = trail.GetPosition(0);
            trail.SetPosition(0, pos0 + (pos1 - pos0).normalized * Time.deltaTime * TrailSpeed);
        }

        Destroy(gameObject);
    }
}
