using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public Rigidbody2D rb;

    private void Start() {
        health = 5f;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            health -= 1;
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
