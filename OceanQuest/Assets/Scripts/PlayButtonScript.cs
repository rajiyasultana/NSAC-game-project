using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    
    public void palyGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
