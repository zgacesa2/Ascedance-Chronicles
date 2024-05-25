using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hvatanje : StateMachineBehaviour {
    
    private GameObject igrac;
    public float brzina;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        igrac = GameObject.FindGameObjectWithTag("Igrac");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (igrac != null) {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, igrac.transform.position, brzina * Time.deltaTime);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    }
}
