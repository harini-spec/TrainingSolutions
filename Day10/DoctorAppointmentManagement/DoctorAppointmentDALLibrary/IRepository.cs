namespace DoctorAppointmentDALLibrary
{
    public interface IRepository<K, T> where T : class
    {
        T Add(T item);
        T Get(K key);
        List<T> GetAll();
        T Delete(K key);
        T Update(T item);
    }
}
