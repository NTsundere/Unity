using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdRestart : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Bird");
    }
}
