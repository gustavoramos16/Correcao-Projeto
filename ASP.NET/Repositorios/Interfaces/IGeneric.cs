namespace ASP.NET.Repositorios.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        public Task<List<T>> ViewAll();
        public Task<T> SearchID(int IDtosearch);
        public Task<T> Add(T nameToAdd);

        public Task<T> Update(T nameToUpdate, int id);

        public Task<bool> Delete(int id);
        
    }
}
