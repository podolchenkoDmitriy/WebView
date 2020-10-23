using UnityEngine;

public class LoseDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            UIInstance.instance.Lose();

        }
    }
}
