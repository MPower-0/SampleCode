using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerPartlySpotted : Node
{
    private FieldOfView fov;
    private Animator anim;

    public IsPlayerPartlySpotted(FieldOfView fov, Animator anim){
        this.fov = fov;
        this.anim = anim;
    }

    //Returns success if partlySpotted is true otherwise returns failure
    public override NodeState Evaluate(){
        if (fov.partlySpotted == true){
            anim.SetBool("IsSearching", false);
            return NodeState.SUCCESS;
        }
        else{
            return NodeState.FAILURE;
        }
    }
}
