using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    enum availableHittables { Player, Enemy }
    [SerializeField] availableHittables hittableTag;

    List<Health> actorsInArea = new List<Health>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(hittableTag.ToString()))
        {
            actorsInArea.Add(other.GetComponent<Health>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(hittableTag.ToString()))
        {
            actorsInArea.Remove(other.GetComponent<Health>());
        }
    }

    public void doDamage(int amount)
    {
        foreach (Health hp in actorsInArea)
        {
            hp.Damage(amount);
        }
    }
}
