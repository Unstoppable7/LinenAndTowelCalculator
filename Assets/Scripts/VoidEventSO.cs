using UnityEngine;
using UnityEngine.Events;

    /// <summary>
    /// This class is used for Events that have no arguments (Example: Exit game event)
    /// </summary>
    [CreateAssetMenu(menuName = "Elim/Events/Types/Void Event Channel")]
    public class VoidEventSO : BaseEventSO
    {
        public UnityAction OnEventRaised;

        public void RaiseEvent() => OnEventRaised?.Invoke();
    }
