using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void NextScene(int _nextScene)
    {
        SceneManager.LoadScene(_nextScene);
    }
}
