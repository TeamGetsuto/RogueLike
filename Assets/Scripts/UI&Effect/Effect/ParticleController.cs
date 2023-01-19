using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoSingleton<ParticleController>
{
    [SerializeField] GameObject effector;
    ParticleSystem effectSystem;

    //Singleton
    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //effectorからparticle関連のコンポーネントを取得
        effectSystem = effector.GetComponent<ParticleSystem>();

        //effectorを無効化
        effector.SetActive(false);

        //effectを再生
        PlayEffect();
    }

    private void Update()
    {
        #region Debug

        if(Input.GetKeyDown(KeyCode.P))
        {
            PlayEffect();
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            StopEffect();
        }

        #endregion
    }

    public void PlayEffect()
    {
        //effectorを有効化
        effector.SetActive(true);

        //エフェクトを再生
        effectSystem.Play();
    }

    public void StopEffect()
    {
        //エフェクトを停止
        effectSystem.Stop();

        //effectorを無効化
        effector.SetActive(false);
    }

}
