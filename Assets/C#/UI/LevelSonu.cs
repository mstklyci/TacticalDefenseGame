using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSonu : MonoBehaviour
{
    public static bool kazanma;
    public GameObject Kazanma;
    public GameObject Kaybetme;
    public Text KazanilanPara;

    private bool durumGuncellendi = false;

    private void Update()
    {     
        if (kazanma && !durumGuncellendi)
        {
            Durum(true);
            ParaArtir();
            durumGuncellendi = true;
        }
        else if (!kazanma && !durumGuncellendi)
        {
            Durum(false);
            K_ParaArtir();
            durumGuncellendi = true;
        }
    }

    private void Durum(bool kazandi)
    {
        Kazanma.SetActive(kazandi);
        Kaybetme.SetActive(!kazandi);
    }

    private void ParaArtir()
    {
        int paraBonusu = ButtonManager.level * 10;
        KazanilanPara.text = paraBonusu.ToString();
        ParaSistemi.Para += paraBonusu;
        PlayerPrefs.SetInt("ParaSave", ParaSistemi.Para);
    }
    private void K_ParaArtir()
    {
        int paraBonusu = ButtonManager.level * 2;
        KazanilanPara.text = paraBonusu.ToString();
        ParaSistemi.Para += paraBonusu;
        PlayerPrefs.SetInt("ParaSave", ParaSistemi.Para);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
