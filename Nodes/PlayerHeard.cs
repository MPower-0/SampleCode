using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeard : Node
{
    private float radius;
    private Transform playerTransform;
    private int amount;
    private EnemyAI enemyAI;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;

    public PlayerHeard(float radius, Transform playerTransform, int amount, EnemyAI enemyAI, UnityEngine.AI.NavMeshAgent agent, Animator anim){
        this.radius = radius;
        this.playerTransform = playerTransform;
        this.amount = amount;
        this.enemyAI = enemyAI;
        this.agent = agent;
        this.anim = anim;
    }

    //Calls to the generate waypoints script with the given values
    public override NodeState Evaluate(){
        GenerateWaypoints generateWaypoints = new GenerateWaypoints();
        enemyAI.playerHeardWaypoints = generateWaypoints.GenerateNewWaypointsCircle(radius, playerTransform, amount, agent);
        anim.SetBool("IsSearching", false);
        return NodeState.SUCCESS;
    }
}
