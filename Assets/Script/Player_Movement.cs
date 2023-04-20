using UnityEditor.Search;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public GameObject topRightLimitGameobject;
    public GameObject bottomLeftLimitGameobject;

    public Vector3 topRightLimit;
    public Vector3 bottomLeftLimit;

    public Projectile laserPrefab;
    void Start () {
        // Set the cursor to not be visible
        Cursor.visible = false;
        topRightLimit = topRightLimitGameobject.transform.position;
        bottomLeftLimit = bottomLeftLimitGameobject.transform.position;
    }

    void Update() {
        // Get the mouse position and move the player to that position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

        transform.position = mousePosition;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y),
            transform.position.z
        );
        
        // Shoot when the left mouse button is pressed
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 laserOffset = new Vector3(0.6f, 0.36f, 0);
        Vector3 spawnPosition = transform.position + laserOffset;
        Instantiate(laserPrefab, spawnPosition, Quaternion.identity);
    }


}