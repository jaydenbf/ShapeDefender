using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 targetPos = GameObject.Find("Player").transform.position;
        if((targetPos - gameObject.transform.position).magnitude < 1.5f) {
            Debug.Log("DESTROY");
            Destroy(transform.gameObject);
        }

    }
}
