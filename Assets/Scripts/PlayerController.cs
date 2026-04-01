using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 initialScale;
    // private bool isEnlarged = false;
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    public void EnlargePaddle(float duration)
    {
        
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z * 1.5f);
            // isEnlarged = true;
            Invoke("ResetPaddleSize", duration);
        
    }
    void ResetPaddleSize()
    {
        transform.localScale = initialScale;
        // isEnlarged = false;
    }
    public void IncreaseBallSpeed(float duration)
    {
       
        var ball = FindFirstObjectByType<BallMovement>();
        ball.speed *= 1.5f;
        Debug.Log("Increasing ball speed for duration: " + ball.speed);
        Invoke("ResetBallSpeed", duration);
    }

    void ResetBallSpeed()
    {
        var ball = FindFirstObjectByType<BallMovement>();
        ball.speed /= 1.5f;
    }
    
    public void AddExtraLife()
    {
        var ball = FindFirstObjectByType<BallMovement>();
        ball.lifes++;
        Debug.Log("Extra life added. Total lives: " + ball.lifes);
    }


    void Update()
    {
        
    }
}
