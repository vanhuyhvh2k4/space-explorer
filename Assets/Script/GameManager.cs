using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float wordSpeed;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }
}