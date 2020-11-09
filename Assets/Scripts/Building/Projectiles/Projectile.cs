using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // All instance of Projectiles share this one Projectile Spawn System
    private static ProjectileSpawnSystem sProjectileSystem = null;
    public static void InitializesProjectileSystem(ProjectileSpawnSystem p) { sProjectileSystem = p; }

    private const float kProjectileSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kProjectileSpeed * Time.smoothDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Triangle")
        {
            gameObject.SetActive(false);  // set inactive!
            Destroy(this.gameObject);
        }
       
    }

    private void DestroyThisProjectile(string name)
    {
        // Watch out!! a collision with overlap objects (e.g., two objects at the same location 
        // will result in two OnTriggerEntger2D() calls!!
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);  // set inactive!
            Destroy(this);
        }
    }
}
