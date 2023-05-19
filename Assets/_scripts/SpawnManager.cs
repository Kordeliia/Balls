using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPrefab;
    public GameObject enemyPrefab;
    private float spawnRange = 9f;
    int numberOfEnemies2 = 3;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(numberOfEnemies2);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            numberOfEnemies2 += 2;
            SpawnEnemyWave(numberOfEnemies2);
            int random = Random.Range(0, spawnPrefab.Length);
            int random2 = Random.Range(0, 3);
            for(int i = 0; i < random2; i++)
            {
                Instantiate(spawnPrefab[random], GenerateSpawnPosition(spawnRange), spawnPrefab[random].transform.rotation);
            }
        }
    }
    /// <summary>
    /// Esta función genera una posición aleatoria dado un rango para x y z, ya que y será 0
    /// </summary>
    /// <param name="spawnRange">parámetro para introducir el rango para generar el punto aleatorio</param>
    /// <returns> devuelve el Vector3 randomPos con la pos aleatoria</returns>
    Vector3 GenerateSpawnPosition(float spawnRange)
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange + 1);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange + 1);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    /// <summary>
    /// Método que genera un número determinado de enemigos en pantalla
    /// </summary>
    ///  /// <param name="numberOfEnemies">número de enemigos a spawnear</param>
    private void SpawnEnemyWave(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(spawnRange), enemyPrefab.transform.rotation);
        }
    }
}
