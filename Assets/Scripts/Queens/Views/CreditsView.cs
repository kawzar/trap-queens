using DG.Tweening;
using UnityEngine;

public class CreditsView : MonoBehaviour
{

    [SerializeField] private float endPosition;
    [SerializeField] private float time;
    
    void Start()
    {
        transform.DOMoveY(endPosition, time).SetEase(Ease.Linear);
    }
}
