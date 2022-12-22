using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// �T�E���h�Ǘ��N���X
/// </summary>
public class SoundEffectManager : MonoSingleton<SoundEffectManager>
{
    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        foreach (var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    /// <summary>
    /// �{�����[��
    /// </summary>
    [System.Serializable]
    public class SoundSettings
    {
        public float defVol;
        public bool mute = false;

        public void Reset()
        {
            defVol = 1.0f;
            mute = false;
        }
    }

    /// <summary>
    /// �����̃f�[�^
    /// </summary>
    #region SoundData
    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip clip;
        public float vol = 1.0f;
        public bool loop = false;
    }
    #endregion

    public SoundSettings settings = new SoundSettings();

    //AudioSource
    const int audioChannel = 10;
    AudioSource[] audioList = new AudioSource[audioChannel];

    //Data
    [SerializeField] SoundData[] soundDatas;
    Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    //�L���[
    Queue<SoundData> soundQueue = new Queue<SoundData>();

    private void Start()
    {
        for (int i = 0; i < audioChannel; ++i)
        {
            audioList[i] = gameObject.AddComponent<AudioSource>();
            audioList[i].volume = settings.defVol;
        }

        SwitchMute();
    }

    private void Update()
    {
        //�L���[�ɉ���������Ƃ��Đ�
        int count = soundQueue.Count;
        if (count != 0)
        {
            SoundData data = soundQueue.Dequeue();
            Play(data.clip, data.vol, data.loop);
        }
    }

    //���g�p�̃\�[�X���擾
    AudioSource GetUnActiveSource()
    {
        for (int i = 0; i < audioList.Length; ++i)
        {
            if (!audioList[i].isPlaying)
            {
                return audioList[i];
            }
        }
        //�Ȃ�
        return null;
    }

    //�Đ�����
    public void Play(AudioClip clip, float vol, bool loop)
    {
        var source = GetUnActiveSource();
        if (source == null) { return; }
        source.clip = clip;
        source.volume = vol;
        source.loop = loop;
        source.Play();
    }

    public void Play(string name)
    {
        //string�����Ƃ�data������
        if (soundDictionary.TryGetValue(name, out var soundData))
        {
            //�L���[�ɒǉ�
            if (!soundQueue.Contains(soundData)) { soundQueue.Enqueue(soundData); }
        }
        else
        {
            Debug.LogWarning($"���������o�^�ł�:{name}");
        }
    }

    //�~���[�g�̐؂�ւ�
    public void SwitchMute()
    {
        foreach (var src in audioList)
        {
            src.mute = settings.mute;
        }

        if (settings.mute)
        {
            Debug.LogWarning("�~���[�gON");
        }
        else
        {
            Debug.LogWarning("�~���[�gOFF");
        }
    }

    //�Đ���~
    public void StopAudio()
    {
        soundQueue.Clear();
        foreach (var src in audioList)
        {
            src.Stop();
            src.clip = null;
        }
    }
}