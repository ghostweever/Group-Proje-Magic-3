using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    public int whatSceneAmI;
    public string sceneName = null;

    void Update()
    {
        WhichScene();
    }

    public void WhichScene()
    {
        if (whatSceneAmI == 0)
        {
            sceneName = "Hub";
        }
        else if (whatSceneAmI == 1)
        {
            sceneName = "Forest Level";
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
