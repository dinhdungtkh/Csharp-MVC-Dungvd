using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private bool isFiring;

    public void StartFiring()
    {
        isFiring = true;
        Invoke("FireWithDelay", 0.25f);
    }

    public void StopFiring() => isFiring = false;

    private void FireWithDelay()
    {
        if (isFiring && !audioSource.isPlaying)
        {
            Debug.Log("Firing");
            audioSource.Play();
        }
    }

    private void Update()
    {
        // Không cần kiểm tra trong Update nữa vì chúng ta đã sử dụng Invoke
    }
}
