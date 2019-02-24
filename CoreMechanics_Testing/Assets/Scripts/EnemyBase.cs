using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public delegate void OnPlayerDeath(Enemy enemy);
    public event OnPlayerDeath OnPlayerDeathEvent;

    public void RaiseOnPlayerDeathEvent(Enemy enemy)
    {
        OnPlayerDeathEvent(enemy);
    }

}
