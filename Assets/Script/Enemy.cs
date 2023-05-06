using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 20f;
    public float health;
    public Vector3 direction;

    public Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        health = 5f;

    }
    
    private void Update()
    {
        this.transform.position += direction * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Projectile projectile = hitInfo.GetComponent<Projectile>();
        if (projectile != null) {
            health -= 1;
            if (health <= 0) {
                Destroy(gameObject);
                if (Score.instance != null) {
                    Score.instance.AddScore(1);
}
            }
        }
    }
}
