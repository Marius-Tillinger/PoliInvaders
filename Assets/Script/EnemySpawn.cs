using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyRB;
    public float interval = 10f;

    void Start()
    {
        InvokeRepeating("InstantiateEnemy", 0f, interval);
    }

    void InstantiateEnemy () {
        Vector3 randomPosition = new Vector3(this.transform.position.x, Random.Range(-9f, 9f), 0);
        Instantiate(enemyRB, randomPosition, Quaternion.identity);
    }
}
