using System.Threading.Tasks;
using TMPro;
using TreeEditor;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 8f;
    public GameObject playArea;
    public float maxXSpeed;
    public float minXSpeed;
    private Vector3 velocity;
    public float factor = 5.0f;
    public TMP_Text myText;

    public int hitCount;
    void Start()
    {
        velocity = new Vector3(maxXSpeed, 0, 0);
    }

    void Update()
    {

        transform.position += velocity * Time.deltaTime;
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player")){
    //         float hit = transform.position.x - collision.transform.position.x;

    //         Vector3 dir = new Vector3(hit, 0, 1).normalized;

    //         rb.linearVelocity = dir * speed;
    //     }
    // }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float maxDist = other.transform.localScale.z*0.5f + transform.localScale.z*0.5f;
            float actualDist = transform.position.z - other.transform.position.z;
            float normalizedDist = actualDist / maxDist;
            velocity = new Vector3(-velocity.x, velocity.y, normalizedDist * maxDist *factor);
            // myText.text = (++hitCount).ToString();

        }
        else if (other.CompareTag("WallTag"))
        {
            velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
        }
        else if (other.CompareTag("Brick"))
        {
            float maxDist = other.transform.localScale.z * 0.5f + transform.localScale.z * 0.5f;
            float actualDist = transform.position.z - other.transform.position.z;
            float normalizedDist = actualDist / maxDist;
            velocity = new Vector3(-velocity.x, velocity.y, normalizedDist * maxDist *factor);
            myText.text = (++hitCount).ToString();
        }
        GetComponent<AudioSource>().Play();

        // put any memory or information attach the script, add new script, counting script, and put some internal state 
        // int hitcount and increase it y lo adjunta al mismo paddle. other<getcomponent><Counting>().youWereHit() (asi consgo el script que he adjuntado)
    }
}