using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject Player;
    public Transform[] spawnPoints;

    private void Start()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        Transform selectedSpawnPoint = spawnPoints[randomIndex];

        Player.transform.position = selectedSpawnPoint.position;    

        Player.transform.rotation = selectedSpawnPoint.rotation;
    }

}
