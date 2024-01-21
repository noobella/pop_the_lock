using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    public Text textScore;
    public int score { get; private set; } = 0;
    public GameObject gameLock;
    public GameObject lockMechanism;
    public Animator lockAnimator;
    public Animator lockMechAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore()
    {
        score++;
        textScore.text = score.ToString();
        Debug.Log(score);
      
    }

    public void gameOver()
    {
        // stop lock mech
        // lockMechanism.transform.RotateAround(Vector3.zero, Vector3.back, 0);
        // tilt screen
        
        lockAnimator.enabled = true;
        // lockMechAnimator.enabled = true;
        // GetComponent<Animator>().Play("lockMechAnim");
        // game over screen
    }

    private void OnAnimatorIK(int layerIndex)
    {
        lockAnimator.bodyPosition = gameLock.transform.position;
        // lockMechAnimator.bodyPosition = lockMechanism.transform.position;
    }

}
