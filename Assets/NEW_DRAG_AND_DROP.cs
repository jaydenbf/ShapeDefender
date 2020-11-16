using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NEW_DRAG_AND_DROP : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler, IPointerDownHandler
{
    public Zoom zoom;

    public bool isDragging = false;
    public bool isColliding = false;

    Color normal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    Color transparent = new Color(1.0f, 1.0f, 1.0f, 0.85f);
    Color transparentRed = new Color(1.0f, 0.15f, 0.15f, 0.85f);

    public float size;

    public Vector3 pos = new Vector3(0, 0, 0);
    public bool newObject = true;
    public string name;
    public GameObject prefab;
    public float zoomedInTileSize = 60;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        size = transform.localScale.x;
    }

    void Update()
    {
        updateColor();
    }

    void updateColor()
    {
        if (isDragging)
        {
            GetComponent<Graphic>().color = transparent;
        }
        else
        {
            GetComponent<Graphic>().color = normal;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        transform.position = p;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        canvasGroup.blocksRaycasts = true;

        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;

        float x = 0.0f;
        float y = 0.0f;

        if(size % 2 == 0)
        {
            x = Mathf.Round(p.x);
            y = Mathf.Round(p.y);
        }
        else
        {
            x = Mathf.Floor(p.x) + 0.5f;
            y = Mathf.Floor(p.y) + 0.5f;
        }

        transform.position = new Vector3(x, y);

        Debug.Log(x + ", " + y);
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    private void onMouseOver()
    {

    }

    private void onMouseUp()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void OnTriggerStay2D(Collider2D collision)
    {

    }

    public void OnTriggerExit2D(Collider2D collision)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}