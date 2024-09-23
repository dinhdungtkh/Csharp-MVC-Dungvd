using System.Collections;
using UnityEngine;


public enum Soundnames
{
    DAD,
    MOM,
    OHNO,
    OOPS,
    TRYAGAIN,
    GAMEOVER,
    TING,
    ERROR,
    BABY,
    VICTORY
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    private AudioSource mAudioSource;
    [SerializeField]
    private AudioClip[] soundList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(Soundnames m_Soundname, float volume = 1)
    {
        instance.mAudioSource.PlayOneShot(instance.soundList[(int)m_Soundname], volume);
    }
    public static void PlayRandomErrorSound()
    {
        PlaySound(Soundnames.ERROR);

        instance.StartCoroutine(instance.PlayDelayedRandomSound());
    }

    private IEnumerator PlayDelayedRandomSound()
    {
        yield return new WaitForSeconds(0.5f);

        Soundnames[] randomSounds = { Soundnames.OOPS, Soundnames.TRYAGAIN, Soundnames.OHNO };
        int randomIndex = UnityEngine.Random.Range(0, randomSounds.Length);
        PlaySound(randomSounds[randomIndex]);
    }

}
