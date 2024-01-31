using System.Collections;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    //The "Start" function for the attack state
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy is in the attack state");
        enemy.StartCoroutine(Attack(enemy));
    }


    //The "Update" function for the attack state
    public override void UpdateState(EnemyStateManager enemy)
    {
        
    }


    //What happens when this state is exited
    public override void ExitState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy is exiting the attack state");

        //stops the coroutine on exit
        enemy.StopCoroutine(Attack(enemy));
        
    }



    public IEnumerator Attack(EnemyStateManager enemy)
    {
        //call the attack event
        Debug.Log("Attacking...");
        EnemyStateManager.onAttack?.Invoke();

        //wait a second
        yield return new WaitForSeconds(2f);

        //switch to chase state
        enemy.SwitchState(enemy.chaseState);
       
        
    }
}
