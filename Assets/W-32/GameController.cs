using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int score { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementScore()
    {
        Debug.Log("I'm Pibble");
        score++;
    }
    public void ResetScore()
    {
        Debug.Log("You Lost, you loser!");
        score = 0;
    }
}
