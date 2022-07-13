using UnityEngine;

public class Player : MonoBehaviour
{
    public int CurrentAmmo { get { return currentAmmo; }}
    int currentAmmo = 0;

    public int MaxAmmo { get { return maxAmmo; }}
    readonly int maxAmmo = 20;

    public float JumpForce { get { return jumpForce; }}
    readonly float jumpForce = 350.0f;

    [Header("Mesh renderer to recolor:"), SerializeField] private Renderer meshRenderer;

    public Animator Animator { get; private set; }
    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public PlayerState CurrentState { get; private set; }
    
    public readonly PlayerStateDuck StateDuck = new PlayerStateDuck();
    public readonly PlayerStateIdle StateIdle = new PlayerStateIdle();
    public readonly PlayerStateJump StateJump = new PlayerStateJump();
    public readonly PlayerStateReload StateReload = new PlayerStateReload();
    public readonly PlayerStateSpin StateSpin = new PlayerStateSpin();

    public ManagerUI managerUI;

    void Awake()
    {
        Animator = GetComponent<Animator>();
        Renderer = meshRenderer;
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        /* Default state of the player */    
        TransitionToState(StateIdle);
    }

    void Update()
    {        
        CurrentState.Update(this);
    }

    void OnCollisionEnter(Collision other)
    {
        /* TODO: Layer conditions may be desirable */
        CurrentState.OnCollisionEnter(this);
    }

    public void TransitionToState(PlayerState state)
    {
        CurrentState = state;
        StartCoroutine(CurrentState.EnterState(this));
    }

    public void SetMaterialColor(Color newColor)
    {
        Renderer.material.color = newColor;
    }

    public void SetMaxAmmo()
    {
        currentAmmo = maxAmmo;
        managerUI.UpdateAmmoString($"Ammo: {currentAmmo}/{maxAmmo}");
    }

    public void EmptyAmmo()
    {
        if (currentAmmo == 0) return;

        currentAmmo = 0;
        managerUI.UpdateAmmoString($"Ammo: {currentAmmo}/{maxAmmo}");
    }
}
