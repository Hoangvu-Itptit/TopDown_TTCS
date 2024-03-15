using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData : HumanData
{
    public float damage;
    public EnemyType enemyType;
}

public enum EnemyType
{
    Kurniawan,
    Ornn,
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "datas/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    public List<EnemyData> listEnemyData;
}