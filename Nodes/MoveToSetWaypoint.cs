using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveToSetWaypoint : Node
{
    private UnityEngine.AI.NavMeshAgent agent;
    private EnemyAI enemyAI;
    private Animator anim;

    public MoveToSetWaypoint(UnityEngine.AI.NavMeshAgent agent, EnemyAI enemyAI, Animator anim){
        this.agent = agent;
        this.enemyAI = enemyAI;
        this.anim = anim;
    }

    //Heads towards a waypoint within the enemyInvestigateWaypoints list and removes them from the list once they are reached
    public override NodeState Evaluate(){
        
        if(enemyAI.enemyInvestigateWaypoints.Count == 0){
            return NodeState.FAILURE;
        }

        float distance = Vector3.Distance(enemyAI.enemyInvestigateWaypoints[0], agent.transform.position);

        if(distance > 1.1){
            agent.isStopped = false;
            agent.SetDestination(enemyAI.enemyInvestigateWaypoints[0]);
            return NodeState.RUNNING;
        }
        else if(distance <= 1.1){
            agent.isStopped = true;
            enemyAI.activateTimer = true;
            anim.SetBool("IsSearching", true);

            if(enemyAI.timer >= enemyAI.waitTime){
                anim.SetBool("IsSearching", false);
                enemyAI.enemyInvestigateWaypoints.RemoveAt(0);
                enemyAI.resetTimer = true;
                return NodeState.SUCCESS;   
            }
            return NodeState.RUNNING;
        }
        else{
            return NodeState.RUNNING;
        }
    }
}
