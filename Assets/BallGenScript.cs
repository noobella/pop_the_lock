using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallGenScript : MonoBehaviour
{

    public GameObject ball;
    public BallScript ballScript;
    public LogicScript logicScript;
    // private bool generateBall { get; set; }
    private System.Random random = new System.Random();
    private float radius = 2.35f;
   
    
    // Start is called before the first frame update
    void Start()
    {
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
        generateNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject ballClone;
        if (ballScript.generateBall)
        {
           generateNewBall();

        }
    }

    private void generateNewBall()
    {
        Debug.Log("Generate ball...");
        // randomly generate an angle + calculate the coordinates along the circle
        int angle = random.Next(0, 360);
        float xPos = radius * Mathf.Sin(angle);
        float yPos = radius * Mathf.Cos(angle);
        Vector3 position = new Vector3(xPos, yPos, 0);
        ballScript.generateNewBall(position);
        
    }

}
