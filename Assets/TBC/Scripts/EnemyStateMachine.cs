<<<<<<< HEAD
using System.Collections;
using System.Xml.Serialization;
=======
>>>>>>> parent of e722991 (Idk atm)
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStateMachine : MonoBehaviour
{
    public BaseEnemy enemy;
    public enum TurnState
    {
        PROCESSING,
        ADDTOLIST,
        WAITING,
        SELECTING,
        ACTION,
        DEAD
    }

    public TurnState currentState;
    //For progress bar
    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;
<<<<<<< HEAD

    private Vector3 startPosition;

    private bool actionActive = false;
    public GameObject targetHero;
    private float animSpeed = 5f;

=======
    
>>>>>>> parent of e722991 (Idk atm)
    void Start()
    {
        currentState = TurnState.PROCESSING;
    }

    void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case (TurnState.PROCESSING):

                UpgradeProgressBar();

                break;

            case (TurnState.ADDTOLIST):


                break;

            case (TurnState.WAITING):


                break;

            case (TurnState.SELECTING):


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
            currentState = TurnState.ADDTOLIST;
        }
    }
<<<<<<< HEAD

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
=======
>>>>>>> parent of e722991 (Idk atm)
}
