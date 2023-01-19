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
        //effector����particle�֘A�̃R���|�[�l���g���擾
        effectSystem = effector.GetComponent<ParticleSystem>();

        //effector�𖳌���
        effector.SetActive(false);

        //effect���Đ�
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
        //effector��L����
        effector.SetActive(true);

        //�G�t�F�N�g���Đ�
        effectSystem.Play();
    }

    public void StopEffect()
    {
        //�G�t�F�N�g���~
        effectSystem.Stop();

        //effector�𖳌���
        effector.SetActive(false);
    }

}
