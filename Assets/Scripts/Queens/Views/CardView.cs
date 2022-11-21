using DG.Tweening;
using Queens.Managers;
using Queens.Systems.CardFlow;
using Queens.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
   [SerializeField] private Image image;
   [SerializeField] private TextMeshProUGUI overlayText;
   [SerializeField] private TextMeshProUGUI dialogText;
   [SerializeField] private float animationRotationModule = 3.75f;
   [SerializeField] private float animationScale = 1.5f;
   [SerializeField] private float spawnAnimationEndValue = 255f;
   [SerializeField] private float spawnAnimationDuration = 1.25f;

   private Vector3 _initialScale;

   private CardViewModel _viewModel;

   private CardFlowEvent _swipeLeft;
   private CardFlowEvent _swipeRight;

   private void OnEnable()
   {
      transform.DOMoveY(spawnAnimationEndValue, spawnAnimationDuration)
         .SetEase(Ease.InBounce);
      SwipeDetectionManager.Instance.SwipeLeft += OnSwipeLeft;
      SwipeDetectionManager.Instance.SwipeRight += OnSwipeRight;
   }

   public void Bind(CardViewModel viewModel)
   {
      _viewModel = viewModel;
     RebindValues();
   }

   private void RebindValues()
   {
      dialogText.SetText(_viewModel.Dialog);
      _swipeLeft = new CardFlowEvent(_viewModel.NoAnswerArgs);
      _swipeRight = new CardFlowEvent(_viewModel.YesAnswerArgs);
   }

 private void OnSwipeRight()
   {
      transform.DOMoveX(Screen.safeArea.xMax, 0.25f)
         .OnComplete(() =>
         {
            _swipeRight.Raise();
            SwipeDetectionManager.Instance.SwipeLeft -= OnSwipeLeft;
            SwipeDetectionManager.Instance.SwipeRight -= OnSwipeRight;
            Destroy(gameObject);
         });
   }

   private void OnSwipeLeft()
   {
      transform.DOMoveX(Screen.safeArea.xMin, 0.25f)
         .OnComplete(() =>
         {
            _swipeLeft.Raise();
            SwipeDetectionManager.Instance.SwipeLeft -= OnSwipeLeft;
            SwipeDetectionManager.Instance.SwipeRight -= OnSwipeRight;
            Destroy(gameObject);
         });
   }
}
