using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanismScript : MonoBehaviour
{

    private Vector3 cenGlobal;
    public float speed = 45f;
    public BallScript ballScript;
    public LogicScript logicScript;
    private bool scoreIncreased = false;

    public void increaseSpeed(float increaseBy)
    {
        speed += increaseBy;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 cenLocal = gameObject.GetComponent<Renderer>().bounds.center;
        cenGlobal = gameObject.transform.TransformPoint(cenLocal);
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!ballScript.isDead) {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.back, speed * Time.deltaTime);
        }      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ball touched trigger");
        if (collision.gameObject.CompareTag("Ball") && Input.GetKeyDown(KeyCode.Space))
        {
            // whenBallIsHit(true);
            ballScript.setGenerateBall(true);
            scoreIncreased = true;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Ball inside trigger");
        if (collision.gameObject.CompareTag("Ball") && Input.GetKeyDown(KeyCode.Space) && !scoreIncreased)
        {
            // whenBallIsHit(true);
            ballScript.setGenerateBall(true);
            scoreIncreased = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        Debug.Log("Ball left trigger");
        if (scoreIncreased == false)
        {
            Debug.Log("is dead");
            ballScript.setGenerateBall(false);
            ballScript.setIsDead(true);
            logicScript.gameOver();
        } else
        {
            Debug.Log("score increased");
            logicScript.increaseScore();
            if (logicScript.score % 5 == 0)
            {
                increaseSpeed(5f);
            }
            scoreIncreased = false;
            speed *= -1;
            Debug.Log("speed: " + speed);
        }
    }

    public void whenBallIsHit(bool scoreInc)
    {
        speed *= -1;
        Debug.Log("speed: " + speed);
        ballScript.setGenerateBall(true);
        logicScript.increaseScore();
        if (logicScript.score % 5 == 0)
        {
            increaseSpeed(5f);
        }
        scoreIncreased = scoreInc;

    }

}
