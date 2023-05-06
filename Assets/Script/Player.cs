using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float health;
    public Rigidbody2D rb;

    private void Awake() {
        instance = this;
    }

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
                if (Score.instance != null) {
                    Score.instance.SetHighScore();
                    Score.instance.ShowHighScore();
                }
            }
        }
    }
}
