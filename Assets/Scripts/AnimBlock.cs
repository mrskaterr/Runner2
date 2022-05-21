using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBlock : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      animator.transform.parent.GetComponent<Player>().isPlayingAnimation=true;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      animator.transform.parent.GetComponent<Player>().isPlayingAnimation=false;
    }

}
