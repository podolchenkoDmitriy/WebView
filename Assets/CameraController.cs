using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        Vector3 origPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition += new Vector3(x, 0, y);
            elapsed += Time.fixedDeltaTime;
            yield return null;
        }
        transform.localPosition = origPos;
    }
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeRoutine(duration, magnitude));
    }
}
