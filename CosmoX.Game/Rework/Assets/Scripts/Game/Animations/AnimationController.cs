using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public GameObject myObject;

    void Start()
    {
        // Ensure 'animator' is assigned in the Unity Editor
        if (animator == null)
        {
            Debug.LogError("Animator component is not assigned.");
            return;
        }

        // Start the animations
        PlayAnimations();
    }

    void PlayAnimations()
    {
        // Play the "Icon" animation
        PlayAnimation("Icon");

        // Play the "Text" animation after the "Icon" animation finishes
        StartCoroutine(WaitAndPlayAnimation("Text", GetAnimationLength("Icon") + 1.0f)); // Adjust the delay as needed
    }

    void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    float GetAnimationLength(string animationName)
    {
        // Get the length of the specified animation
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == animationName)
            {
                return clip.length;
            }
        }

        Debug.LogError("Animation clip not found: " + animationName);
        return 0f;
    }

    IEnumerator WaitAndPlayAnimation(string animationName, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // Play the second animation ("Text")
        PlayAnimation(animationName);

        // Wait for the length of the second animation
        yield return new WaitForSeconds(GetAnimationLength(animationName));

        // Show the GameObject
        if (myObject != null)
        {
            myObject.SetActive(true);
        }
    }
}
