using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public AudioClip[] grassFootsteps;
    public AudioClip[] concreteFootsteps;
    public AudioClip[] dirtFootsteps;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Raycast downward to detect the surface
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.1f))
        {
            string surfaceType = hit.collider.gameObject.tag; // Assuming you've tagged your surfaces

            // Play the appropriate footstep sound based on the surface
            PlayFootstepSound(surfaceType);
        }
    }

    private void PlayFootstepSound(string surfaceType)
    {
        AudioClip[] footstepSounds = GetFootstepSounds(surfaceType);

        if (footstepSounds.Length > 0)
        {
            // Randomly choose a footstep sound from the array
            AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];

            // Play the footstep sound
            audioSource.clip = footstepSound;
            audioSource.Play();
        }
    }

    private AudioClip[] GetFootstepSounds(string surfaceType)
    {
        switch (surfaceType)
        {
            case "Grass":
                return grassFootsteps;
            case "Concrete":
                return concreteFootsteps;
            case "Dirt":
                return dirtFootsteps;
            // Add more cases for other surface types as needed
            default:
                return new AudioClip[0]; // Return an empty array if no matching surface type
        }
    }
}
