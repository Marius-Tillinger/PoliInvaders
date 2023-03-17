using UnityEditor.Search;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Projectile laserPrefab;
    private void Start () {
        // Set the cursor to not be visible
        Cursor.visible = false;
    }

    private void Update() {
        // Get the mouse position and move the player to that position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

        transform.position = mousePosition;
        
        // Shoot when the left mouse button is pressed
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
    }
}
