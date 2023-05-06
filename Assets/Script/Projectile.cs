using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Vector3 direction;

    public Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void Update() {
        this.transform.position += direction * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Destroy(gameObject);
    }
}
