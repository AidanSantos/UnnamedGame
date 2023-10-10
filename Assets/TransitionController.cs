using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public Material transitionMaterial;
    public float transitionSpeed = 0.5f;

    private Material quadMaterial;

    void Start()
    {
        // Attempt to find the quad material
        Renderer quadRenderer = GetComponentInChildren<Renderer>();

        if (quadRenderer != null)
        {
            quadMaterial = quadRenderer.material;
        }
        else
        {
            Debug.LogError("Quad material not found. Make sure the quad has a Renderer component.");
            return;
        }

        // Start the transition
        StartCoroutine(TransitionEffect());
    }

    IEnumerator TransitionEffect()
    {
        float progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime * transitionSpeed;
            transitionMaterial.SetFloat("_Radius", progress);
            yield return null;
        }

        // Load your next scene here

        // Reverse the transition
        while (progress > 0f)
        {
            progress -= Time.deltaTime * transitionSpeed;
            transitionMaterial.SetFloat("_Radius", progress);
            yield return null;
        }

        // Reset the material
        transitionMaterial.SetFloat("_Radius", 0f);
    }
}
