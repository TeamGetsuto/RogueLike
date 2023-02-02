using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputKey : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            anim.SetTrigger("Menu");
        }

    }

    public void MoveScene()
    {

        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }
}

