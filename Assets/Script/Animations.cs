using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour
{
    public RectTransform rt;

    //public void Click()
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.transform.localScale = new Vector3(0.9f, 0.9f, 1);
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
