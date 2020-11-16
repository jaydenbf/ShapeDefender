using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool rangeAttack; 
    int hitPoint = 4;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isAlive();
        /*
        Vector3 targetPos = GameObject.Find("Player").transform.position;
        if ((targetPos - gameObject.transform.position).magnitude < 1.5f)
        {
            Debug.Log("DESTROY");
            Destroy(transform.gameObject);
        }
        */
    }

    private void isAlive()
    {
        if(hitPoint <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Egg(Clone)")
        {
            hitPoint--;
        }
    }
}
