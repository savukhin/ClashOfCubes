using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public class PlacedBuilding {
        public BaseBuilding building;
        public Vector2 corner;
    }
    
    public Cell cellPrefab;
    public Vector2 shape;
    public Camera mainCamera;
    public HashSet<BaseBuilding> buildings = new HashSet<BaseBuilding>();
    public World world;
    [System.NonSerialized] public BaseBuilding choosenBuilding;
    

    private Vector3 fieldSize;
    private Vector2 localCellSize;
    private Vector3 center;
    private List<List<Cell>> cells = new List<List<Cell>>();
    private bool loaded = false;
    private GameObject cellsMask;

    public bool showGrid {
        get {
            if (cellsMask == null)
                return false;
            return cellsMask.gameObject.activeSelf;
        }
        set {
            if (cellsMask == null)
                return;
            cellsMask.SetActive(value);
        }
    }

    void Start()
    {
        CreateCells();
        LoadStartBuildings();
        showGrid = false;
    }

    void OnEnable() {
        CreateCells();
    }

    public void AddBuilding(BaseBuilding building) {
        if (!buildings.Contains(building)) {
            building.field = this;
            buildings.Add(building);
        }
    }

    private Vector3 PlaceBuilding(BaseBuilding building, Cell cell) {
        if (cell == null)
            return Vector3.zero;

        Vector3 position = cell.transform.position;
        Vector3 size = building.GetComponent<BoxCollider>().size;

        position.y += fieldSize.y / 2 + size.y / 2;
        position.x += localCellSize.x * building.shape.x / 2.0f - localCellSize.x / 2;
        position.z += localCellSize.y * building.shape.y / 2.0f - localCellSize.y / 2;
        return position;
    }

    public void LoadStartBuildings() {
        if (loaded)
            return;
        loaded = true;
        var result = StartBuildingsConfig.LoadData();
        BuildingContainer container 
                = GameObject.Find("Building Container").GetComponent<BuildingContainer>();
        for (int i = 0; i < result.Count; i++) {
            BaseBuilding item = container.find(result[i].Name);
            if (item == null)
                continue;
            
            int X = int.Parse(result[i].Location.X);
            int Y = int.Parse(result[i].Location.Y);
            cells[X][Y].gameObject.GetComponent<Renderer>().material.SetFloat("_Active", 1);;
            BaseBuilding instance = Instantiate(item, PlaceBuilding(item, cells[X][Y]), Quaternion.identity);
            Build(instance, cells[X][Y], true);
        }
    }

    private void CreateCells() {
        if (cells.Count > 0)
            return;
        
        cellsMask = new GameObject();
        cellsMask.transform.parent = transform;

        fieldSize = GetComponent<Collider>().bounds.size;
        center = transform.position;

        localCellSize = new Vector2(fieldSize.x / shape.x, fieldSize.z / shape.y);

        for (int i = 0; i < shape.x; i++) {
            float y = center.z - fieldSize.z / 2 + localCellSize.y / 2 + localCellSize.y * i;
            cells.Add(new List<Cell>());
            
            for (int j = 0; j < shape.y; j++) {
                float x = center.x - fieldSize.x / 2 + localCellSize.x / 2 + localCellSize.x * j;
                Vector3 position = new Vector3(y, center.y, x);
                cells[i].Add(
                    Instantiate(cellPrefab, position, Quaternion.identity, cellsMask.transform)
                    );
                cells[i][j].position = new Vector2(i, j);
            }
        }
    }

    public bool IsBusy(Cell cell) {
        return cell.busy;
    }

    public bool IsBusy(int x, int y) {
        if (x < 0 || x >= shape.x
                || y < 0 || y >= shape.y)
            return true;

        return cells[x][y].busy;
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

    private bool AbleToBuild(BaseBuilding building) {
        Cell cell = GetForwardCell();
        if (cell == null)
            return false;
        
        for (int i = 0; i < building.shape.x; i++) {
            for (int j = 0; j < building.shape.y; j++) {
                int x = ((int)cell.position.x) + i;
                int y = ((int)cell.position.y) + j;
                if (IsBusy(x, y))
                    return false;

            }
        }
        return true;
    }

    public bool Build(BaseBuilding building, Cell cell=null, bool instantly=false) {
        if (!AbleToBuild(building))
            return false;
        
        AddBuilding(building);
        building.field = this;
        building.Build(instantly);
        
        if (cell == null)
            cell = GetForwardCell();

        for (int i = 0; i < building.shape.x; i++) {
            for (int j = 0; j < building.shape.y; j++) {
                int x = ((int)cell.position.x) + i;
                int y = ((int)cell.position.y) + j;
                cells[x][y].gameObject.GetComponent<Renderer>().material.SetFloat("_Active", 1);
                cells[x][y].busy = true;
            }
        }
        return true;
    }

    public Vector3 PlaceBuilding(BaseBuilding building) {
        Cell cell = GetForwardCell();
        return PlaceBuilding(building, cell);
    }

    public void Unchoose() {
        world.ChooseBuilding(null);
    }

    public void Choose(BaseBuilding building) {
        world.ChooseBuilding(building);
    }

    public void Product(BaseResource production) {
        world.TakeResource(production);
    }

    public void AddStorage(Storage storage) {
        world.AddStorage(storage);
    }
}
