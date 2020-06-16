using UnityEngine;

public class ButtonP : MonoBehaviour
{
    public int i;
    public RectTransform myRect;

    private void Start()
    {
        myRect = GetComponent<RectTransform>();
    }
}
