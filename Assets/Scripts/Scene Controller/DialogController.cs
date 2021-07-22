using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI charaName;
    public string charName;
    public string[] sentences;
    int index;
    public float typingSpeed;

    public GameObject DialogBox;
    public GameObject FallTrap;

    void Start()
    {   
        charaName.text = charName;
        StartCoroutine(Type());

    }

    IEnumerator Type(){
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextSentece(){
        if(index < sentences.Length - 1 ){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }else{
            textDisplay.text = "";
            Destroy(FallTrap);
            Destroy(DialogBox);
        }
    }
}
