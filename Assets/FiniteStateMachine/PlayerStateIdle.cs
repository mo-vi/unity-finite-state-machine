using System.Collections;
using UnityEngine;

public class PlayerStateIdle : PlayerState
{
    public override IEnumerator EnterState(Player player)
    {
        player.SetMaterialColor(new Color(0.34f, 0.68f, 0.75f));
        
        player.managerUI.UpdateStateString("Idle");

        /* Reset rotation if the player was spinning */
        player.transform.rotation = Quaternion.identity;

        /* Prevent trigger failures when input buttons are smashed */
        player.Animator.ResetTrigger("T_Duck");
        player.Animator.ResetTrigger("T_Jump");
        player.Animator.ResetTrigger("T_Reload");

        player.Animator.SetTrigger("T_Idle");

        yield break;
    }

    public override void OnCollisionEnter(Player player)
    {
        /* Not in use */
    }

    public override void Update(Player player)
    {
        /* Possible outcomes while in default state: */
        if (Input.GetButtonDown("Duck"))
        {
            player.TransitionToState(player.StateDuck);
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.TransitionToState(player.StateJump);
        }

        if (Input.GetButtonDown("Reload"))
        {
            if (player.CurrentAmmo >= 20) return;

            player.TransitionToState(player.StateReload);
        }
    }
}
