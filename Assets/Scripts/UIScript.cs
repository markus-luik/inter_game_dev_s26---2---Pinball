using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI polaroid1;
    [SerializeField] private TextMeshProUGUI polaroid2;
    [SerializeField] private TextMeshProUGUI polaroid3;

    [SerializeField] private TextMeshProUGUI narrative1;
    [SerializeField] private TextMeshProUGUI narrative2;
    [SerializeField] private TextMeshProUGUI narrative3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        narrative1.text = "booo!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
