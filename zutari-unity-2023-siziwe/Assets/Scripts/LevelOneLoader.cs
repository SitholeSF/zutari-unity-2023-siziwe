using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneLoader : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level One"); //Loading level one scene
    }
}