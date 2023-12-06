using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public OVROverlay overlay_Background;
    public OVROverlay overlay_LoadingText;
    
    public static SceneLoader instance;

    private void Awake()
    {
        if(instance  != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(ShowOverLayAndLoad(sceneName));
    }

    IEnumerator ShowOverLayAndLoad(string sceneName)
    {
        overlay_Background.gameObject.SetActive(true);
        overlay_LoadingText.gameObject.SetActive(true);
        

        GameObject centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        overlay_LoadingText.gameObject.transform.position = centerEyeAnchor.transform.position + new Vector3(0,0,3f);

        yield return new WaitForSeconds(5f);

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }

        //Disable the overlays
        overlay_Background.gameObject.SetActive(false);
        overlay_LoadingText.gameObject.SetActive(false);


        yield return null;
    }
}
