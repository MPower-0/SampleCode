using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : Node
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform target;
    private FieldOfView fov;
    private EnemyAI enemyAI;
    private Animator anim;

    public ChasePlayer(UnityEngine.AI.NavMeshAgent agent, Transform target, FieldOfView fov, EnemyAI enemyAI, Animator anim){
        this.agent = agent;
        this.target = target;
        this.fov = fov;
        this.enemyAI = enemyAI;
        this.anim = anim;
    }

    //As long as the player is still in vision they are directly chased after and the node is set to RUNNING
    //otherwise if the player is reached the node is SUCCESS else its FAILURE if the player is no longer in vision
    public override NodeState Evaluate(){
        float distance = Vector3.Distance(target.position, agent.transform.position);
        if(fov.canSeePlayer){
            agent.speed = 8;
            agent.angularSpeed = 180;
            if(distance > 0.1f){
                anim.SetBool("IsChasing", true);
                agent.isStopped = false;
                agent.SetDestination(target.position);
                return NodeState.RUNNING;
            }
            else{
                agent.isStopped = true;
                return NodeState.SUCCESS;
            }
        }
        //Activates hunting mode and gets the position also changes the fullySpotted variable in the FieldOfView script
        else{
            agent.isStopped = true;

            enemyAI.huntingMode = true;
            enemyAI.huntingForPlayerPosition = target.position;
            fov.fullySpotted = false;

            return NodeState.FAILURE;
        }
    }
}
