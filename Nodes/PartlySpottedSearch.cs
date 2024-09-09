using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartlySpottedSearch : Node
{
    private UnityEngine.AI.NavMeshAgent agent;
    private FieldOfView fov;
    private EnemyAI enemyAI;

    public PartlySpottedSearch(UnityEngine.AI.NavMeshAgent agent, EnemyAI enemyAI, FieldOfView fov){
        this.agent = agent;
        this.fov = fov;
        this.enemyAI = enemyAI;
    }
    
    //Heads to the position where the player was partly spotted
    //Destination is set and once it is reached the agent stopped

    public override NodeState Evaluate(){
        
        float distance = Vector3.Distance(enemyAI.partlySpottedPlayerPos, agent.transform.position);
        if(distance > 1.1){
            UnityEngine.MonoBehaviour.print("partlySpotted");
            agent.isStopped = false;
            agent.SetDestination(enemyAI.partlySpottedPlayerPos);
            return NodeState.RUNNING;
        }
        else{
            agent.isStopped = true;
            fov.partlySpotted = false;
            return NodeState.SUCCESS;
        }
    }
}
