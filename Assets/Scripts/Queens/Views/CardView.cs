using System;
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
   [SerializeField] private CanvasGroup overlayTextCanvasGroup;
   [SerializeField] private TextMeshProUGUI dialogText;
   [SerializeField] private float spawnAnimationEndValue = 255f;
   [SerializeField] private float spawnAnimationDuration = 1.25f;
   [SerializeField] private float swipeThreshold = 50f;
   [SerializeField] private float swipeVelocity = 15f;

   private Vector3 _initialScale;

   private CardViewModel _viewModel;

   private CardFlowEvent _swipeLeft;
   private CardFlowEvent _swipeRight;
   private bool _isDragging;

   private void OnEnable()
   {
      transform.DOMoveY(spawnAnimationEndValue, spawnAnimationDuration);
      InputManager.Instance.OnStartTouch += OnStartedTouch;
      InputManager.Instance.OnEndTouch += OnReleasedFinger;
   }

   private void OnStartedTouch(Vector2 position, float time)
   {
      _isDragging = true;
   }

   private void OnReleasedFinger(Vector2 position, float time)
   {
      _isDragging = false;
      HideOverlayText();

      if (transform.localPosition.x >= swipeThreshold)
      {
         OnSwipeRight();
      }
      else if (transform.localPosition.x <= -swipeThreshold)
      {
         OnSwipeLeft();
      }
      else
      {
         transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
      }
   }

   private void Update()
   {
      if (_isDragging)
      {
         var fingerPosition = InputManager.Instance.GetPrimaryPosition();
         transform.localPosition = new Vector3(fingerPosition.x * swipeVelocity, transform.localPosition.y, transform.localPosition.z);
      }
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
      _swipeRight.Raise();
      UnsuscribeEvents();
      Destroy(gameObject);
   }

   private void OnSwipeLeft()
   {
      _swipeLeft.Raise();
      UnsuscribeEvents();
      Destroy(gameObject);
   }

   private void UnsuscribeEvents()
   {
      InputManager.Instance.OnStartTouch -= OnStartedTouch;
      InputManager.Instance.OnEndTouch -= OnReleasedFinger;   }

   private void OnPeekRight()
   {
      overlayText.SetText(_viewModel.Yes_answer);
      ShowOverlayText();
   }

   private void OnPeekLeft()
   {
      overlayText.SetText(_viewModel.No_answer);
      ShowOverlayText();
   }

   private void ShowOverlayText()
   {
      overlayTextCanvasGroup.alpha = 1;
   }

   private void HideOverlayText()
   {
      overlayText.alpha = 0;
   }
}
