using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMahine : MonoBehaviour
{
    public AttackState attackState;

    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }
    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
