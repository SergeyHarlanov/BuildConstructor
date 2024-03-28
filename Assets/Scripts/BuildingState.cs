
    public abstract class BuildingState
    {
        protected Tower _tower;

        public BuildingState(Tower tower)
        {
            _tower = tower;
        }
        public abstract void Active();
        public abstract void Upgrade();
        public abstract void Sale();
        public abstract void Repair();
    }
