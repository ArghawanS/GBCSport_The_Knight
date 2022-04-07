namespace GBCSport_The_Knight.Models 
{ 

    public interface IIncidentUnitOfWork
    {
        Repository<Customer> Customers { get; }
        Repository<Technician> Technicians { get; }
        Repository<Product> Products { get; }
        Repository<Incident> Incidents { get; }

    }
}
