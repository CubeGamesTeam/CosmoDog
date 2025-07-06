using UnityEngine;

public class AmbientMusic : MonoBehaviour
{
    public static AmbientMusic instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(gameObject);
    }
}
