using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneController : MonoBehaviour
{
    public GameObject restartGameObj;

    // Start is called before the first frame update
    void OnEnable()
    {
        restartGameObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
