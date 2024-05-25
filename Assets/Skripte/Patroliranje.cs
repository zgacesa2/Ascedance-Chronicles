using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroliranje : StateMachineBehaviour {

    private GameObject[] tockePatroliranja;
    private int nasumicnaTocka;
    public float brzina;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        tockePatroliranja = GameObject.FindGameObjectsWithTag("TockePatroliranja");
        nasumicnaTocka = Random.Range(0, tockePatroliranja.Length);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, tockePatroliranja[nasumicnaTocka].transform.position, brzina * Time.deltaTime);

        if (Vector2.Distance(animator.transform.position, tockePatroliranja[nasumicnaTocka].transform.position) < 0.1f) {
            nasumicnaTocka = Random.Range(0, tockePatroliranja.Length);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    
    }

}
