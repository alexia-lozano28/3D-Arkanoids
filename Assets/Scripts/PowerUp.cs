using UnityEngine;

public enum PowerUpType
{
    SpeedUp,Enlarge,ExtraLife, MultiBall
}

public class PowerUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PowerUpType type;
    public float duration = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ApplyPowerUp(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();

        Debug.Log("Applying power-up: " + type);
        switch (type)
        {
            case PowerUpType.SpeedUp:
                // Increase ball speed
                controller.IncreaseBallSpeed(duration);
                break;
            case PowerUpType.Enlarge:
                // Enlarge paddle
                controller.EnlargePaddle(duration);
                break;
            case PowerUpType.ExtraLife:
                // Add extra life
                controller.AddExtraLife();
                break;
            case PowerUpType.MultiBall:
                // Spawn additional balls
                FindObjectOfType<BallSpawner>().SpawnExtraBalls();
                break;
        }
    }

      void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {        
            ApplyPowerUp(other.gameObject);
            // Debug.Log("Power-up applied: " + type);
            Destroy(gameObject);
        }
    }
}
