using UnityEngine;

public class DoubleFire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null) {
            Destroy(gameObject);
        }
    }
}
