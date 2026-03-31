using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject playArea;
    public float speed = 6.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello Game");
        Debug.Log(transform.position.x);
        Debug.Log(transform.position.y);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        float dir = 0;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            dir = -1;
            Debug.Log("Key is pressed left");
        }
            
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            dir = 1;
            Debug.Log("Key is pressed right");
        }
            

        // Movimiento suave
        transform.position += new Vector3(0, 0, dir * speed * Time.deltaTime);

        // Tamaños reales en mundo
        float halfWidth = playArea.GetComponent<Renderer>().bounds.size.z / 2f;
        float paddleHalf = GetComponent<Renderer>().bounds.size.z / 2f;

        // Centro del área
        float centerZ = playArea.transform.position.z;

        // Límites reales
        float minZ = centerZ - halfWidth + paddleHalf;
        float maxZ = centerZ + halfWidth - paddleHalf;

        // Clamp
        Vector3 pos = transform.position;
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;
    }
}
