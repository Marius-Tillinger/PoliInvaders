using UnityEditor.Search;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public GameObject topRightLimitGameobject;
    public GameObject bottomLeftLimitGameobject;

    private Vector3 topRightLimit;
    private Vector3 bottomLeftLimit;

    public Projectile laserPrefab;
    private void Start () {
        // Set the cursor to not be visible
        Cursor.visible = false;
        topRightLimit = topRightLimitGameobject.transform.position;
        bottomLeftLimit = bottomLeftLimitGameobject.transform.position;
    }



    private void Update() {
        // Get the mouse position and move the player to that position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

        transform.position = mousePosition;

        if(transform.position.x < bottomLeftLimit.x){
            transform.position = new Vector3(bottomLeftLimit.x, transform.position.y , transform.position.z);
        }

        if(transform.position.y < bottomLeftLimit.y){
            transform.position = new Vector3(transform.position.x, bottomLeftLimit.y , transform.position.z);
        }

        if(transform.position.x > topRightLimit.x){
            transform.position = new Vector3(topRightLimit.x, transform.position.y , transform.position.z);
        }

        if(transform.position.y > topRightLimit.y){
            transform.position = new Vector3(transform.position.x, topRightLimit.y , transform.position.z);
        }


        // Shoot when the left mouse button is pressed
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
    }
}
