using UnityEngine;

public class Item : MonoBehaviour
{
    public int i;
    public RectTransform myRect;

    private void Start()
    {
        myRect = GetComponent<RectTransform>();
    }
}
