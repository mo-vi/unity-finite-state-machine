using System.Collections;
using UnityEngine;

public class PlayerStateReload : PlayerState
{
    public override IEnumerator EnterState(Player player)
    {
        player.SetMaterialColor(new Color(1.0f, 1.0f, 1.0f));
        player.managerUI.UpdateStateString("Reload");

        player.Animator.SetTrigger("T_Reload");

        /* Current animation state is Reload. Get its length */
        var reloadTime = player.Animator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(reloadTime);

        player.SetMaxAmmo();

        player.TransitionToState(player.StateIdle);

        yield break;
    }

    public override void OnCollisionEnter(Player player)
    {
        player.TransitionToState(player.StateIdle);
    }

    public override void Update(Player player)
    {
        /* Not in use */ 
    }
}
