using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int coins_collected = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin()
    {
        coins_collected++;
        if (coins_collected == 5)
        {
            SceneManager.LoadScene(1);
        }
    }
}
