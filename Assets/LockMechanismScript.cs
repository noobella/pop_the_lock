using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanismScript : MonoBehaviour
{

    private Vector3 cenGlobal;
    public float rotationAngle = 5f;
    public BallScript ballScript;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 cenLocal = gameObject.GetComponent<Renderer>().bounds.center;
        cenGlobal = gameObject.transform.TransformPoint(cenLocal);
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.transform.Rotate(0, 0, rotationAngle * Time.deltaTime);
        gameObject.transform.RotateAround(Vector3.zero, Vector3.back, rotationAngle);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger touched ball");
        if (collision.gameObject.CompareTag("Ball") && Input.GetKeyDown(KeyCode.Space))
        {
            ballScript.setGenerateBall(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger inside ball");
        if (collision.gameObject.CompareTag("Ball") && Input.GetKeyDown(KeyCode.Space))
        {
            ballScript.setGenerateBall(true);
        }

    }

}
