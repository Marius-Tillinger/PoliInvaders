using UnityEngine;
using System;

public class Player_PU : MonoBehaviour
{
    bool doubleFire = false;
    public Projectile laserPrefab;
    void Update() 
    {
        // Shoot when the left mouse button is pressed
        if (Input.GetMouseButtonDown(0) && doubleFire) 
        {
            DoubleShoot();
        }

        if (Input.GetMouseButtonDown(0) && !doubleFire) 
        {
            Shoot();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DoubleFirePU"))
        {
            doubleFire = true;
            Debug.Log(doubleFire);
        }
    }

    void Shoot()
    {
        Vector3 laserOffset = new Vector3(0.99f, 0.36f, 0);
        Vector3 spawnPosition = transform.position + laserOffset;
        Instantiate(laserPrefab, spawnPosition, Quaternion.identity);
    }

    void DoubleShoot()
    {
        Vector3[] laserOffsets = { new Vector3(0.99f, 0.43f, 0), new Vector3(0.99f, 0.27f, 0) };

        foreach (Vector3 offset in laserOffsets)
        {
            Vector3 spawnPosition = transform.position + offset;
            Instantiate(laserPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
