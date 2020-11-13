using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private Camera cam;
    private float zoom;
    private float zoomMin; 

    void Start()
    {
        cam = Camera.main;
        zoom = cam.orthographicSize;
        zoomMin = zoom;
    }

    void Update()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scrollData * 3f;
        zoom = Mathf.Clamp(zoom, 9f, 14.5f);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * 10f);
    }
}