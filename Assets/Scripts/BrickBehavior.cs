using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    public int lives;
    private Renderer rend;
    public Color color;

    public float powerUpChance = 0.2f; // 20% chance to drop a power-up
    public float powerUpFallSpeed = 2f; // Speed at which the power-up falls
    public GameObject[] powerUpPrefabs; // Array of power-up prefabs to choose
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
            if (Random.value < powerUpChance)
            {
                int index = Random.Range(0, powerUpPrefabs.Length);
                GameObject powerUp = Instantiate(powerUpPrefabs[index], transform.position, powerUpPrefabs[index].transform.rotation);
                Rigidbody rb = powerUp.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = powerUp.AddComponent<Rigidbody>();
                    rb.useGravity = false; // Disable gravity if you want it to fall straight down
                    rb.isKinematic = false; // Make it kinematic to control its movement manually
                }
                var fallScript = powerUp.AddComponent<PowerUpFallX>();
                fallScript.fallSpeed = powerUpFallSpeed;
                fallScript.direction = Vector3.right; // Adjust direction as needed
            }
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