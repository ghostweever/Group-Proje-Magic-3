using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private int whatSceneAmI;
    public string sceneName = null;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneType();
    }

    void SceneType()
    {
        if (whatSceneAmI == 0)
        {
            sceneName = "Hub";
        }
        else if (whatSceneAmI == 1)
        {
            sceneName = "Level1";
        }
        else if (whatSceneAmI == 2)
        {
            sceneName = "Level2";
        }
        else if (whatSceneAmI == 3)
        {
            sceneName = "Level3";
        }
    }
}
