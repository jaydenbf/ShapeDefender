using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerClickHandler
{
    public bool isDragging = false;
    public bool isColliding = false;
    public int size;
    public Vector3 pos = new Vector3(0, 0, 0);
    public bool newObject = true;
    public string name;
    public GameObject prefab;

    private CanvasGroup canvasGroup;
    private static Shop shop = null;
    public static void InitializeShop(Shop s) { shop = s; }

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if(gameObject.name == "Red Square")
        {
            prefab = Resources.Load<GameObject>("Prefabs/Red Square") as GameObject;

        } else if(gameObject.name == "Green Square")
        {
            prefab = Resources.Load<GameObject>("Prefabs/Green Square") as GameObject;

        } else if(gameObject.name == "Blue Square")
        {
            prefab = Resources.Load<GameObject>("Prefabs/Blue Square") as GameObject;
        }
    }

    void FixedUpdate()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isColliding)
        {
            string n = gameObject.name;
            Debug.Log(n);

            GameObject g = Instantiate(prefab);
        }

        if (shop.canAfford(gameObject.name))
        {

            isDragging = true;

            pos = transform.position;

            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(shop.canAfford(gameObject.name))
        {
            if (isColliding)
            {
                if (newObject)
                {
                    Destroy(transform.gameObject);
                    return;

                }
                else
                {
                    transform.position = pos;
                    canvasGroup.blocksRaycasts = true;
                    return;
                }
            }

            isDragging = false;

            if (newObject)
            {
                int p = 0;

                if (gameObject.name == "Red Square")
                {
                    p = shop.redPrice;
                    shop.redCount++;

                }
                else if (gameObject.name == "Green Square")
                {
                    p = shop.greenPrice;
                    shop.greenCount++;

                }
                else if (gameObject.name == "Blue Square")
                {
                    p = shop.bluePrice;
                    shop.blueCount++;
                }

                shop.cash -= p;
            }

            newObject = false;

            float x = Mathf.Round(Input.mousePosition.x / 60f) * 60f;
            float y = Mathf.Round(Input.mousePosition.y / 60f) * 60f;

            if (size % 2 != 0)
            {
                x = Mathf.Floor(Input.mousePosition.x / 60f) * 60f;
                y = Mathf.Floor(Input.mousePosition.y / 60f) * 60f;
                x += 60f / 2f;
                y += 60f / 2f;
            }

            transform.position = new Vector3(x, y);

            Graphic g = GetComponent<Graphic>();
            Color c = g.color;
            c.a = 1f;
            GetComponent<Graphic>().color = c;

            canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(shop.canAfford(gameObject.name))
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;

            transform.position = new Vector3(x, y);

            Graphic g = GetComponent<Graphic>();
            Color c = g.color;
            c.a = 0.85f;
            GetComponent<Graphic>().color = c;
        }
    }

    private void onMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }
    }

    private void onMouseUp()
    {
        isDragging = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        isColliding = true;

        if (collision.gameObject.name != name && !newObject)
        {
            Graphic g = GetComponent<Graphic>();
            Color c = g.color;
            c.b = 0.15f;
            c.g = 0.15f;
            c.a = 0.85f;
            GetComponent<Graphic>().color = c;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;

        if(collision.gameObject.name == name)
        {
            Vector3 s = new Vector3((float) size * 60f, (float) size * 60f);
            transform.localScale = s;
        }

        Graphic g = GetComponent<Graphic>();
        Color c = g.color;
        c.b = 1f;
        c.g = 1f;
        c.a = 1f;
        GetComponent<Graphic>().color = c;
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && !newObject)
        {
            string n = gameObject.name;

            if (n == "Red Square")
            {
                shop.redCount--;
                shop.cash += shop.redPrice;

            } else if(n == "Green Square")
            {
                shop.greenCount--;
                shop.cash += shop.greenPrice;

            } else if(n == "Blue Square")
            {
                shop.blueCount--;
                shop.cash += shop.bluePrice;
            }

            Destroy(transform.gameObject);
        }
    }
}