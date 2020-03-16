using System.Collections.Generic;
using System.Linq;
using AFIAPITest.Models.Repository;

namespace AFIAPITest.Models.DataManager
{
    public class RegistrationManager : IDataRepository<Registration>
    {
        readonly RegistrationContext _registrationContext;

        public RegistrationManager(RegistrationContext context)
        {
            _registrationContext = context;
        }

        public IEnumerable<Registration> GetAll()
        {
            return _registrationContext.Registrations.ToList();
        }

        public Registration Get(long id)
        {
            return _registrationContext.Registrations
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Registration entity)
        {
            _registrationContext.Registrations.Add(entity);
            _registrationContext.SaveChanges();
        }

        public void Update(Registration registration, Registration entity)
        {

            registration.Firstname = entity.Firstname;
            registration.Surname = entity.Surname;
            registration.PolicyReference = entity.PolicyReference;
            registration.DOB = entity.DOB;
            registration.Email = entity.Email;

            _registrationContext.SaveChanges();

        }

        public void Delete(Registration registration)
        {
            _registrationContext.Registrations.Remove(registration);
            _registrationContext.SaveChanges();
        }


    }
}
