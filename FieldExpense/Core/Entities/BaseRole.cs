
using Core.Persistence;

namespace Core.Entities
{
    public class BaseRole:Entity<int>
    {
        public string Name {  get; set; }
    }
}
