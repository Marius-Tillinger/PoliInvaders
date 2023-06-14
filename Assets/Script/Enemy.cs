using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private float health = 5f;
    public Vector3 direction;
    public Rigidbody2D rb;
    public DoubleFire _doubleFirePU;
    private System.Random rnd = new System.Random();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    public void SetSpeed(float speed)
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Projectile projectile = hitInfo.GetComponent<Projectile>();
        if (projectile != null)
        {
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject);
                if (rnd.Next(0, 100) > 70)
                {
                    Instantiate(_doubleFirePU, this.transform.position, Quaternion.identity);
                }
                if (Score.instance != null)
                {
                    Score.instance.AddScore(1);
                }
            }
        }
    }
}
