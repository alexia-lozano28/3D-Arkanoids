using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    public int lives;
    private Renderer rend;
    public Color color;
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
         lives--;

            Debug.Log("impactando, vidas: " + lives);

            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        
    }
    // void OnCollisionEnter(Collision collision)
    // {
    //     // if (collision.gameObject.CompareTag("Ball"))
    //     // {
    //         lives--;

    //         Debug.Log("impactando, vidas: " + lives);

    //         if (lives <= 0)
    //         {
    //             Destroy(gameObject);
    //         }
    //     // }
    // }

}