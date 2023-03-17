using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Vector3 direction;

    // private void Start() {
    //     rb.velocity = transform.right * speed;
    // }

    private void Update() {
        this.transform.position += direction * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        // Enemy enemy = hitInfo.GetComponent<Enemy>();
        // if (enemy != null) {
        //     enemy.TakeDamage(1);
        // }

        Destroy(gameObject);
    }
}
