using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyRB;
    public float interval;
    public static float enemySpeed = 5f;
    public float speedUpdateInterval = 5f;
    public float speedIncreaseAmount = 2f;

    private void Start()
    {
        StartCoroutine(InstantiateEnemyCoroutine());
        StartCoroutine(UpdateSpeedCoroutine());
    }

    IEnumerator InstantiateEnemyCoroutine()
    {
        while (true)
        {
            InstantiateEnemy();
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator UpdateSpeedCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedUpdateInterval);
            UpdateEnemySpeed();
        }
    }

    void InstantiateEnemy()
    {
        if (Player.instance.health == 0)
        {
            return;
        }

        Vector3 randomPosition = new Vector3(this.transform.position.x, Random.Range(-9f, 9f), 0);
        GameObject enemyObj = Instantiate(enemyRB, randomPosition, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.direction = Vector3.left; // Set the desired direction
        enemy.SetSpeed(enemySpeed); // Set the initial speed
    }

    void UpdateEnemySpeed()
    {
        enemySpeed += speedIncreaseAmount;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.SetSpeed(enemySpeed);
        }
    }

    void Update()
    {
        if (Player.instance != null && Player.instance.health == 0)
        {
            StopAllCoroutines();
        }
    }
}
