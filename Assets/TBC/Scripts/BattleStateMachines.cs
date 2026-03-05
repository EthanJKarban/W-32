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

            break;

            case PerformAction.TAKEACTION:

            break;

            case PerformAction.PERFORMACTION:

            break;
        }
        
    }
    
}
