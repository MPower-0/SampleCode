using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveToPlayerHeardWaypoint : Node
{
    private UnityEngine.AI.NavMeshAgent agent;
    private EnemyAI enemyAI;

    public MoveToPlayerHeardWaypoint(UnityEngine.AI.NavMeshAgent agent, EnemyAI enemyAI){
        this.agent = agent;
        this.enemyAI = enemyAI;
    }

    //Moves to the waypoints in the playerHeardWaypoints list
    //Once the waypoint is reached it is removed from the list
    public override NodeState Evaluate(){
        if(enemyAI.playerHeardWaypoints.Count == 0){
            return NodeState.FAILURE;
        }

        enemyAI.GenerateInvestigateWaypoints();
        float distance = Vector3.Distance(enemyAI.playerHeardWaypoints[0], agent.transform.position);

        if(distance > 1.1){
            agent.isStopped = false;
            agent.SetDestination(enemyAI.playerHeardWaypoints[0]);
            return NodeState.RUNNING;
        }
        else{
            enemyAI.playerHeardWaypoints.RemoveAt(0);
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}
