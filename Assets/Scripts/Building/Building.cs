using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    private float health;
    private Color defaultColor;
    // Add resource type


    public abstract void connectBuilding(GameObject build);
    public abstract void disconnectBuilding(GameObject build);
    public abstract void takeDamage(float damage);
    public abstract float getHealth();
    public abstract void resourceHander();
    public abstract void receiveResource(float[] recievedResources);
    public abstract void sendResource();
    public abstract float[] resourceTotal();
}
