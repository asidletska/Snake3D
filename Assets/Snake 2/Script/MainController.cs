using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] private Snake2 snake;
    [SerializeField] private Grid grid;
    [SerializeField] private AppleManager2 appleManager;
    [SerializeField] private Timer timer;
    private bool addSegmentOnNextTick;
    private void Tick()
    {
        if (addSegmentOnNextTick)
        {
            snake.AddSegment();
        }
        addSegmentOnNextTick = false;
        if (CheckWin())
        {
            timer.StopTimer();
            return;
        }
        ObjectType obj = snake.CheckCollide();
        switch (obj)
        {
            case ObjectType.None:
                snake.Move();
                break;
            case ObjectType.Apple:
                addSegmentOnNextTick = true;                
                CreateApple();
                snake.AddSegment();
                snake.Move();
                break;
            case ObjectType.Segment:
                Debug.LogError("GAME OVER");
                timer.StopTimer();
                break;
            case ObjectType.Block:
                Debug.LogError("GAME OVER");
                timer.StopTimer();
                break;

        }
    }
    private void CreateApple()
    {
        appleManager.CreateApple(grid.GetEmptyCells(snake.Segments));
    }
    private bool CheckWin()
    {
        return snake.Segments.Count == grid.Size * grid.Size;
    }
    public void Restart()
    {
        addSegmentOnNextTick = false;
        grid.Init();
        snake.Init(new Vector3(grid.Size / 2, 0f, grid.Size / 2));
        appleManager.Init();
        timer.StartTimer(Tick);
        CreateApple();
    }
    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
