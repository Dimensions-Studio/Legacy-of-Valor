using UnityEngine;

public class IdleState : State
{
    public IdleState(GameObject _npc, Animator _anim, Transform _player) : base(_npc, _anim, _player)
    {
        name = STATE.IDLE;
    }
    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        base.Enter();
    }
    public override void Update()
    {
        if (CanChasePLayer())
        {
            nextState = new ChaseState(npc, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }


}