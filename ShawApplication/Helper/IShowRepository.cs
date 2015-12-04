using System.Collections.Generic;

namespace ShawApplication.API.Models
{
    public interface IShowRepository
    {
        void Add(Show item);
        IEnumerable<Show> GetAll();
        Show Find(int key);
        Show Remove(int key);
        void Update(Show item);

    }
}