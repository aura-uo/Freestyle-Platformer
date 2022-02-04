using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public static LosePanel Singleton;
    private static bool Active = false;

    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
        }
    }

    public static void SetActive(bool flag)
    {
        Singleton.gameObject.SetActive(flag);
        Active = flag;
    }

    public static bool getActive()
    {
        return Active;
    }
}
