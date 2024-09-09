using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : Node
{
    private float attackRange;
    private Transform target;
    private Transform origin;

    public KillPlayer(float attackRange, Transform target, Transform origin){
        this.attackRange = attackRange;
        this.target = target;
        this.origin = origin;
    }

    //Calculates the distance to the player
    //If the player is within attack range they are killed otherwise the NodeState fails
    public override NodeState Evaluate(){
        float distance = Vector3.Distance(target.position, origin.position);

        if(distance <= attackRange){
            UnityEngine.Object.Destroy(target.gameObject);
            return NodeState.SUCCESS;
        }
        else{
            return NodeState.FAILURE;
        }
    }
}
