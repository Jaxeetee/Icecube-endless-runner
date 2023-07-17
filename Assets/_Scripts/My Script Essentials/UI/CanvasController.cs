using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private string _pageName;

    public string pageName
    {
        get => _pageName;
        set => _pageName = value;
    }
}
