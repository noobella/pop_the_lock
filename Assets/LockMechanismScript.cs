using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanismScript : MonoBehaviour
{


    private Vector3 cenGlobal;
    public float rotationAngle = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 cenLocal = gameObject.GetComponent<Renderer>().bounds.center;
        cenGlobal = gameObject.transform.TransformPoint(cenLocal);
        Debug.Log(cenGlobal.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.transform.Rotate(0, 0, rotationAngle * Time.deltaTime);
        gameObject.transform.RotateAround(Vector3.zero, Vector3.back, rotationAngle);

    }
}
