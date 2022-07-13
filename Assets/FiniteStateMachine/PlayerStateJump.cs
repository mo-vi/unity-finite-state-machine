using System.Collections;
using UnityEngine;

public class PlayerStateJump : PlayerState
{
    public override IEnumerator EnterState(Player player)
    {
        player.SetMaterialColor(new Color(1.00f, 0.25f, 0.75f));
        player.managerUI.UpdateStateString("Jump");

        player.Animator.SetTrigger("T_Jump");

        player.Rigidbody.AddForce(Vector3.up * player.JumpForce);

        yield break;
    }

    public override void OnCollisionEnter(Player player)
    {
        player.TransitionToState(player.StateIdle);
    }

    public override void Update(Player player)
    {
        if (Input.GetButtonDown("Duck"))
        {
            player.TransitionToState(player.StateSpin);
        }
    }
}
