namespace States
{
    public class ActiveState : BuildingState
    {
        public override void Active()
        {
            
        }

        public override void Upgrade()
        {
           _tower.AddLevel();
        }

        public override void Sale()
        {
            _tower.SetLevel(0);
            _tower.SetState(Tower.BuildStateType.NotBuild);
        }

        public override void Repair()
        {
          
        }

        public ActiveState(Tower tower) : base(tower)
        {
        }
    }
}