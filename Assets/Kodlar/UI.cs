using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject duraklatM,
                      duraklatB,
                      yükseklikTx,
                      yükseklikSTx,
                      yakıtBittiM;

    public AudioSource aus, ads;
    public AudioClip[] audioClips;

    private void Start()
    {
        duraklatM.SetActive(false);
        yakıtBittiM.SetActive(false);
        duraklatB.SetActive(true);
        yükseklikSTx.SetActive(false);
        yükseklikTx.SetActive(false);
    }
    public void Duraklat()
    {
        Time.timeScale = 0;
        duraklatM.SetActive(true);
        duraklatB.SetActive(false);
        aus.Pause();
    }
    public void DevamEt()
    {
        Time.timeScale = 1;
        duraklatM.SetActive(false);
        duraklatB.SetActive(true);
        aus.Play();
    }

    public void AtölyeYeGit()
    {
        SceneManager.LoadScene(2);
    }

    public void AnaMenüyeGit()
    {
        SceneManager.LoadScene(0);
    }

    public void TekrarBaşla()
    {
        SceneManager.LoadScene(1);
    }

    public void YakıtBitti()
    {
        yakıtBittiM.SetActive(true);
        duraklatB.SetActive(false);
    }
}
