using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerFullySpotted : Node
{
    private FieldOfView fov;
    private Animator anim;

    public IsPlayerFullySpotted(FieldOfView fov, Animator anim){
        this.fov = fov;
        this.anim = anim;
    }

    //Returns success if fullySpotted is true otherwise returns failure. No running state.
    public override NodeState Evaluate(){

        if (fov.fullySpotted == true){
            anim.SetBool("IsSearching", false);
            return NodeState.SUCCESS;
        }
        else{
            return NodeState.FAILURE;
        }
    }
}
