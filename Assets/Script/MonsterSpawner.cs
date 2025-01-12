using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs;  
    public float spawnDistance = 5f;    
    public float spawnInterval = 3f;     
    public Transform player;             

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnMonster", 0f, spawnInterval); 
    }

    void SpawnMonster()
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float screenHeight = mainCamera.orthographicSize * 2f;              

        Vector3 spawnPosition = Vector3.zero;

        int spawnSide = Random.Range(0, 4);
        switch (spawnSide)
        {
            case 0: // 왼쪽
                spawnPosition = new Vector3(cameraPosition.x - screenWidth - spawnDistance, player.position.y, Random.Range(cameraPosition.z - screenHeight / 2f, cameraPosition.z + screenHeight / 2f));
                break;
            case 1: // 오른쪽
                spawnPosition = new Vector3(cameraPosition.x + screenWidth + spawnDistance, player.position.y, Random.Range(cameraPosition.z - screenHeight / 2f, cameraPosition.z + screenHeight / 2f));
                break;
            case 2: // 위쪽
                spawnPosition = new Vector3(Random.Range(cameraPosition.x - screenWidth / 2f, cameraPosition.x + screenWidth / 2f), player.position.y, cameraPosition.z + screenHeight + spawnDistance);
                break;
            case 3: // 아래쪽
                spawnPosition = new Vector3(Random.Range(cameraPosition.x - screenWidth / 2f, cameraPosition.x + screenWidth / 2f), player.position.y, cameraPosition.z - screenHeight - spawnDistance);
                break;
        }

        // 랜덤한 몬스터 프리팹을 선택해서 스폰
        int randomIndex = Random.Range(0, monsterPrefabs.Length);
        Instantiate(monsterPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }
}