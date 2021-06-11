using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fala : MonoBehaviour
{
   GameObject dia;
   GameObject diaCanvas;
   GameObject sceneController;
   GameObject magD;

    void Start()
    {
       sceneController = GameObject.Find("SceneController");
       magD = sceneController.transform.GetChild(0).gameObject;
       magD.SetActive(true);
       Invoke("pei", 0.1f);
    }

    void pei()
    {
        dia = GameObject.Find("dia");
       diaCanvas = dia.transform.GetChild(0).gameObject;
       diaCanvas.SetActive(true);
    }
}
