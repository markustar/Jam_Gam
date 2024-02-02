using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    //The "Start" function for the attack state
    public override void EnterState(EnemyStateManager enemy)
    {

    }


    //The "Update" function for the attack state
    public override void UpdateState(EnemyStateManager enemy)
    {
        Vector3 targetPos = new Vector3(enemy.Target.transform.position.x, enemy.transform.position.y, enemy.Target.transform.position.z);

        //set the destination to be the target
        enemy.Agent.SetDestination(enemy.Target.transform.position);

        enemy.transform.LookAt(targetPos);

        //checks if the target is in range
        CheckIfTargetIsInRange(enemy);
    }


    //What happens when this state is exited
    public override void ExitState(EnemyStateManager enemy)
    {
  
    }


    public void CheckIfTargetIsInRange(EnemyStateManager enemy)
    {
        //sets the min distance to be equal to the agents stopping distance
        float minDistance = enemy.Agent.stoppingDistance;

        //sets the distance
        float distance = Vector3.Distance(enemy.Target.transform.position, enemy.transform.position);



        //if the ai enemy is close to the player...
        if (distance <= (minDistance + 2))
        {
            //switch to attack state
            enemy.SwitchState(enemy.attackState);
        }
    }
}
