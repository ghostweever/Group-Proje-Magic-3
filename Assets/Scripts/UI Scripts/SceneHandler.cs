using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private int whatSceneAmI;
    public string sceneName = null;
    

    private void Awake()
    {
        
    }

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
            sceneName = "Forest Level";
        }
        else if (whatSceneAmI == 2)
        {
            sceneName = "Water Level";
        }
        else if (whatSceneAmI == 3)
        {
            sceneName = "Lava Level";
        }
        else if (whatSceneAmI == 4)
        {
            sceneName = "Tutorial";
        }
    }
}
