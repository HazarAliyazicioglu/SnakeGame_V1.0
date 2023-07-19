using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeMovement : MonoBehaviour
{
    
    private Vector2 direction;  

    private List<Transform> segments = new List<Transform>();

    public Transform segmentPrefab;

    public int initialSize = 3;

    private void Start()
    {
        ResetState();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (direction != Vector2.down) { direction = Vector2.up; }
        } 
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (direction != Vector2.up) { direction = Vector2.down; }
        } 
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (direction != Vector2.right) { direction = Vector2.left; }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (direction != Vector2.left) { direction = Vector2.right; }
        }

    }

    private void FixedUpdate()
    {



        for (int i = segments.Count - 1; i > 0 ; i--)
        {
            segments[i].position = segments[i - 1].position;

        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x ,
            Mathf.Round(this.transform.position.y) + direction.y ,
            0.0f
            );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
        
    }

    private void ResetState()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        for (int i = 1;i < this.initialSize; i++)
        {
            segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {

        if (other.tag == "Food")
        {
            Grow();
            Score.Instance.AddPoint();
        } 
        else if (other.tag == "Obstacle")
        {
            ResetState();
            Score.Instance.ResetPoint();
            SceneManager.LoadScene("RestartMenu");
            
        }
    }

}
