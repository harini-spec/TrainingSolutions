using HotelManagementModels;

namespace HotelManagementDAL
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        readonly Dictionary<int, Customer> _customers;

        public CustomerRepository()
        {
            _customers = new Dictionary<int, Customer>();
        }

        public int GenerateId()
        {
            if (_customers.Count == 0)
                return 1;
            int id = _customers.Keys.Max();
            return ++id;
        }

        public Customer Add(Customer item)
        {
            if (_customers.ContainsValue(item))
                return null;
            int Id = GenerateId();
            item.Id = Id;
            _customers.Add(Id, item);
            return _customers[Id];
        }

        public Customer Delete(int key)
        {
            if (_customers.ContainsKey(key))
            {
                var Customer = _customers[key];
                _customers.Remove(key);
                return Customer;
            }
            return null;
        }

        public Customer Get(int key)
        {
            return _customers.ContainsKey(key) ? _customers[key] : null;
        }

        public List<Customer> GetAll()
        {
            if (_customers.Count == 0)
                return null;
            return _customers.Values.ToList();
        }

        public Customer Update(Customer item)
        {
            if (_customers.ContainsKey(item.Id))
            {
                _customers[item.Id] = item;
                return _customers[item.Id];
            }
            return null;
        }
    }
}
