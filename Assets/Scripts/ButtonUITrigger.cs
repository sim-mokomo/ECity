using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames
{
    [RequireComponent(typeof(Button))]
    public class ButtonUITrigger : Trigger
    {
        private Button listenButton;

        private void Awake()
        {
            listenButton = GetComponent<Button>();
            listenButton.onClick.AddListener(Detect);
        }
    }
}