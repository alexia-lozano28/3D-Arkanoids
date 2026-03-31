using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    public void SpawnExtraBalls()
    {
       GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
       Rigidbody rb = newBall.GetComponent<Rigidbody>();
         rb.linearVelocity = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(5f, 10f));
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
