using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    Animator anim;
    public Transform player;
    State currentState;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        currentState = new IdleState(this.gameObject, anim, player);
    }

    private void Update()
    {
        currentState = currentState.Process();
    }
}
