using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class NEW_DRAG_AND_DROP : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler, IPointerDownHandler
{
    public Zoom zoom;
    public Tile tile;
    public Tilemap tilemap;

    private bool isDragging = false;
    private bool isColliding = false;
    private bool isPlaced = false;
    public bool isMovableAfterPlaced = false;

    Color normal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    Color transparent = new Color(1.0f, 1.0f, 1.0f, 0.85f);
    Color transparentRed = new Color(1.0f, 0.15f, 0.15f, 0.85f);

    public float size;
    public GameObject prefab;
    private Vector3 initialPosition;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        size = transform.localScale.x;
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        updateColor();
    }

    void updateColor()
    {
        if (isColliding)
        {
            GetComponent<Graphic>().color = transparentRed;
        } else if(isDragging)
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
        if(!isPlaced || isMovableAfterPlaced)
        {
            isDragging = true;
            canvasGroup.blocksRaycasts = false;

            if (size == 1)
            {
                Vector3Int cell;
                cell = tilemap.WorldToCell(transform.position);
                tilemap.SetTile(cell, null);
            }
            else if (size == 2)
            {
                Vector3Int TR;
                TR = tilemap.WorldToCell(transform.position);
                tilemap.SetTile(TR, null);

                Vector3Int TL;
                TL = tilemap.WorldToCell(new Vector3(transform.position.x - 1, transform.position.y));
                tilemap.SetTile(TL, null);

                Vector3Int BL;
                BL = tilemap.WorldToCell(new Vector3(transform.position.x - 1, transform.position.y - 1));
                tilemap.SetTile(BL, null);

                Vector3Int BR;
                BR = tilemap.WorldToCell(new Vector3(transform.position.x, transform.position.y - 1));
                tilemap.SetTile(BR, null);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!isPlaced || isMovableAfterPlaced)
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f;
            transform.position = p;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!isPlaced || isMovableAfterPlaced)
        {
            if(isColliding)
            {
                transform.localPosition = initialPosition;

                isPlaced = true;
                isDragging = false;
                canvasGroup.blocksRaycasts = true;
                return;
            }

            isPlaced = true;
            isDragging = false;
            canvasGroup.blocksRaycasts = true;

            initialPosition = transform.localPosition;

            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f;

            float x = 0.0f;
            float y = 0.0f;

            if (size % 2 == 0)
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

            if (size == 1)
            {
                Vector3Int cell;
                cell = tilemap.WorldToCell(transform.position);
                tilemap.SetTile(cell, tile);
            }
            else if (size == 2)
            {
                Vector3Int TR;
                TR = tilemap.WorldToCell(transform.position);
                tilemap.SetTile(TR, tile);

                Vector3Int TL;
                TL = tilemap.WorldToCell(new Vector3(transform.position.x - 1, transform.position.y));
                tilemap.SetTile(TL, tile);

                Vector3Int BL;
                BL = tilemap.WorldToCell(new Vector3(transform.position.x - 1, transform.position.y - 1));
                tilemap.SetTile(BL, tile);

                Vector3Int BR;
                BR = tilemap.WorldToCell(new Vector3(transform.position.x, transform.position.y - 1));
                tilemap.SetTile(BR, tile);
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
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
        isColliding = true;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        isColliding = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
}