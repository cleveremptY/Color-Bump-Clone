using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40f;

    private Vector2 lastMousePosition;

    [SerializeField]
    private float wallDistance = 5f;
    [SerializeField]
    private float minCameraDistance = 5f;
    public LevelManager mainLevelManager;

    private void Update()
    {
        Vector2 deltaPosition = Vector2.zero;

        if (Input.GetMouseButton(0))
        {
            Vector2 currectMousePosition = Input.mousePosition;

            if (lastMousePosition == Vector2.zero)
            {
                lastMousePosition = currectMousePosition;
            }

            deltaPosition = currectMousePosition - lastMousePosition;
            lastMousePosition = currectMousePosition;

            Vector3 force = new Vector3(deltaPosition.x, 0, deltaPosition.y) * speed;
            GetComponent<Rigidbody>().AddForce(force);
        }
        else
        {
            lastMousePosition = Vector2.zero;
        }
    }

    public void LateUpdate()
    {
        Vector3 pos = transform.position;
        
        if (transform.position.x > wallDistance)
        {
            pos.x = wallDistance;
        }
        else if (transform.position.x < -wallDistance)
        {
            pos.x = -wallDistance;
        }

        if (transform.position.z < Camera.main.transform.position.z + minCameraDistance)
        {
            pos.z = Camera.main.transform.position.z + minCameraDistance;
        }

        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {
            mainLevelManager.Fail();
        }
        if (other.gameObject.tag == "Win")
        {
            mainLevelManager.Win();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            mainLevelManager.Fail();
        }
        if (collision.gameObject.tag == "Win")
        {
            mainLevelManager.Win();
        }
    }
}
