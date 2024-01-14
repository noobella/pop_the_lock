using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ball;
    public bool generateBall { get; private set; } = true;
    public bool isDead { get; private set; } = false;
    private GameObject ballClone;

    public void setGenerateBall(bool generateBall) { this.generateBall = generateBall; }

    public void setIsDead(bool isDead) { this.isDead = isDead; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateNewBall(Vector3 position) {

        if(ballClone != null)
        {
            Destroy(ballClone);
        }

        ballClone = Instantiate(ball, position, transform.rotation);
        SpriteRenderer spriteRenderer = ballClone.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 1;
        generateBall = false;
    }

}
