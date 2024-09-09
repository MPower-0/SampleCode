using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHuntingModeActivated : Node
{
    private EnemyAI enemyAI;

    public IsHuntingModeActivated(EnemyAI enemyAI){
        this.enemyAI = enemyAI;
    }

    //SUCCESS if huntingMode is true else FAILURE
    public override NodeState Evaluate(){
        if (enemyAI.huntingMode == true){
            return NodeState.SUCCESS;
        }
        else{
            return NodeState.FAILURE;
        }
    }
}
