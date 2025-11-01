using UnityEngine;
using System.Collections;

public class BallShrinker : MonoBehaviour
{
    [Header("Shrinking Settings")]
    [SerializeField] private float shrinkDuration = 0.5f; // Time in seconds to shrink completely
    [SerializeField] private float minScale = 0.0f;      // Minimum scale (1 = normal size)
    [SerializeField] private AnimationCurve shrinkCurve = AnimationCurve.Linear(0, 1, 1, 0.1f);
    
    private Vector3 originalScale;
    private bool isShrinking = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    // Call this method to start shrinking
    public void StartShrinking()
    {
        if (!isShrinking)
        {
            StartCoroutine(ShrinkCoroutine());
        }
    }

    // Call this method to reset the scale
    public void ResetScale()
    {
        StopAllCoroutines();
        transform.localScale = originalScale;
        isShrinking = false;
    }

    IEnumerator ShrinkCoroutine()
    {
        isShrinking = true;
        float elapsedTime = 0f;
        Vector3 startScale = transform.localScale;

        while (elapsedTime < shrinkDuration)
        {
            // Calculate progress (0 to 1)
            float progress = elapsedTime / shrinkDuration;
            
            // Evaluate the curve to get the current scale factor
            float scaleFactor = shrinkCurve.Evaluate(progress);
            
            // Apply the scaling
            transform.localScale = originalScale * Mathf.Max(scaleFactor, minScale);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure we reach exactly the minimum scale
        transform.localScale = originalScale * minScale;
        isShrinking = false;
        Destroy(gameObject);
    }
}