using UnityEngine;
using UnityEngine.SceneManagement;

public class HKRRSceneManager : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
