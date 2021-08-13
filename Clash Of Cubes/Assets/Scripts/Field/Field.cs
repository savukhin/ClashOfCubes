using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Cell cellPrefab;
    public Vector2 shape;
    public Camera mainCamera;

    private Vector3 cellSize;
    private Vector3 center;
    private List<List<Cell>> cells = new List<List<Cell>>();

    void Start()
    {
        // size = GetComponent<Collider>().bounds.size;
        // center = transform.position;
        CreateCells();
    }

    void OnEnable() {
        CreateCells();
    }

    private void CreateCells() {
        if (cells.Count > 0)
            return;

        cellSize = GetComponent<Collider>().bounds.size;
        center = transform.position;

        Vector2 localSize = new Vector2(cellSize.x / shape.x, cellSize.z / shape.y);

        for (int i = 0; i < shape.x; i++) {
            float y = center.z - cellSize.z / 2 + localSize.y / 2 + localSize.y * i;
            cells.Add(new List<Cell>());
            
            for (int j = 0; j < shape.y; j++) {
                float x = center.x - cellSize.x / 2 + localSize.x / 2 + localSize.x * j;
                Vector3 position = new Vector3(x, center.y, y);
                cells[i].Add(
                    Instantiate(cellPrefab, position, Quaternion.identity, transform)
                    );
            }
        }
    }

    public Cell GetForwardCell() {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit info;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue, 10, true);
        if (Physics.Raycast(ray, out info, Mathf.Infinity, LayerMask.GetMask("Cell"))) {
            return info.collider.GetComponent<Cell>();
        }
        return null;
    }

    public Vector3 PlaceBuilding(BaseBuilding building) {
        Cell cell = GetForwardCell();
        if (cell == null)
            return Vector3.zero;
        Vector3 position = cell.transform.position;

        position.y += cellSize.y / 2 + building.GetComponent<BoxCollider>().size.y / 2;
        return position;
    }
}
