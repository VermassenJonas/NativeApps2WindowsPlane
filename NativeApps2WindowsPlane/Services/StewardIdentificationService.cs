using NativeApps2WindowsPlane.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Services
{
    public class StewardIdentificationService
    {
        private Steward user;
        public void SetCurrentUser(Steward steward)
        {
            user = steward;
        }

        public Steward getCurrentUser()
        {
            return user;
        }
    }
}
