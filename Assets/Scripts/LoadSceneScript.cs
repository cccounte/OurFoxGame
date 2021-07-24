using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;
    public int nextScene;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){ 
        StartCoroutine(LoadLevel(nextScene));
    }

    IEnumerator LoadLevel(int sceneIndex){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
 