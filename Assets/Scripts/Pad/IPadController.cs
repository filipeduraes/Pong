namespace Pong.Pad
{
    public interface IPadController
    {
        void Possess(PadMovement padMovement, bool isLeftPlayer);
    }
}