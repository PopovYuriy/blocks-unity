namespace Game
{
    public interface IGameController
    {
        GameState GetCurrentState();
        void 
        void startMoving(SlideDirection direction);
    }
}