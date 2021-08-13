using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Cell cellPrefab;
    public Vector2 shape;

    private Vector3 size;
    private Vector3 center;
    private List<List<Cell>> cells = new List<List<Cell>>();

    void Start()
    {
        size = GetComponent<Collider>().bounds.size;
        center = transform.position;

        Vector2 localSize = new Vector2(size.x / shape.x, size.z / shape.y);

        for (int i = 0; i < shape.x; i++) {
            float y = center.z - size.z / 2 + localSize.y / 2 + localSize.y * i;
            cells.Add(new List<Cell>());
            
            for (int j = 0; j < shape.y; j++) {
                float x = center.x - size.x / 2 + localSize.x / 2 + localSize.x * j;
                Vector3 position = new Vector3(x, center.y, y);
                cells[i].Add(
                    Instantiate(cellPrefab, position, Quaternion.identity, transform)
                    );
            }
        }
    }
}
