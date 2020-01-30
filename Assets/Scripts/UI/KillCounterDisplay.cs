using UnityEngine;
using UnityEngine.UI;

public class KillCounterDisplay : MonoBehaviour
{
    public Text killCounterLabel;

    private void Awake()
    {
    }
    private void Update()
    {
        killCounterLabel.text = Global.count.ToString();
    }
}