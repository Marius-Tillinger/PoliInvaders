using UnityEngine;

public class DoubleFire : MonoBehaviour
{
    public static bool DFactive = false;
    private void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null) {
            DFactive = true;
            Destroy(gameObject);
        }
    }
}
