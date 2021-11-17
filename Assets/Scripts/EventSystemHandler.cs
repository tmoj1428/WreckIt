using UnityEngine;
using UnityEngine.Events;

public class EventSystemHandler : MonoBehaviour
{
    public UnityEvent onBoxWreck;
    public UnityEvent onUpdateScore;

    void Awake()
    {
        onBoxWreck = new UnityEvent();
        onUpdateScore = new UnityEvent();
    }
}
