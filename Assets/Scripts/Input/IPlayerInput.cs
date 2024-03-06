using UniRx;

namespace Input
{
    public interface IPlayerInput
    {
        FloatReactiveProperty Forward { get; }
        FloatReactiveProperty Backward { get; }
        FloatReactiveProperty StrafeLeft { get; }
        FloatReactiveProperty StrafeRight { get; }
        ReactiveCommand Stop { get; }
    }
}