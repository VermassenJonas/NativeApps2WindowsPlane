using NativeApps2WindowsPlane.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Services
{
    public class PassengerIdentificationService
    {
        private Passenger user;
        public void SetCurrentUser(Passenger passenger)
        {
            user = passenger;
        }

        public Passenger getCurrentUser()
        {
            return user;
        }
    }
}
