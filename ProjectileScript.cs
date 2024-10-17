using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //This script makes the projectile move and destroy after 1 second
    public Vector3 projectileMove;
    public float projectileTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position += projectileMove;

        projectileTimer += Time.deltaTime;
        if (projectileTimer > 1f)
        {
            Destroy(gameObject);
        }
    }
}
