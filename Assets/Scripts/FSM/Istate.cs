namespace Assets.Scripts.FSM
{
    public interface Istate
    {
        public string Name { get; }
        public void Enter();
        public void Exit();
        public void Update();

    }
}