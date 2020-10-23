using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    CameraController cam;
    public float _moveSpeed;
    Rigidbody _rb;
    Vector3 direction;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
        _rb = GetComponent<Rigidbody>();

        StartCoroutine(MoveBall());
    }
    IEnumerator MoveBall()
    {
        while (true)
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, 40f);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                direction = -new Vector3(0.5f, 0, 0) + Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, 0, 0));

                transform.position = Vector3.Lerp(transform.position, transform.position + direction, _moveSpeed * Time.fixedDeltaTime);
            }
            yield return new WaitForFixedUpdate();
        }
    }
    int _bounces = 0;
    private void OnCollisionEnter(Collision collision)
    {
        _bounces++;
        direction = Vector3.zero;
        UIInstance.instance.CountBounces(_bounces);
        cam.Shake(0.1f, 0.1f);
    }
}
