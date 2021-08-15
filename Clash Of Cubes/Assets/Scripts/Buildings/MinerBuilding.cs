using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerBuilding : BaseBuilding
{
    [SerializeField] public BaseResource productionPerHour;

    private float deltaTime; // In seconds
    private BaseResource deltaProduction = new BaseResource();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        print("MinerBuilding start");
        deltaTime = 60f * 60f / productionPerHour.count;
        deltaProduction.name = productionPerHour.name;
        // deltaProduction.count = (int)(productionPerHour.count / 60f / 60f);
        deltaProduction.count = 1;
        print(deltaTime);
        print(deltaProduction);
    }

    protected override void Launch()
    {
        StartCoroutine(Product());
    }

    protected override void Stop() {
        StopCoroutine(Product());
    }

    IEnumerator Product() {
        while (true) {
            field.Product(deltaProduction);
            yield return new WaitForSeconds(deltaTime);
        }
    }
}
