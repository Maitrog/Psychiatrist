using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadManager : MonoBehaviour
{ 
    void Start()
    {
        this.GetComponentInChildren<KeepInventory>().inventory.Load();
        this.GetComponentInChildren<KeepDrugs>().inventory.Load();
        this.GetComponentInChildren<KeepMethods>().inventory.Load();
        SceneManager.LoadScene(1);
    }
}
