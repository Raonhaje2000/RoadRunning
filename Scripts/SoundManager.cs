using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 사운드 볼륨은 최소 0, 최대 1
    public float sfxVolum = 1.0f;  // 일반 효과음 볼륨
    public float bgmVolum = 1.0f;  // 배경음 볼륨

    public bool isSfxMute = false; // 음소거 상태인지 체크

    AudioSource bgmSource;

    public AudioClip mainBgm;      // 메인 배경음악

    // 발걸음 효과음
    //public AudioClip stepA;
    //public AudioClip stepB;
    //public AudioClip stepC;

    public AudioClip collision;    // 충돌 효과음

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;

        // 배경음 및 효과음 로드
        LoadAudioClip();
    }

    private void Start()
    {
        // 변수 초기화
        sfxVolum = 0.3f;
        bgmVolum = 1.0f;

        isSfxMute = false;
    }

    // 배경음 및 효과음 로드
    void LoadAudioClip()
    {
        mainBgm = Resources.Load<AudioClip>("Sound/Sunny Travel - Nico Staf");
        collision = Resources.Load<AudioClip>("Sound/Hit with Club");
    }

    // 효과음 재생(동적 생성)
    public void PlaySfx(Vector3 position, AudioClip sfx, float delay, float volum)
    {
        // 음소거 상태가 아닌 경우
        if (!isSfxMute)
        {
            // 효과음 재생
            StartCoroutine(PlaySfxDelay(position, sfx, delay, volum));
        }
    }

    // 효과음 재생
    IEnumerator PlaySfxDelay(Vector3 position, AudioClip sfx, float delay, float volum)
    {
        yield return new WaitForSeconds(delay);

        // 효과음 Object 생성
        GameObject sfxObject = new GameObject("sfx");

        AudioSource audio = sfxObject.AddComponent<AudioSource>();

        // 효과음이 재생될 위치, 재생될 효과음, 효과음의 볼륨 조절 설정
        sfxObject.transform.position = position;
        audio.clip = sfx;
        audio.volume = volum;

        // 거리에 따른 소리 조절
        audio.minDistance = 5.0f;
        audio.maxDistance = 10.0f;

        // 효과음 재생
        audio.Play();

        // 효과음이 끝나면 제거
        Destroy(sfxObject, sfx.length);
    }

    // 배경음악 재생
    public void PlayBGM(AudioClip bgm, float delay, bool loop)
    {
        // 배경음악 재생
        StartCoroutine(PlayBgmDelay(bgm, delay, loop));
    }

    // 배경음악 재생
    IEnumerator PlayBgmDelay(AudioClip bgm, float delay, bool loop)
    {
        yield return new WaitForSeconds(delay);

        // 배경음악 Object 생성
        GameObject bgmObject = new GameObject("BGM");

        if (!bgmSource)
        {
            bgmSource = bgmObject.AddComponent<AudioSource>();
        }

        // 재생될 배경음악, 배경음악의 볼륨 조절, 반복 설정
        bgmSource.clip = bgm;
        bgmSource.volume = bgmVolum;
        bgmSource.loop = loop;

        // 배경음악 재생
        bgmSource.Play();
    }
}