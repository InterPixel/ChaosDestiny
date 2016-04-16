using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

    public Slider loadingBar;
    private AsyncOperation async;
    private float downValue;
    private float topValue;
    private GameObject wait;
    public int level;

    void Start(){
    	DontDestroyOnLoad(GameObject.Find("LoaderCanvas"));
    	downValue = Random.Range(0.1f, 0.5f);
    	topValue = Random.Range(0.6f, 0.9f);
    	wait = GameObject.Find("Wait");
    	StartCoroutine(LoadLevelWithBar(level));
    }

    void Update(){
    	if(loadingBar.value == 1){
    		Destroy(gameObject);
    	}
    }


    IEnumerator LoadLevelWithBar (int level){
    	//'yield return null' wait until the next frame then continue where it left off
        async = SceneManager.LoadSceneAsync(level);
        while (!async.isDone)
        {
            loadingBar.value = (async.progress / 2f);
            yield return null;
        }

        wait.GetComponent<Text>().text = "Generating map";

       while(loadingBar.value < topValue){
       		loadingBar.value = loadingBar.value + 0.01f;
       		yield return null;
       }

       wait.GetComponent<Text>().text = "Preparing environment";

       while(loadingBar.value > downValue){
       	loadingBar.value = loadingBar.value - 0.001f;
 		yield return null;
       }

       wait.GetComponent<Text>().text = "Analyzing AI";

       while(loadingBar.value != 1){
       	loadingBar.value = loadingBar.value + 0.005f;
       	yield return null;
       }

       wait.GetComponent<Text>().text = "Done";

    }

}