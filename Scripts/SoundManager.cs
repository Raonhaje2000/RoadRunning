using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // ���� ������ �ּ� 0, �ִ� 1
    public float sfxVolum = 1.0f;  // �Ϲ� ȿ���� ����
    public float bgmVolum = 1.0f;  // ����� ����

    public bool isSfxMute = false; // ���Ұ� �������� üũ

    AudioSource bgmSource;

    public AudioClip mainBgm;      // ���� �������

    // �߰��� ȿ����
    //public AudioClip stepA;
    //public AudioClip stepB;
    //public AudioClip stepC;

    public AudioClip collision;    // �浹 ȿ����

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;

        // ����� �� ȿ���� �ε�
        LoadAudioClip();
    }

    private void Start()
    {
        // ���� �ʱ�ȭ
        sfxVolum = 0.3f;
        bgmVolum = 1.0f;

        isSfxMute = false;
    }

    // ����� �� ȿ���� �ε�
    void LoadAudioClip()
    {
        mainBgm = Resources.Load<AudioClip>("Sound/Sunny Travel - Nico Staf");
        collision = Resources.Load<AudioClip>("Sound/Hit with Club");
    }

    // ȿ���� ���(���� ����)
    public void PlaySfx(Vector3 position, AudioClip sfx, float delay, float volum)
    {
        // ���Ұ� ���°� �ƴ� ���
        if (!isSfxMute)
        {
            // ȿ���� ���
            StartCoroutine(PlaySfxDelay(position, sfx, delay, volum));
        }
    }

    // ȿ���� ���
    IEnumerator PlaySfxDelay(Vector3 position, AudioClip sfx, float delay, float volum)
    {
        yield return new WaitForSeconds(delay);

        // ȿ���� Object ����
        GameObject sfxObject = new GameObject("sfx");

        AudioSource audio = sfxObject.AddComponent<AudioSource>();

        // ȿ������ ����� ��ġ, ����� ȿ����, ȿ������ ���� ���� ����
        sfxObject.transform.position = position;
        audio.clip = sfx;
        audio.volume = volum;

        // �Ÿ��� ���� �Ҹ� ����
        audio.minDistance = 5.0f;
        audio.maxDistance = 10.0f;

        // ȿ���� ���
        audio.Play();

        // ȿ������ ������ ����
        Destroy(sfxObject, sfx.length);
    }

    // ������� ���
    public void PlayBGM(AudioClip bgm, float delay, bool loop)
    {
        // ������� ���
        StartCoroutine(PlayBgmDelay(bgm, delay, loop));
    }

    // ������� ���
    IEnumerator PlayBgmDelay(AudioClip bgm, float delay, bool loop)
    {
        yield return new WaitForSeconds(delay);

        // ������� Object ����
        GameObject bgmObject = new GameObject("BGM");

        if (!bgmSource)
        {
            bgmSource = bgmObject.AddComponent<AudioSource>();
        }

        // ����� �������, ��������� ���� ����, �ݺ� ����
        bgmSource.clip = bgm;
        bgmSource.volume = bgmVolum;
        bgmSource.loop = loop;

        // ������� ���
        bgmSource.Play();
    }
}