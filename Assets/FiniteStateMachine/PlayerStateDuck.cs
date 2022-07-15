using System.Collections;
using UnityEngine;

public class PlayerStateDuck : PlayerState
{
    public override IEnumerator EnterState(Player player)
    {
        player.SetMaterialColor(new Color(0.93f, 0.86f, 0.34f));
        
        player.managerUI.UpdateStateString("Duck");

        player.Animator.SetTrigger("T_Duck");

        yield break;
    }

    public override void OnCollisionEnter(Player player)
    {
        /* Not in use */
    }

    public override void Update(Player player)
    {
        if (Input.GetButtonUp("Duck"))
        {
            player.TransitionToState(player.StateIdle);
        }   
    }
}
