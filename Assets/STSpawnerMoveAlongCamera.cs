using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STSpawnerMoveAlongCamera : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = _camera.transform.position;
        transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
    }
}
