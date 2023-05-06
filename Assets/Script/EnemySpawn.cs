using UnityEngine;
using System.Collections;


public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyRB;
    public float interval = 10f;

    void Start()
    {
        StartCoroutine(InstantiateEnemyCoroutine());
    }

    IEnumerator InstantiateEnemyCoroutine() {
        while (true) {
            InstantiateEnemy();
            yield return new WaitForSeconds(interval);
        }
    }

    void InstantiateEnemy () {
        if (Player.instance.health == 0) {
            return;
        }
        Vector3 randomPosition = new Vector3(this.transform.position.x, Random.Range(-9f, 9f), 0);
        Instantiate(enemyRB, randomPosition, Quaternion.identity);
    }

    void Update()
    {
        if (Player.instance.health == 0) {
            StopCoroutine(InstantiateEnemyCoroutine());
        }
    }
}
