using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float health;
    public Rigidbody2D rb;

    public SpriteRenderer playerSr;
    public Player_Movement playerMov;

    private Projectile projectileScript;

    public Sprite defaultSprite;
    public Sprite hurtSprite;
    public float hurtDuration = 0.25f;
    public float hurtTimer = 0.0f;

    public Sprite newSprite;

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
                //Destroy(gameObject);

                
                if (projectileScript != null) {
                    projectileScript.enabled = false;
                }

                playerSr.enabled = false;
                playerMov.enabled = false;

                if (Score.instance != null) {
                    Score.instance.SetHighScore();
                    Score.instance.ShowHighScore();
                }
            }
            else{
                 playerSr.sprite = hurtSprite;
                hurtTimer = hurtDuration;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            playerSr.sprite = newSprite;
        }

        if (hurtTimer > 0) {
            hurtTimer -= Time.deltaTime;
            if (hurtTimer <= 0) {
                playerSr.sprite = defaultSprite;
            }
        }

    }

}
