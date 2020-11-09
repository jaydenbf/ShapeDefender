using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    int hitPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isAlive();
    }

    private void isAlive()
    {
        if(hitPoint > 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.Debug.Log(collision.name);
        if (collision.name == "Egg(Clone)")
        {
            hitPoint++;
        }
    }
}
