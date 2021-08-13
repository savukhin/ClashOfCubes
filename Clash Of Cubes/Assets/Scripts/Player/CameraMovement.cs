using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitive = 1f;
    public float zoom = 1;
    [Range(0, 1)] public float zoomSpeed = 0.2f;
    public GameObject mainCamera;

    private Vector3 lastMousePosition;
    private Rigidbody m_rigidbody;
    private Vector3 startPosition;

    void Start() {
        m_rigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {
        if (Input.GetMouseButtonDown(0)) 
            lastMousePosition = Input.mousePosition;
        if (Input.GetMouseButton(0)) {
            Vector3 forward = Vector3.Scale(new Vector3(1, 0, 1), mainCamera.transform.forward).normalized;
            Vector3 right = Vector3.Scale(new Vector3(1, 0, 1), mainCamera.transform.right).normalized;
            Vector3 delta = -(Input.mousePosition - lastMousePosition);
            m_rigidbody.velocity = sensitive * (right * delta.x + forward * delta.y);

            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) {
            m_rigidbody.velocity = Vector3.zero;
        }

        zoom = Mathf.Clamp(zoom - 0.1f * Input.mouseScrollDelta.y, 0.1f, 1.5f);
        float desiredY = startPosition.y * zoom;
        transform.position = new Vector3(transform.position.x, 
                    Mathf.Lerp(transform.position.y, desiredY, zoomSpeed),
                    transform.position.z);
    }
}
