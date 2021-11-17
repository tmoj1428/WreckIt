using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Score;
    public EventSystemHandler eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem.onUpdateScore.AddListener(UpdateScoreText);
    }

    // Update is called once per frame
    void UpdateScoreText()
    {
        Score.text = FindObjectOfType<MovePlayer>().playerScore.ToString();
    }
}
