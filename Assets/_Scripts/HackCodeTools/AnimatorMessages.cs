using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMessages : MonoBehaviour
{
    public void SendMessageToParent(string message)
    {
        SendMessageUpwards(message);
    }
}
