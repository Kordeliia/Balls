using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUpManager : MonoBehaviour
{
    public GameObject[] spawnPrefab;
    private float spawnRange = 9f;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, spawnPrefab.Length);

        Instantiate(spawnPrefab[random], GenerateSpawnPosition(spawnRange), spawnPrefab[random].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// Esta funci�n genera una posici�n aleatoria dado un rango para x y z, ya que y ser� 0
    /// </summary>
    /// <param name="spawnRange">par�metro para introducir el rango para generar el punto aleatorio</param>
    /// <returns> devuelve el Vector3 randomPos con la pos aleatoria</returns>
    Vector3 GenerateSpawnPosition(float spawnRange)
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange + 1);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange + 1);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
