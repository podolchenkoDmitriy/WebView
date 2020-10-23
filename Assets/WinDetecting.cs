using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetecting : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerController>())
        {
            UIInstance.instance.Win();
        }
    }
}
