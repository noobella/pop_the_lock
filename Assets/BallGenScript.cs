using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenScript : MonoBehaviour
{

    public GameObject ball;
    private bool generateBall { get; set; }
    private System.Random random = new System.Random();
    private float radius = 2.35f;
    
    // Start is called before the first frame update
    void Start()
    {
        generateBall = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ballClone;
        if (generateBall)
        {
            // randomly generate an angle + calculate the coordinates along the circle
            int angle = random.Next(0, 360);
            float xPos = radius * Mathf.Sin(angle);
            float yPos = radius * Mathf.Cos(angle);
            Vector3 position = new Vector3(xPos, yPos, 0);
            ballClone = Instantiate(ball, position, transform.rotation);
            SpriteRenderer spriteRenderer = ballClone.GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = 1;
            generateBall = false;
        }
    }
}
