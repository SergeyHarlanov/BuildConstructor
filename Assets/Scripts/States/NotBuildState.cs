namespace States
{
    public class NotBuildState : BuildingState
    {
        public override void Active()
        {
            _tower.SetState(Tower.BuildStateType.Active);
        }

        public override void Upgrade()
        {
       
        }

        public override void Sale()
        {
          
        }

        public override void Repair()
        {
         
        }

        public NotBuildState(Tower tower) : base(tower)
        {
        }
    }
}