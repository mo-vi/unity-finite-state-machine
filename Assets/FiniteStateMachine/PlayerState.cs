using System.Collections;

public abstract class PlayerState
{
    /* Existing functions have a context parameter but will not necessarily be mandatory in new ones */
    /* To provide the possibility to perform time-based actions, such as reloading a weapon and then replenish ammo, EnterState() is a coroutine */
    public abstract IEnumerator EnterState(Player player);

    public abstract void OnCollisionEnter(Player player);

    public abstract void Update(Player player);
}
