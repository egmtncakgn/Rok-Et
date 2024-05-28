using UnityEngine;
using UnityEngine.SceneManagement;
public class AnaMenü : MonoBehaviour
{
    public void Oyna()
    {
        SceneManager.LoadScene(1);
    }

    public void YüksekPuanlar()
    {
        SceneManager.LoadScene(2);

    }
    public void Atölye()
    {
        SceneManager.LoadScene(3);
    }
    public void Çık()
    {
        Application.Quit();
    }
}
