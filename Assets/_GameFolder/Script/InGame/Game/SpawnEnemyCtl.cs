using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEnemyCtl : MonoBehaviour
{
    public void SpawnEnemy()
    {
        var newEnemy = GetDiedEnemy();
    }

    GameObject GetDiedEnemy()
    {
        var listEnemySpawned = GameController.Instance.listEnemySpawned;
        var listEnemyPrefabs = GameController.Instance.enemyData.listEnemyData;

        var newEnemy = listEnemySpawned.FirstOrDefault(enemy => enemy.activeInHierarchy == false);
        if (newEnemy != null)
        {
            newEnemy.transform.position = transform.position;
            newEnemy.SetActive(true);
            return newEnemy;
        }

        var rand = Random.Range(0, listEnemyPrefabs.Count);
        newEnemy = Instantiate(listEnemyPrefabs[rand].model, transform.position, Quaternion.identity);
        var enemy = newEnemy.GetComponent<BaseEnemy>();
        // enemy.maxHp = listEnemyPrefabs[rand].hp;
        // enemy.damage = listEnemyPrefabs[rand].damage;
        // enemy.moveSpeed = listEnemyPrefabs[rand].moveSpeed;
        // enemy.avatar = listEnemyPrefabs[rand].avatar;
        enemy.Init(listEnemyPrefabs[rand]);
        listEnemySpawned.Add(newEnemy);
        return newEnemy;
    }
}