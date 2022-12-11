using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    private float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance;

        if (gameManager.IsGameOver())
        {
            return;
        }
        
        cooldown -= Time.deltaTime;
        if(cooldown <= 0f)
        {
            cooldown = gameManager.obstacleInterval;
            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];
            float x = gameManager.obstacleOffsetX;
            float y = Random.Range(gameManager.obstacleOffsetY.x, gameManager.obstacleOffsetY.y);
            Quaternion rotation = prefab.transform.rotation;
            Vector3 position = new Vector3(x, y, 3f);
            Instantiate(prefab, position, rotation);
        }
        
    }
}
