using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Clicky : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent clickScore;


    public AudioClip clickSound;
    WindowMover windowMover;

    private void Awake()
    {
        windowMover = Object.FindAnyObjectByType<WindowMover>();
    }
  
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        clickScore.Invoke();
        windowMover.clicked();
    }
}
