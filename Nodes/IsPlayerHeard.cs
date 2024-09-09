using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerHeard : Node
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform playerTransform;
    private PlayerCrouch playerCrouch;
    private PlayerMovement playerMovement;
    private EnemyAI enemyAI;

    public IsPlayerHeard(PlayerCrouch playerCrouch, PlayerMovement playerMovement, UnityEngine.AI.NavMeshAgent agent, Transform playerTransform, EnemyAI enemyAI){
        this.playerCrouch = playerCrouch;
        this.playerMovement = playerMovement;
        this.agent = agent;
        this.playerTransform = playerTransform;
        this.enemyAI = enemyAI;
    }

    //Checks whether the player has been heard based on movement, whether they are crouched, how close they are and whether they can allowed to be heard
    //Last variable enemyAI.canPlayerBeHeard is set to false when the node is evaluated to prevent the entire sequence continually looping and preventing the AI from moving to waypoints
    public override NodeState Evaluate(){

        float distance = Vector3.Distance(playerTransform.position, agent.transform.position); 

        if(playerMovement.isMoving == true && playerCrouch.crouched == false && distance <= 15.0f && enemyAI.canPlayerBeHeard){
            enemyAI.canPlayerBeHeard = false;
            return NodeState.SUCCESS;
        }
        else if(playerMovement.isMoving == true && playerCrouch.crouched == true && distance <= 6.0f && enemyAI.canPlayerBeHeard){
            enemyAI.canPlayerBeHeard = false;
            return NodeState.SUCCESS;
        }
        else{
            return NodeState.FAILURE;
        }
    }
}
