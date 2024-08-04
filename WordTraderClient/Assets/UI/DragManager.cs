using UnityEngine;

/// <summary>
/// Manages the dragging of UI elements within a specified bounding box.
/// </summary>
public class DragManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform _defaultLayer = null, _dragLayer = null;

    private Rect _boundingBox;
    private DragObject _currentDraggedObject = null;

    /// <summary>
    /// Gets the current dragged object.
    /// </summary>
    public DragObject CurrentDraggedObject => _currentDraggedObject;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        SetBoundingBoxRect(_dragLayer);
    }

    /// <summary>
    /// Registers the dragged object and sets its parent to the drag layer.
    /// </summary>
    /// <param name="drag">The drag object to register.</param>
    public void RegisterDraggedObject(DragObject drag)
    {
        _currentDraggedObject = drag;
        drag.transform.SetParent(_dragLayer);
    }

    /// <summary>
    /// Unregisters the dragged object and sets its parent to the default layer.
    /// </summary>
    /// <param name="drag">The drag object to unregister.</param>
    public void UnregisterDraggedObject(DragObject drag)
    {
        drag.transform.SetParent(_defaultLayer);
        _currentDraggedObject = null;
    }

    /// <summary>
    /// Checks if a position is within the bounding box.
    /// </summary>
    /// <param name="position">The position to check.</param>
    /// <returns>True if within bounds; otherwise, false.</returns>
    public bool IsWithinBounds(Vector2 position)
    {
        return _boundingBox.Contains(position);
    }

    /// <summary>
    /// Sets the bounding box based on the provided RectTransform.
    /// </summary>
    /// <param name="rectTransform">The RectTransform to set the bounding box from.</param>
    private void SetBoundingBoxRect(RectTransform rectTransform)
    {
        var corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        var position = corners[0];

        Vector2 size = new Vector2(
            rectTransform.lossyScale.x * rectTransform.rect.size.x,
            rectTransform.lossyScale.y * rectTransform.rect.size.y);

        _boundingBox = new Rect(position, size);
    }
}
