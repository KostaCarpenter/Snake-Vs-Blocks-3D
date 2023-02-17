using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Snake : MonoBehaviour
{
    [SerializeField] Transform SnakeStart;
    [SerializeField] float CollisionInterval;
    [SerializeField] float CircleDiametr;
    [SerializeField] TextMeshProUGUI HitPointText;
    [SerializeField] PlayerInput Player;
    public ParticleSystem DestroyParts;
    public ParticleSystem DestroyBlock;

    public int HitPoints { get; private set; }
    private List<Transform> SnakeBodyParts = new List<Transform>();
    private List<Vector3> Points = new List<Vector3>();
    private float CollisionTime;

    void Start()
    {
        Points.Add(SnakeStart.position);
        int StartHitPoints = Progress.SnakeLance != -1 ? Progress.SnakeLance : Progress.InitialSnakeLance;

        for (int i = 0; i < StartHitPoints; i++)
        {
            AddSnakeBody();
        }
    }

    void Update()
    {
        CollisionTime -= Time.deltaTime;
        float Distance = (SnakeStart.position - Points[0]).magnitude;
        if (Distance > CircleDiametr) 
        {
            Vector3 Direction = (SnakeStart.position - Points[0]).normalized;
            Points.Insert(0, Points[0] + Direction * CircleDiametr);
            Points.RemoveAt(Points.Count -1);
            Distance -= CircleDiametr;
        }

        for (int i = 0; i < SnakeBodyParts.Count; i++)
        {
            SnakeBodyParts[i].position = Vector3.Lerp(Points[i + 1], Points[i], Distance / CircleDiametr);
        }
    }

    private void AddSnakeBody() 
    {
        HitPoints++;
        HitPointText.text = (HitPoints + 1).ToString();
        Transform BodyPart = Instantiate(SnakeStart, Points[Points.Count -1], Quaternion.identity);
        SnakeBodyParts.Add(BodyPart);
        Points.Add(BodyPart.position);
    }

    private void RemoveBodyPart()
    {
        int Index = SnakeBodyParts.Count -1;
        if (SnakeBodyParts.Count == 0) 
        {
            Destroy(gameObject);
            Player.Die();
        }
        else
        {
            HitPoints--;
            HitPointText.text = (HitPoints + 1).ToString();
            Destroy(SnakeBodyParts[Index].gameObject);
            SnakeBodyParts.RemoveAt(Index);
            Points.RemoveAt(Index +1);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Food food))
        {
            for (int i = 0; i < food.Amount; i++)
            {
                AddSnakeBody();
            }

            Progress.SnakeLance = HitPoints;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(CollisionTime <=0 && collision.gameObject.TryGetComponent(out Block block))
        {
            DestroyParts.Play();
            block.ApplyDamage();
            RemoveBodyPart();
            CollisionTime = CollisionInterval;
            Progress.SnakeLance = HitPoints;
            if (block.HitPoints == 0)
                DestroyBlock.Play();


        }
    }
}
