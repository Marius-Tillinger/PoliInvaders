using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    public float speed = 20f;
    public float health;
    public Vector3 direction;
    public Rigidbody2D rb;
    public DoubleFire _doubleFirePU;
    Random rnd = new Random();

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
                rnd.Next(0, 100);
                if (rnd.Next(0, 100) > 50) {
                    Instantiate(_doubleFirePU, this.transform.position, Quaternion.identity);
                }
                if (Score.instance != null) {
                    Score.instance.AddScore(1);
}
            }
        }
    }
}
