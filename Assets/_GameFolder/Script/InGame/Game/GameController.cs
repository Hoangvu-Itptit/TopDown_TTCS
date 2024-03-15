using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public PlayerController player;
    public EnemyDataSO enemyData;
    public PlayerDataSO playerData;
    public GunDataSO gunData;
    public List<SpawnEnemyCtl> listPosSpawnEnemy;
    [SerializeField] private Transform posSpawnPlayer;
    [HideInInspector] public List<GameObject> listEnemySpawned;

    private void Awake()
    {
        Instance = this;
#if UNITY_EDITOR
        PrefData.player_type = 1;
#endif
        Init();
        StartCoroutine(SpawnEnemy());
    }

    private void Init()
    {
        var pData = playerData.listPlayerData[PrefData.player_type];
        player = Instantiate(pData.model).GetComponent<PlayerController>();
        player.transform.position = posSpawnPlayer.position;
        player.Init(pData);
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            SpawnNewEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnNewEnemy()
    {
        var rand = Random.Range(0, listPosSpawnEnemy.Count);
        listPosSpawnEnemy[rand].SpawnEnemy();
    }
}