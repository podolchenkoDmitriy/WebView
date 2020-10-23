using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesStanding : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _planePrefab;
    public GameObject _winPlane;
    public int _planesOnLevel = 50;
    public Vector3 _distBetveenPlanes;
    Transform[] _planes;

    void Awake()
    {

        _planes = new Transform[_planesOnLevel];

        Vector3 pos = Vector3.zero;

        for (int i = 1; i <= _planesOnLevel; i++)
        {
            float randFl = Random.Range(0, 3f);
            
            if (randFl > 0 && randFl < 1)
            {
                pos = new Vector3(  _distBetveenPlanes.x, 0, i*_distBetveenPlanes.z);
            }

            else if (randFl > 1 && randFl < 2)
            {
                pos = new Vector3( - _distBetveenPlanes.x, 0, i*_distBetveenPlanes.z);

            }

            else if (randFl > 2 && randFl < 3)
            {
                pos = new Vector3(0, 0, i*_distBetveenPlanes.z);

            }

            _planes[i-1] =  Instantiate(_planePrefab, pos, Quaternion.identity, transform).transform;
        }

        Instantiate(_winPlane, pos + Vector3.forward  * _distBetveenPlanes.z, Quaternion.identity, transform);

        for (int i = 4; i < _planesOnLevel; i++)
        {
            _planes[i].gameObject.SetActive(false);
        }
        StartCoroutine(Move());
    }

   IEnumerator Move()
    {
        int i = 3;
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.back, Time.fixedDeltaTime * 15.5f);

            yield return new WaitForFixedUpdate();

            if (i < _planes.Length - 1)
            {
                if (transform.position.z < -(_distBetveenPlanes.z * i))
                {
                    i++;

                    _planes[i].gameObject.SetActive(true);
                }
            }
            
        }
    }
   
}
