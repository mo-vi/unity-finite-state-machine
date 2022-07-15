using System.Collections;
using UnityEngine;

public class PlayerStateSpin : PlayerState
{
    public override IEnumerator EnterState(Player player)
    {
        player.SetMaterialColor(new Color(0.10f, 0.10f, 0.10f));
        
        player.managerUI.UpdateStateString("Spin");

        yield break;
    }

    public override void OnCollisionEnter(Player player)
    {
        player.TransitionToState(player.StateIdle);
    }

    public override void Update(Player player)
    {
        var amountToRotate = 800.0f * Time.deltaTime;
        
        player.transform.Rotate(Vector3.up, amountToRotate);
    }
}
