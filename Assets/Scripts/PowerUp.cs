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
        
        if (controller == null)
        {
            Debug.LogError("PlayerController not found on player: " + player.name);
            return;
        }

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
                BallSpawner spawner = FindFirstObjectByType<BallSpawner>();
                if (spawner != null)
                    spawner.SpawnExtraBalls();
                else
                    Debug.LogError("BallSpawner not found in scene");
                break;
        }
    }

      void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.tag != "Player")
            return;
        Debug.Log("Trigger enter " + type);    
        ApplyPowerUp(other.gameObject);
        Debug.Log("Power-up applied: " + type);
        Destroy(gameObject);
        Debug.Log("Power-up destroyed: " + type);
    }
}
