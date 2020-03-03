using UnityEngine;

namespace MokomoGames.UI
{
    public class UISoulCell : MonoBehaviour
    {
        public void Show(bool show)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.gameObject.SetActive(show);
            }
        }
    }
}