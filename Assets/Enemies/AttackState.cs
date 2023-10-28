using UnityEngine;

public class AttackState : State
{
    float rotationSpeed = 2.0f;
    public AttackState(GameObject _npc, Animator _anim, Transform _player) : base(_npc, _anim, _player)
    {
        name = STATE.ATTACK;
    }


    public override void Enter()
    {
        anim.SetTrigger("isAttacking");
        base.Enter();
    }

    public override void Update()
    {
        Vector3 direction = player.position - npc.transform.position;

        float angle = Vector3.Angle(direction, npc.transform.forward);
        direction.y = 0;
        // npc.transform.rotation = Quaternion(npc.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        npc.transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, 0);


        if (!CanAttackPLayer())
        {
            nextState = new IdleState(npc, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isAttacking");
        base.Exit();
    }

}
