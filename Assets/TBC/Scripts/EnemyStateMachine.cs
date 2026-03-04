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
}
