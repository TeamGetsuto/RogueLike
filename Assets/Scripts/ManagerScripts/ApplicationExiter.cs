using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationExiter : MonoSingleton<ApplicationExiter>
{
    private bool isEscKeyDown = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isEscKeyDown = true;

            if (isEscKeyDown) { return; }
            
            Debug.Log("Quit this game in 1 second. See you later.");
            Invoke("QuitApplication", 1.0f);
        }
    }

    private void QuitApplication()
    {
        Application.Quit();
    }
}
