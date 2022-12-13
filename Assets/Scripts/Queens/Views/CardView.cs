using DG.Tweening;
using Queens.Services;
using Queens.Systems;
using Queens.Systems.CardFlow;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
   [SerializeField] private AppeareanceConfigService _appeareanceConfigService;
   [SerializeField] private Image image;
   [SerializeField] private float spawnAnimationEndValue = 255f;
   [SerializeField] private float spawnAnimationDuration = 1.25f;
   [SerializeField] private float swipeThreshold = 50f;
   [SerializeField] private float swipeVelocity = 15f;

   private Vector3 _initialScale;

   private bool _isDragging;
   private bool _hasSwiped;

  private void Start()
   {
      transform.DOMoveY(spawnAnimationEndValue, spawnAnimationDuration);
      image.sprite = _appeareanceConfigService.GetCharacterSpriteForCurrentCard();
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

      if (_isDragging) return; // so we don't spawn events
      
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


   private void OnSwipeRight()
   {
      if (_hasSwiped) return;
      _hasSwiped = true;
      DeckSystem.Instance.CurrentCardViewModel.Value.CardPlayed(CardFlowEventEnum.YES);
      UnsuscribeEvents();
      Destroy(gameObject);
   }

   private void OnSwipeLeft()
   {
      if (_hasSwiped) return;
      _hasSwiped = true;
      DeckSystem.Instance.CurrentCardViewModel.Value.CardPlayed(CardFlowEventEnum.NO);
      UnsuscribeEvents();
      Destroy(gameObject);
   }
   
   private void UnsuscribeEvents()
   {
      InputManager.Instance.OnStartTouch -= OnStartedTouch;
      InputManager.Instance.OnEndTouch -= OnReleasedFinger;
   }
}
