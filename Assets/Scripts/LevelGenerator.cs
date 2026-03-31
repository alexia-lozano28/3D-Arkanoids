using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject brickPrefab;
    public GameObject playArea;
    public int rows = 5;
    public int cols = 5;
    public float spacing = 0.1f;
    // public Color brickColor = Color.red;

    Color[] colors = new Color[]
 {
    Color.red,
    Color.yellow,
    Color.green,
    Color.cyan,
    Color.blue
 };

    void Start()
    {
        Vector3 brickSize = brickPrefab.GetComponent<Renderer>().bounds.size;
        Vector3 areaSize = playArea.GetComponent<Renderer>().bounds.size;
        Vector3 areaCenter = playArea.transform.position;

        float playWidth = areaSize.z;

        float brickWidth = (playWidth - (cols - 1) * spacing) / cols;

        float startZ = areaCenter.z - playWidth / 2 + brickWidth / 2;

        float topX = areaCenter.x + areaSize.x / 2;
        float marginTop = 0.5f;
        float startX = -(topX - marginTop);

        for (int row = 0; row < rows; row++)
        {
            Color rowColor = colors[row % colors.Length];
            for (int col = 0; col < cols; col++)
            {
                float x = startX + row * (brickSize.x + spacing);
                float z = startZ + col * (brickWidth + spacing);

                Vector3 pos = new Vector3(x, brickPrefab.transform.position.y, z);

                GameObject brick = Instantiate(brickPrefab, pos, Quaternion.identity, transform);
                BrickBehavior bb = brick.GetComponent<BrickBehavior>();
                bb.lives = rows - row;
                brick.GetComponent<Renderer>().material.color = rowColor;
                // Ajustar ancho automáticamente
                Vector3 scale = brick.transform.localScale;
                scale.z = brickWidth / brickSize.z;
                brick.transform.localScale = scale;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
