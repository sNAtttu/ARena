using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUtilities : MonoBehaviour
{

    private PlayMakerFSM enemyFsm;

    private void Start()
    {
        enemyFsm = GetComponent<PlayMakerFSM>();
    }

    public void SendEnemyFsmEvent(string fsmEvent)
    {
        enemyFsm.SendEvent(fsmEvent);
    }
}
