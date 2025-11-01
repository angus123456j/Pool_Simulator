using UnityEngine;

public class PoolTriangleGenerator : MonoBehaviour
{
    public GameObject ballPrefab; // Assign your ball prefab in Inspector
    public int rows = 5; // Number of rows in the triangle
    public float spacing = 1f; // Distance between balls

    void Start()
    {
        Vector3 startPos = transform.position;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                // Calculate position for each ball
                Vector3 pos = startPos + new Vector3(
                    (col - row * 0.5f) * spacing, 
                    0, 
                    row * spacing
                );
                Instantiate(ballPrefab, pos, Quaternion.identity, transform);
            }
        }
    }
}