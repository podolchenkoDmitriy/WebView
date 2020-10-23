using System.Collections;
using UnityEngine;

public class DistanceController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particle;

    private void Start()
    {
        StartCoroutine(OnOfPlane());

    }

    private IEnumerator OnOfPlane()
    {
        while (true)
        {
            if ( transform.position.z < -50f)
            {
                gameObject.SetActive(false);

                yield return new WaitForFixedUpdate();
            }

            yield return new WaitForFixedUpdate();

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        particle.transform.position = collision.contacts[0].point;
        particle.SetActive(true);
    }

}
