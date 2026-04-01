using UnityEngine;
using TMPro;
// using System.Drawing;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 initialScale;
    // private bool isEnlarged = false;
    public TMP_Text lifesText;
    public Color old_color;

    void Start()
    {
        initialScale = transform.localScale;
        lifesText.text = "Lives: " + FindFirstObjectByType<BallMovement>().lifes;
        old_color = transform.GetComponent<Renderer>().material.color;

    }

    // Update is called once per frame
    public void EnlargePaddle(float duration)
    {
        
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z * 1.5f);
            transform.GetComponent<Renderer>().material.color = Color.yellow; // Ensure the material color is set
            // isEnlarged = true;
            Invoke("ResetPaddleSize", duration);
        
    }
    void ResetPaddleSize()
    {
        transform.localScale = initialScale;
        // isEnlarged = false;
        transform.GetComponent<Renderer>().material.color = old_color;

    }
    public void IncreaseBallSpeed(float duration)
    {
       
        var ball = FindFirstObjectByType<BallMovement>();
        ball.speed *= 2f;
        Debug.Log("Increasing ball speed for duration: " + ball.speed);
        Invoke("ResetBallSpeed", duration);
    }

    void ResetBallSpeed()
    {
        var ball = FindFirstObjectByType<BallMovement>();
        ball.speed /= 2f;
    }
    
    public void AddExtraLife()
    {
        var ball = FindFirstObjectByType<BallMovement>();
        ball.lifes++;
        Debug.Log("Extra life added. Total lives: " + ball.lifes);
        lifesText.text = "Lives: " + ball.lifes;
    }


    void Update()
    {
        
    }
}
