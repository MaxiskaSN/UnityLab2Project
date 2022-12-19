using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Obj;
    private Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        camera.transform.LookAt(Obj);
    }
}
