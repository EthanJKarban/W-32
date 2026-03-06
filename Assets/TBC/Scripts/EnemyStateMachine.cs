using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStateMachine : MonoBehaviour
{
    private BattleStateMachines BSM;
    public BaseEnemy enemy;
    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        DEAD
    }

    public TurnState currentState;
    //For progress bar
    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;

    private Vector3 startPosition;

    private bool actionActive = false;
    public GameObject targetHero;
    private float animSpeed = 5f;

    void Start()
    {
        currentState = TurnState.PROCESSING;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachines>();
            startPosition = transform.position;
    }

    void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case (TurnState.PROCESSING):

                UpgradeProgressBar();

                break;

            case (TurnState.CHOOSEACTION):

                ChooseAction();
                currentState = TurnState.WAITING;
                break;

            case (TurnState.WAITING):


                break;

            case (TurnState.ACTION):

                StartCoroutine(TimeForAction());
                break;

            case (TurnState.DEAD):


                break;
        }
    }
    void UpgradeProgressBar()
    {
        cur_cooldown = cur_cooldown + Time.deltaTime;
        
        if (cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.CHOOSEACTION;
        }
    }

   void ChooseAction()
    {
        TurnHandler myAttack = new TurnHandler();
        myAttack.Attacker = enemy.name;
        myAttack.Type = "Enemy";
        myAttack.AttackerObject = this.gameObject;
        myAttack.AttackersTarget = BSM.HerosInFight[Random.Range(0, BSM.HerosInFight.Count)];
        BSM.CollectActions(myAttack);
    }

    private IEnumerator TimeForAction()
    {
        if(actionActive)
        {
            yield break;
        }
        
        actionActive = true;

        //animate the enemy near the hero to hit
        Vector3 HeroPosition = new Vector3(targetHero.transform.position.x - 1.5f, targetHero.transform.position.y - 1.5f, targetHero.transform.position.z - 1.5f);
        while (MoveTowardsTargetEnemy(HeroPosition))
        {
            yield return null;
        }
        //wait

        //damage

        //animate back to start

        //remove this performer from the list in BattleStateMachine

        //reset BSM -> Wait

        actionActive = false;
        //reset the enemies state
        cur_cooldown = 0f;
        currentState = TurnState.PROCESSING;
    }

    private bool MoveTowardsTargetEnemy(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }
}
