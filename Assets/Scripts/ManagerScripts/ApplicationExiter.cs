using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationExiter : MonoSingleton<ApplicationExiter>
{
    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
    }
    public void QuitApplication()
    {
        Debug.Log("Application will quit in 1 second");
        Application.Quit();
    }
}
