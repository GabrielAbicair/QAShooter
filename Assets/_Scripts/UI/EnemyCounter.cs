using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] TMP_Text txt_EnemiesRemaining;

    public void UpdateEnemyCount(int alive, int total)
    {
        txt_EnemiesRemaining.text = alive.ToString() + "/" + total.ToString();
    }

}
