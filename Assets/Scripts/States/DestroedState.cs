namespace States
{
    public class DestroedState : BuildingState
    {
        public override void Active()
        {
            
        }

        public override void Upgrade()
        {
        }

        public override void Sale()
        {
            _tower.SetState(Tower.BuildStateType.NotBuild);
        }

        public override void Repair()
        {
            _tower.SetState(Tower.BuildStateType.Active);
        }

        public DestroedState(Tower tower) : base(tower)
        {
        }
    }
}