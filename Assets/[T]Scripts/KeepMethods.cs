using UnityEngine;

public class KeepMethods : MonoBehaviour
{
    public MethodsObject inventory;

    private void OnApplicationQuit()
    {
        inventory.Save();
    }
}
