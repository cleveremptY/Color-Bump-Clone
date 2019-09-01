using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        //Camera.main.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Camera.main.transform.Translate(new Vector3(0, 10, 10) * Time.deltaTime * speed);
    }
}

