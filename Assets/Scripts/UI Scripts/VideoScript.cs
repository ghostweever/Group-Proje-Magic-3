using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class VideoScript : MonoBehaviour
{

    VideoPlayer video;
    private DataPersistenceManager dataPersistenceManager;
    private void Awake()
    {
        dataPersistenceManager = GetComponent<DataPersistenceManager>();
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().gameCompleted == false)
        {
            StartCoroutine(LoadScene("Hub"));
        } else
        {
            StartCoroutine(LoadScene("Win"));
        }
    }

    private IEnumerator LoadScene(string sceneToLoad)
    {

        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
