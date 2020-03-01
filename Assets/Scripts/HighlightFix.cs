using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightFix : MonoBehaviour
{
    public void MouseOverMe()
    {
        if (!EventSystem.current.alreadySelecting)
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
        }
    }
}
