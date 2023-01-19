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
        SoundEffectManager.Instance.Play("タイトル");
        SceneManager.sceneLoaded += SceneLoaded;

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

#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ++nextSceneIndex;

            Debug.Log(nextSceneIndex % sceneCount);
            SceneChanger.Instance.ChangeScene(nextSceneIndex % sceneCount);
        }
#endif

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            //タイトル - メニュー
            case 0:
                
                break;

            //インゲーム
            case 1:
                
                break;
        }
    }

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        SoundEffectManager.Instance.StopAudio();

        //0 = タイトルシーン
        if(nextScene.buildIndex == 0)
        {
            ParticleController.Instance.PlayEffect();
            SoundEffectManager.Instance.Play("タイトル");
        }
        //1 = ゲームシーン
        else if(nextScene.buildIndex == 1)
        {
            ParticleController.Instance.StopEffect();
            SoundEffectManager.Instance.Play("ゲームBGM");
        }
    }

    private void CallQuitSequence()
    {
        ApplicationExiter.Instance.QuitApplication();
    }
}
