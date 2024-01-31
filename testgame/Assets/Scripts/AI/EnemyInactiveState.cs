using UnityEngine;

public class EnemyInactiveState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy is in the inactive state");
    }


    public override void UpdateState(EnemyStateManager enemy)
    {
        //if the enemy can see the player...
        if(enemy.CanSeePlayer)
        {
            //switch to the chase state
            enemy.SwitchState(enemy.chaseState);
        }
    }

    public override void ExitState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy is exiting the inactive state");
    }

}
