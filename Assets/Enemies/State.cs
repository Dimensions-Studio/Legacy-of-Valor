using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    public enum STATE
    {
        IDLE,CHASE,ATTACK,DEATH
    }

    public enum EVENT
    {
        ENTER,UPDATE,EXIT
    }

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;


    float chaseDist = 10.0f;
    float attackDist = 7.0f;


    public State(GameObject _npc,Animator _anim,Transform _player)
    {
        npc = _npc;
        player = _player;
        anim = _anim;
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.ENTER; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }



    public State Process()
    {
        if(stage == EVENT.ENTER)Enter();
        if(stage == EVENT.UPDATE)Update();
        if(stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }


    public bool CanChasePLayer()
    {
        Vector3 direction = player.position - npc.transform.position;
        if (direction.magnitude < chaseDist)
        {
            return true;
        }
        return false;
    }
    public bool CanAttackPLayer()
    {
        Vector3 direction = player.position - npc.transform.position;
        if(direction.magnitude < attackDist)
        {
            return true;
        }
        return false;
    }

}
