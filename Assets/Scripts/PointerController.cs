using UnityEngine;
using UnityEngine.SceneManagement;

public class PointerController : MonoBehaviour
{
    public GameObject playText;
    public GameObject quitText;

    private bool onPlayButton;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-8, 0.5f, 0);
        onPlayButton = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (onPlayButton)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                onPlayButton = false;
                transform.position = new Vector3(-8, -1.5f, 0);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Debug.Log("Play pressed");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                onPlayButton = true;
                transform.position = new Vector3(-8, 0.5f, 0);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Application.Quit();
            }
        }
    }
}
