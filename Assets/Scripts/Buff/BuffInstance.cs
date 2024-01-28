namespace GGJ
{
    public abstract class BuffInstance : IBuff
    {
        public int Id => _id;
        protected int _id;

        public BuffType Type => _type;
        protected BuffType _type;

        public IBuffOwner Owner => _owner;
        protected IBuffOwner _owner;
        
        protected BuffInstance(int id, BuffType type, IBuffOwner owner)
        {
            _id = id;
            _type = type;
            _owner = owner;
        }

        public abstract void Effect();
    }
}