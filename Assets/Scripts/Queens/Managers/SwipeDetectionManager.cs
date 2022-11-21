using System;
using UnityEngine;

namespace Queens.Managers
{
    public class SwipeDetectionManager : MonoBehaviour
    {
        [SerializeField] private float minimumSwipeLenght = .2f;
        [SerializeField] private float maxSwipeDuration = 1;
        [SerializeField] private float directionThreshold = .9f;

        
        private Vector2 startPosition;
        private float startTime;
        private Vector2 endPosition;
        private float endTime;

        public event Action SwipeLeft;
        public event Action SwipeRight;
        
        public static SwipeDetectionManager Instance { get; private set; }

        public Vector2 SwipeDirectionRaw => endPosition - startPosition;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            InputManager.Instance.OnStartTouch += OnSwipeStart;
            InputManager.Instance.OnEndTouch += OnSwipeEnd;
        }

        private void OnSwipeEnd(Vector2 position, float time)
        {
            endPosition = position;
            endTime = time;
            DetectSwipe();
        }

        private void OnSwipeStart(Vector2 position, float time)
        {
            startPosition = position;
            startTime = time;
        }

        private void OnDestroy()
        {
            InputManager.Instance.OnStartTouch -= OnSwipeStart;
            InputManager.Instance.OnEndTouch -= OnSwipeEnd;
        }

        private void DetectSwipe()
        {
            if (Vector2.Distance(endPosition, startPosition) >= minimumSwipeLenght &&
                endTime - startTime <= maxSwipeDuration)
            {
                Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
                Vector3 direction = endPosition - startPosition;
                Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
                SwipeDirection(direction2D);
            }
        }

        private void SwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
            {
                SwipeRight?.Invoke();
            }
            if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
            {
                SwipeLeft?.Invoke();

            }
        }
    }
}
