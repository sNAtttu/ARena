using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchHandler : MonoBehaviour
{
    private EnemyUtilities enemyUtilities;

    private void Start()
    {
        enemyUtilities = GetComponent<EnemyUtilities>();
    }

    internal void HandleCollisionEvent(string tag)
    {
        if (tag == Utilities.EnemyConstants.TagEnemyBody)
        {
            enemyUtilities.SendEnemyFsmEvent(Utilities.EnemyConstants.EventSelectBody);
        }
        else if (tag == Utilities.EnemyConstants.TagEnemyHead)
        {
            enemyUtilities.SendEnemyFsmEvent(Utilities.EnemyConstants.EventSelectHead);
        }
        else if (tag == Utilities.EnemyConstants.TagEnemyLeftArm)
        {
            enemyUtilities.SendEnemyFsmEvent(Utilities.EnemyConstants.EventSelectLeftArm);
        }
        else if (tag == Utilities.EnemyConstants.TagEnemyRightArm)
        {
            enemyUtilities.SendEnemyFsmEvent(Utilities.EnemyConstants.EventSelectRightArm);
        }
    }
}
