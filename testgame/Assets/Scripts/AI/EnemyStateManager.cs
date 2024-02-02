using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{

    //gets the health script on the player
    private Health playerHealthRef;

   
    [Header("Enemy Values")]
    [SerializeField] private GameObject _enemyThisBelongsTo;   //The enemy this script belongs to
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private int _health;
    [SerializeField] private float _speed;

    

    [Header("Target")]
    private GameObject _target;


    [Header("Bools")]
    [SerializeField] private bool _canSeePlayer;

    //delegates
    public delegate void EnemyAIEvents();

    //events
    public static EnemyAIEvents onAttack;
    
    
    public NavMeshAgent Agent { get { return _agent; } }
    public GameObject Target { get { return _target; } }
    public int Health { get { return _health; } }
    public float Speed { get { return _speed; } }
    public bool CanSeePlayer { get { return _canSeePlayer; } }


    



    //current states
    public EnemyBaseState currentState;
    public EnemyInactiveState inactiveState = new EnemyInactiveState();
    public EnemyBaseState chaseState = new EnemyChaseState();
    public EnemyAttackState attackState = new EnemyAttackState();


    private void OnEnable()
    {
        //subscribes to all the events on enable
        EnemyBaseState.onSwitchState += () => currentState?.ExitState(this);
    }

    private void OnDisable()
    {
        //unsubscribes to all the events on disable
        EnemyBaseState.onSwitchState -= () => currentState?.ExitState(this);

    }


    private void Awake()
    {
        //Sets the variable to be equal to the game object that the script is attached to on awake
        _enemyThisBelongsTo = GetComponent<EnemyStateManager>().gameObject;
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player");
        playerHealthRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    private void Start()
    {
        playerHealthRef = FindObjectOfType<Health>();
        _target = GameObject.FindWithTag("Player");
        //sets the current state to be the inactive state on start up
        currentState = inactiveState;

    }

    private void Update()
    {
        //runs the update state used in the current state
        currentState.UpdateState(this);

        //sets the agent's speed equal to the speed variable
        _agent.speed = _speed;

       
    }


    //Function used to switch between the ai states
    public void SwitchState(EnemyBaseState state)
    {
        //sets the current state to equal state
        currentState = state;

        //calls the state's enter state 
        state.EnterState(this);

        //calls the onswitch state event
        EnemyBaseState.onSwitchState?.Invoke();
    }


    


    public void TakeDamage()
    {
        //decreases the health by one
        --_health;

        //play take damage sound
        AudioManager.PlayAudio("Enemy Hit");

        //if the health is less than or equal to 0...
        if(_health <= 0)
        {
            //Call the enemy death function
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        //play the death sound
        AudioManager.PlayAudio("Enemy Death");

        Destroy(gameObject);
    }



}
