using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject[] Enemy = new GameObject[8];

    /*
     * Notes:
     * xBound is 30
     * 
        Enemies:


    */

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Round1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Level 1
    public IEnumerator Round1()
    {
        yield return new WaitForSeconds(4);
        SpawnEnemy(2, 0);
        SpawnEnemy(2, 15);
        SpawnEnemy(2, -15);
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy(1, 35, -60);
        SpawnEnemy(1, -35, -60);
        SpawnEnemy(2, -20);
        SpawnEnemy(2, 20);
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy(2, 0);
        for (int j = 0; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, j);
            SpawnEnemy(2, -j);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(2, 0);
        SpawnEnemy(3, 10);
        for (int j = 0; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, j);
            SpawnEnemy(2, -j);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(4, 15);
        SpawnEnemy(4, -15);
        yield return new WaitForSeconds(0.1f);
        SpawnEnemy(2, 0);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(5, 20);
        SpawnEnemy(5, 22);
        SpawnEnemy(5, 24);
        SpawnEnemy(2, -16);
        SpawnEnemy(2, -18);
        SpawnEnemy(2, -20);
        SpawnEnemy(2, -22);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(5, -22);
        SpawnEnemy(1, 0);
        yield return new WaitForSeconds(1f);
        SpawnEnemy(4, -15);
        SpawnEnemy(4, -30);
        SpawnEnemy(2, 0);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        for (float j = GameManager.instance.xBound; j > -GameManager.instance.xBound; j -= 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        SpawnEnemy(3, 20);
        for (float j = GameManager.instance.xBound; j > -GameManager.instance.xBound; j -= 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        SpawnEnemy(3, 10);
        SpawnEnemy(3, -10);
        for (float j = GameManager.instance.xBound; j > -GameManager.instance.xBound; j -= 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        SpawnEnemy(4, 0);
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        for (float j = GameManager.instance.xBound; j > -GameManager.instance.xBound; j -= 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        SpawnEnemy(5, 25);
        SpawnEnemy(1, -35, -70);
        SpawnEnemy(1, -35, -50);
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        for (float j = GameManager.instance.xBound; j > -GameManager.instance.xBound; j -= 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(1, -35, -50);
        SpawnEnemy(1, -35, -30);
        SpawnEnemy(1, -35, -10);
        SpawnEnemy(1, 35, -50);
        SpawnEnemy(1, 35, -30);
        SpawnEnemy(1, 35, -10);
        yield return new WaitForSeconds(1f);
        SpawnEnemy(1, 0);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(1, -35, -50);
        SpawnEnemy(3, -10);
        SpawnEnemy(5, 30);
        yield return new WaitForSeconds(1f);
        SpawnEnemy(3, 12);
        SpawnEnemy(3, 15);
        SpawnEnemy(3, 18);
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(1, 35, -10);
        SpawnEnemy(1, 35, -30);
        SpawnEnemy(1, -35, -10);
        SpawnEnemy(1, -35, -30);
        SpawnEnemy(4, -20);
        yield return new WaitForSeconds(2f);
        SpawnEnemy(4, 20);
        SpawnEnemy(1, 0);
        SpawnEnemy(2, 20);
        SpawnEnemy(2, -20);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        yield return new WaitForSeconds(4f);
        SpawnEnemy(7, 0); // Mini-Boss
        SpawnEnemy(1, 20);
        SpawnEnemy(1, -20);
        SpawnEnemy(2, 0);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        yield return new WaitForSeconds(2f);
        SpawnEnemy(4, 12);
        SpawnEnemy(4, 0);
        SpawnEnemy(5, -25);
        SpawnEnemy(3, 0);
        SpawnEnemy(1, 35, -20);
        SpawnEnemy(1, -35, -20);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        SpawnEnemy(1, 35, -20);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(2, 0);
        yield return new WaitForSeconds(1f);
        SpawnEnemy(2, 0);
        SpawnEnemy(2, 10);
        SpawnEnemy(2, -10);
        SpawnEnemy(6, 12);
        SpawnEnemy(6, -12);
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy(6, 12);
        SpawnEnemy(6, -12);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(6, 12);
        SpawnEnemy(6, -12);
        yield return new WaitForSeconds(0.7f);
        SpawnEnemy(6, 22);
        SpawnEnemy(6, -22);
        yield return new WaitForSeconds(0.7f);
        SpawnEnemy(6, 35, -15);
        SpawnEnemy(6, -35, -15);
        SpawnEnemy(4, 0);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(4, 0);
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy(4, -15);
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy(4, 15);
        SpawnEnemy(6, 0);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(5, -25);
        SpawnEnemy(5, 25);
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        yield return new WaitForSeconds(1f);
        SpawnEnemy(6, -35, -15);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(4, 10);
        SpawnEnemy(5, -10);
        SpawnEnemy(6, 35, -15);
        yield return new WaitForSeconds(1f);
        SpawnEnemy(6, 35, -15);
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy(6, 35, -15);
        yield return new WaitForSeconds(2f);
        SpawnEnemy(5, -15);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        SpawnEnemy(4, 5);
        for (float j = GameManager.instance.xBound; j > -GameManager.instance.xBound; j -= 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        SpawnEnemy(6, 35, -15);
        for (float j = GameManager.instance.xBound; j > -GameManager.instance.xBound; j -= 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        for (float j = -GameManager.instance.xBound; j < GameManager.instance.xBound; j += 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        for (float j = GameManager.instance.xBound; j > -GameManager.instance.xBound; j -= 5)
        {
            SpawnEnemy(2, (int)j);
            yield return new WaitForSeconds(0.1f);
        }
        SpawnEnemy(6, 35, -15);
        SpawnEnemy(6, -35, -15);
        SpawnEnemy(6, 0);
        yield return new WaitForSeconds(1f);
        SpawnEnemy(6, 0);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(4, 20);
        SpawnEnemy(4, -20);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(4, 21);
        SpawnEnemy(4, -21);
        SpawnEnemy(2, 5);
        SpawnEnemy(2, -5);
        SpawnEnemy(1, 0);
        SpawnEnemy(1, 35, -20);
        SpawnEnemy(1, -35, -20);
        yield return new WaitForSeconds(1f);
        SpawnEnemy(1, 35, -20);
        SpawnEnemy(1, -35, -20);
        yield return new WaitForSeconds(1f);
        SpawnEnemy(4, 0);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(3, -20);
        SpawnEnemy(3, 20);
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy(3, 0);
        yield return new WaitUntil(() => GameManager.instance.enemyCount <= 0);
        SpawnEnemy(8, 0);
        SpawnEnemy(3, 15);
    }

    // Spawns enemy
    private void SpawnEnemy(int EnemyType, int xAxis, int zAxis = 0)
    {
        GameManager.instance.enemyCount++;
        GameObject GetEnemy = Enemy[EnemyType - 1];
        Instantiate(GetEnemy, new Vector3(xAxis, transform.position.y, transform.position.z + zAxis), GetEnemy.transform.rotation);
    }
}
