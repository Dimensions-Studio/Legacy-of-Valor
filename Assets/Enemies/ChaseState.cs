using UnityEngine;

public class ChaseState : State
{
    public ChaseState(GameObject _npc, Animator _anim, Transform _player) : base(_npc, _anim, _player)
    {
        name = STATE.CHASE;
    }

    public override void Enter()
    {
        anim.SetTrigger("isChasing");
        base.Enter();
    }
    public override void Update()
    {
        npc.transform.position = Vector3.MoveTowards(npc.transform.position, player.transform.position,  Time.deltaTime);
        if (CanAttackPLayer())
        {
            nextState = new AttackState(npc, anim, player);
            stage = EVENT.EXIT;
        }
        else if (!CanChasePLayer())
        {
            nextState = new IdleState(npc, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isChasing");
        base.Exit();
    }
}
