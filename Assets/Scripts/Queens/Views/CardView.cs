using DG.Tweening;
using Queens.Services;
using Queens.Systems;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
   [SerializeField] private AppeareanceConfigService _appeareanceConfigService;
   [SerializeField] private Image image;
   [SerializeField] private float spawnAnimationEndValue = 255f;
   [SerializeField] private float spawnAnimationDuration = 1.25f;
   [SerializeField] private float viewportHalfThreshold = 0.5f;
   [SerializeField] private float viewportYesThreshold = 0.8f;
   [SerializeField] private float viewportNoThreshold = 0.2f;

   private Vector3 _initialScale;
   private RectTransform _rectTransform;
   private bool _isDragging;
   private bool _hasSwiped;
   private Tween _tween;
   private float _initialPositionX;
   private Canvas _canvas;

  private void Start()
   {
      _tween = transform.DOLocalMoveY(spawnAnimationEndValue, spawnAnimationDuration).OnComplete(() =>
      {
         InputManager.Instance.OnMovedToPosition += OnTouchPerformed;
         InputManager.Instance.OnFingerReleased += OnReleasedFinger;
      });
      
      _initialPositionX = transform.position.x;
      image.sprite = _appeareanceConfigService.GetCharacterSpriteForCurrentCard();
      _canvas = GetComponentInParent<Canvas>();
      _rectTransform = GetComponent<RectTransform>();
   }

   private void OnTouchPerformed(Vector3 position)
   {
      if (!IsOverMe(position)) return;
      
      _isDragging = true;
      _tween.Kill();
      _tween = transform.DOMoveX(position.x, 0.1f);
   }

   private bool IsOverMe(Vector3 position)
   {
      Vector2 localFingerPosition = _rectTransform.InverseTransformPoint(position);
      if (_rectTransform.rect.Contains(localFingerPosition))
      {
         return true;
      }

      return false;
   }

   private void OnReleasedFinger(Vector3 position)
   {
      if (!IsOverMe(position)) return;
      
      _isDragging = false;
      if (_isDragging) return; // so we don't spawn events

      var primaryX = Camera.main.ScreenToViewportPoint(position).x;
      if (primaryX > viewportYesThreshold && primaryX > viewportHalfThreshold)
      {
         OnSwipeRight();
      }
      else if (primaryX < viewportNoThreshold && primaryX < viewportHalfThreshold)
      {
         OnSwipeLeft();
      }
      else
      {
         _tween.Kill();
         _tween = transform.DOMoveX(_initialPositionX, 0.1f);
      }
   }
 
   private void OnSwipeRight()
   {
      if (_hasSwiped) return;
      _hasSwiped = true;
      DeckSystem.Instance.CardPlayed(CardFlowEventEnum.YES);
      UnsuscribeEvents();
      _tween.Kill();
      Destroy(gameObject);
   }

   private void OnSwipeLeft()
   {
      if (_hasSwiped) return;
      _hasSwiped = true;
      DeckSystem.Instance.CardPlayed(CardFlowEventEnum.NO);
      UnsuscribeEvents();
      _tween.Kill();
      Destroy(gameObject);
   }
   
   private void UnsuscribeEvents()
   {
      InputManager.Instance.OnMovedToPosition -= OnTouchPerformed;
      InputManager.Instance.OnFingerReleased -= OnReleasedFinger;
   }
}
