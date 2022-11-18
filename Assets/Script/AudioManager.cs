using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    static GameObject instGMObj = null;
    private static AudioManager instance = null;
    public static AudioManager Inst
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    instance = new GameObject("AudioManager", typeof(AudioManager)).GetComponent<AudioManager>();
                }
            }
            return instance;
        }
    }
    #endregion

    [Header("UI Sounds")]
    [SerializeField] AudioSource UIAudioSource;
    [SerializeField] AudioSource EnemyAudioSource;
    [SerializeField] AudioSource PlayerAudioSource;

    [SerializeField] AudioClip highlighted;
    [SerializeField] AudioClip pressed;

    [Header("Play Sounds")]
    [SerializeField] AudioClip playerItemGotcha;
    [SerializeField] AudioClip treeFollowing;


    private void Awake()
    {
        if (instGMObj == null)
        {
            instGMObj = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }

        else if (instGMObj != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public void UISound_HighLighted()
    {
        // play hightlighted sound 
        UIAudioSource.clip = highlighted;
        UIAudioSource.Play();
    }


    public void UISound_Pressed()
    {
        // play pressed sound 
        UIAudioSource.clip = pressed;
        UIAudioSource.Play();
    }

    public void PlayerSound_ItemGotcha()
    {
        PlayerAudioSource.Play();
    }

}
