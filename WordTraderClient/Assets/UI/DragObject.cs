using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class DragObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private DragManager _manager = null;
    private Vector2 _centerPoint;
    private Vector2 _worldCenterPoint => transform.TransformPoint(_centerPoint);

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _manager = GetComponentInParent<DragManager>();
        _centerPoint = (transform as RectTransform).rect.center;
    }

    /// <summary>
    /// Called when the drag operation begins.
    /// </summary>
    /// <param name="eventData">Current event data.</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        _manager.RegisterDraggedObject(this);
    }

    /// <summary>
    /// Called every frame during the drag operation.
    /// </summary>
    /// <param name="eventData">Current event data.</param>
    public void OnDrag(PointerEventData eventData)
    {
        if (_manager.IsWithinBounds(_worldCenterPoint + eventData.delta))
        {
            transform.Translate(eventData.delta);
        }
    }

    /// <summary>
    /// Called when the drag operation ends.
    /// </summary>
    /// <param name="eventData">Current event data.</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        _manager.UnregisterDraggedObject(this);
    }
}