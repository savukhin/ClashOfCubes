using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Camera mainCamera;
    public bool busy = false;
    public Vector2 position;

    private new Renderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeActive() {
        renderer.material.SetFloat("_Active", 1);
    }
}
