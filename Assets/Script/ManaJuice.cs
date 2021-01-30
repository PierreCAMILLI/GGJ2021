using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaJuice : MonoBehaviour
{
    public Slider _ManaJuice;
    public Slider _ManaBar;
    private float CurrentValue;
    private float TargetValue;
    public float Delay = 0.5f;
    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        _ManaJuice.value = _ManaJuice.value - 10f;
    }

    public void StartJuice()
    {
        TargetValue = _ManaJuice.value;
        CurrentValue = _ManaBar.value;

        StopAllCoroutines();

        StartCoroutine(Juice(CurrentValue, TargetValue, Speed));
        Debug.Log("startjuice");
    }

    IEnumerator Juice(float CurVal, float TargVal, float Duration)
    {
        float elapsed = 0f;

        yield return new WaitForSeconds(Delay);

        while (elapsed < Speed)
        {
            elapsed += Time.deltaTime;
            _ManaBar.value = Mathf.Lerp(CurVal, TargVal, elapsed / Duration);

            yield return null;

        }

        _ManaBar.value = TargetValue;
    }

}
