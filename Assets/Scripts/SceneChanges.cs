using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanges : MonoBehaviour
{
    public void LoadBadgingScene()
    {
        SceneManager.LoadScene("BadgingScene");
    }
    public void LoadCleanRoomScene()
    {
        SceneManager.LoadScene("CleanRoomScene");
    }
    public void LoadCleaningSolventsScene()
    {
        //SceneManager.LoadScene("CleanRoomScene");
    }
    public void LoadDepositionScene()
    {
        //SceneManager.LoadScene("CleanRoomScene");
    }
    public void LoadPhotolithographyScene()
    {
        //SceneManager.LoadScene("CleanRoomScene");
    }
    public void LoadEtchingScene()
    {
        //SceneManager.LoadScene("CleanRoomScene");
    }
}
