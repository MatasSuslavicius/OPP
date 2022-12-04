using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets.Chain
{
    
    public abstract class Handler
    {
        protected Handler successor;
        public void SetNext(Handler successor)
        {
            this.successor = successor;
        }
        public abstract void HandleRequest(string type, ITurret turret);
    }
}
