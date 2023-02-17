using UnityEngine;
using TMPro;


public class Food : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AmountText;
    public int Amount { get; private set; }
    [SerializeField] int MinAmount = 1;
    [SerializeField] int MaxAmount = 6;

    private void Start()
    {
        Amount = Random.Range(MinAmount, MaxAmount);
        AmountText.text = Amount.ToString();

    }

}
