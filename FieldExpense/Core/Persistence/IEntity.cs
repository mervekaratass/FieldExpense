
namespace Core.Persistence
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
