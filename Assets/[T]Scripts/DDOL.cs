using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        this.GetComponentInChildren<KeepInventory>().inventory.Load();
        SceneManager.LoadScene(1);
    }
}
