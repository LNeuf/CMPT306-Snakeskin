﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, lifeTime;
    public int damage;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            DestroyProjectile();
        }
    }
    
}
