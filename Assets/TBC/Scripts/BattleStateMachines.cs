using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleStateMachines : MonoBehaviour
{
   public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION,

    }
    public PerformAction battleStates;

    public List<TurnHandler> PerformList = new List<TurnHandler>();

    public List<GameObject> HerosInFight = new List<GameObject>();
    public List<GameObject> EnemiesInFight = new List<GameObject>();

    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemiesInFight.AddRange (GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInFight.AddRange(GameObject.FindGameObjectsWithTag("Hero"));

    }

    // Update is called once per frame
    void Update()
    {
        
        switch (battleStates)
        { 
            case PerformAction.WAIT:
                if(PerformList.Count > 0)
                {
                    battleStates = PerformAction.TAKEACTION;
                }
                break;

            case PerformAction.TAKEACTION:
                GameObject performer = GameObject.Find (PerformList[0].Attacker);
                if (PerformList[0].Type == "Enemy")
                {
                   EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
                   ESM.targetHero = PerformList [0].AttackersTarget;
                   ESM.currentState = EnemyStateMachine.TurnState.ACTION;
                }
                if (PerformList[0].Type == "Hero")
                {
                    
                }

                break;

            case PerformAction.PERFORMACTION:

            break;
        }
        
    }
    public void CollectActions(TurnHandler input)
    {
        PerformList.Add(input);
    }

    
}
