using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private Camera cam;
    public float zoom;
    public float zoomScale;
    private float zoomMin;
    public float min = 9f;
    public float max = 18f;

    void Start()
    {
        cam = Camera.main;
        zoom = cam.orthographicSize;
        zoomMin = zoom;
    }

    void Update()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scrollData * 5f;
        zoom = Mathf.Clamp(zoom, min, max);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * 20f);
        zoomScale = min / cam.orthographicSize;
        zoomScale = Mathf.Clamp(zoomScale, 0.5f, 1.0f);
    }
}