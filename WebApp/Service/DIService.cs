namespace Service
{
    public interface ITransient
    {
        Guid Value();
    }
    public interface IScoped
    {
        Guid Value();
    }
    public interface ISingleton
    {
        Guid Value();
    }

    public class DIService : ITransient, IScoped, ISingleton
    {
        private Guid _id = Guid.NewGuid();
        public Guid Value()
        {
            return _id;
        }
    }
}
