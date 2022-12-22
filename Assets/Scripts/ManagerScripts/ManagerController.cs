using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerController : MonoSingleton<ManagerController>
{
    private void Awake()
    {
        if(this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private bool isEscKeyDown;

    int sceneCount;
    int nextSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        isEscKeyDown = false;

        sceneCount = SceneManager.sceneCount + 1;
        nextSceneIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isEscKeyDown) { return; }
            isEscKeyDown = true;

            Invoke("CallQuitSequence", 1.0f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ++nextSceneIndex;

            Debug.Log(nextSceneIndex % sceneCount);
            SceneChanger.Instance.ChangeScene(nextSceneIndex % sceneCount);
        }
    }

    private void CallQuitSequence()
    {
        ApplicationExiter.Instance.QuitApplication();
    }
}
