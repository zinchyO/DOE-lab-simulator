using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanges : MonoBehaviour
{
    public void LoadCleanRoomScene()
    {
        SceneManager.LoadScene("CleanRoomScene");
    }
}
