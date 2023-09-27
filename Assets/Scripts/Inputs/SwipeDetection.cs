using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private bool detectSwipeOnlyAfterRelease = false;
    [SerializeField]
    private float minDistanceForSwipe = 20f;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
                fingerUpPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerUpPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerUpPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    void DetectSwipe()
    {
        if (Vector2.Distance(fingerDownPosition, fingerUpPosition) >= minDistanceForSwipe)
        {
            float deltaX = fingerUpPosition.x - fingerDownPosition.x;
            float deltaY = fingerUpPosition.y - fingerDownPosition.y;

            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY)) // Horizontal swipe
            {
                if (deltaX > 0) // Right swipe
                {
                    TapInput.Instance.MoveLaneRight();
                    Debug.Log("Right Swipe");
                }
                else if (deltaX < 0) // Left swipe
                {
                    TapInput.Instance.MoveLaneLeft();
                    Debug.Log("Left Swipe");
                }
            }
            else // Vertical swipe
            {
                if (deltaY > 0) // Up swipe
                {
                    Debug.Log("Up Swipe");
                }
                else if (deltaY < 0) // Down swipe
                {
                    Debug.Log("Down Swipe");

                }
            }

            fingerDownPosition = fingerUpPosition;
        }
    }
}