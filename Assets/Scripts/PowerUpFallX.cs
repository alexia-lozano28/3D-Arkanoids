using UnityEngine;

public class PowerUpFallX : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float fallSpeed = 2f;
    public Vector3 direction = Vector3.right;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * fallSpeed * Time.deltaTime;
        
    }
}
