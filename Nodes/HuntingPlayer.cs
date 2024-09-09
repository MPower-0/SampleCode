using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingPlayer : Node
{
    private UnityEngine.AI.NavMeshAgent agent;
    private EnemyAI enemyAI;
    private Animator anim;


    public HuntingPlayer(EnemyAI enemyAI, UnityEngine.AI.NavMeshAgent agent, Animator anim){
        this.anim = anim;
        this.enemyAI = enemyAI;
        this.agent = agent;
    }
    

    //Heads to where the player was last spotted when hunting mode is activated
    //Also changes the speed and angular speed back to the normal values 
    public override NodeState Evaluate(){

        float distance = Vector3.Distance(enemyAI.huntingForPlayerPosition, agent.transform.position);
        if(distance > 1.1){
            agent.isStopped = false;
            agent.SetDestination(enemyAI.huntingForPlayerPosition);
            return NodeState.RUNNING;
        }
        else{
            anim.SetBool("IsChasing", false);
            agent.speed = 4;
            agent.angularSpeed = 120;
            agent.isStopped = true;
            enemyAI.huntingMode = false;
            return NodeState.SUCCESS;
        }
    }
}
