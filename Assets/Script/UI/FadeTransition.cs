using UnityEngine;

namespace UI
{
    using System.Collections;
    using UnityEngine.Serialization;

    [RequireComponent(typeof(CanvasGroup))]
    public class FadeTransition : MonoBehaviour
    {
        [SerializeField] private CanvasGroup CanvasGroup;

        [SerializeField] private float Duration = .5f;

        public void FadeIn()
        {
            StartCoroutine(FadeCanvasGroup(CanvasGroup, CanvasGroup.alpha, 1f, Duration));
        }

        public void FadeOut()
        {
            StartCoroutine(FadeCanvasGroup(CanvasGroup, CanvasGroup.alpha, 0f, Duration));
        }

        public IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float duration)
        {
            var startTime = Time.time;
            float completion = 0f;

            do
            {
                completion = (Time.time - startTime) / duration;

                canvasGroup.alpha = Mathf.Lerp(start, end, completion);

                yield return new WaitForEndOfFrame();
            } while (completion < 1);

            canvasGroup.alpha = end;
        }
    }
}
