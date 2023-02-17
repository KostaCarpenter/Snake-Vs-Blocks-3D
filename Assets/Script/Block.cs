using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI HitPointText;
    public int HitPoints { get; private set; }
    [SerializeField] int MinHitPoints = 1;
    [SerializeField] int MaxHitPoints = 6;

    public int MaxHitPoint { get { return MaxHitPoints; } }


    private void Start()
    {
        HitPoints = Random.Range(MinHitPoints, MaxHitPoints);
        HitPointText.text = HitPoints.ToString();

    }

    public void ApplyDamage()
    {
        HitPoints--;
        HitPointText.text = HitPoints.ToString();

        if (HitPoints <= 0) DestroyBlock();
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
    }

}
