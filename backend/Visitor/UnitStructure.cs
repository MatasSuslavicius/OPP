namespace tower_battle.Observer
{
    //'ObjectStructure' class
    public class UnitStructure
    {
        private List<UnitElement> elements = new List<UnitElement>();

        public void Attach(UnitElement element)
        {
            elements.Add(element);
        }
        public void Detach(UnitElement element)
        {
            elements.Remove(element);
        }
        public void Accept(IVisitor visitor, bool isRightPlayer)
        {
            var list = elements.Where(x => x.isRightPlayer == isRightPlayer);
            foreach (UnitElement element in list)
            {
                element.Accept(visitor);
            }
            Console.WriteLine();
        }
    }
}
