using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;

    [SerializeField] private string actionMapName = "Player";

    [SerializeField] private string move = "Move";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string look = "Look";
    [SerializeField] private string sprint = "Sprint";
    [SerializeField] private string primarySpell = "Primary Spell";
    [SerializeField] private string secondarySpell = "Secondary Spell";
    [SerializeField] private string primarySpellSwitch = "Switch Primary";
    [SerializeField] private string secondarySpellSwitch = "Switch Secondary";

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction lookAction;
    private InputAction sprintAction;
    private InputAction primarySpellAction;
    private InputAction secondarySpellAction;
    private InputAction primarySpellSwitchAction;
    private InputAction secondarySpellSwitchAction;

    public Vector2 MoveInput { get; private set; }
    public bool JumpTrigger { get; private set; }
    public Vector2 LookInput { get; private set; }
    public float SprintValue { get; private set; }
    public bool PrimarySpellTrigger { get; private set; }
    public bool SecondarySpellTrigger { get; private set; }
    public bool PrimarySpellSwitchTrigger { get; private set; }
    public bool SecondarySpellSwitchTrigger { get; private set; }


    public static PlayerInputHandler Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    else
        {
            Destroy(gameObject);
        }

        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        jumpAction = playerControls.FindActionMap(actionMapName).FindAction(jump);
        lookAction = playerControls.FindActionMap(actionMapName).FindAction(look);
        sprintAction = playerControls.FindActionMap(actionMapName).FindAction(sprint);
        primarySpellAction = playerControls.FindActionMap(actionMapName).FindAction(primarySpell);
        secondarySpellAction = playerControls.FindActionMap(actionMapName).FindAction(secondarySpell);
        primarySpellSwitchAction = playerControls.FindActionMap(actionMapName).FindAction(primarySpellSwitch);
        secondarySpellSwitchAction = playerControls.FindActionMap(actionMapName).FindAction(secondarySpellSwitch);

        RegisterInputActions();
    }

    void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = context.ReadValue<Vector2>();

        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => LookInput = context.ReadValue<Vector2>();

        sprintAction.performed += context => SprintValue  = context.ReadValue<float>();
        sprintAction.canceled += context => SprintValue = 0f;

        jumpAction.performed += context => JumpTrigger = true;
        jumpAction.canceled += context => JumpTrigger = false;

        primarySpellAction.performed += context => PrimarySpellTrigger = true;
        primarySpellAction.canceled += context => PrimarySpellTrigger = false;

        secondarySpellAction.performed += context => SecondarySpellTrigger = true;
        secondarySpellAction.canceled += context => SecondarySpellTrigger = false;

        primarySpellSwitchAction.performed += context => PrimarySpellSwitchTrigger = true;
        primarySpellSwitchAction.canceled += context => PrimarySpellSwitchTrigger = false;

        secondarySpellSwitchAction.performed += context => SecondarySpellSwitchTrigger = true;
        secondarySpellSwitchAction.canceled += context => SecondarySpellSwitchTrigger = false;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        lookAction.Enable();
        sprintAction.Enable();
        primarySpellAction.Enable();
        secondarySpellAction.Enable();
        primarySpellSwitchAction.Enable();
        secondarySpellSwitchAction.Enable();
    }


    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        lookAction.Disable();
        sprintAction.Disable();
        primarySpellAction.Disable();
        secondarySpellAction.Disable();
        primarySpellSwitchAction.Disable();
        secondarySpellSwitchAction.Disable();
    }
}
