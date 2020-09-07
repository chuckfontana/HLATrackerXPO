using DevExpress.Xpo;
using System.Collections.Generic;
using System.Text;

namespace HLATrackerXPO.Models
{
    public class Patient : XPObject
    {
        public Patient(Session session): base(session){}

        string mrn;
        [Indexed(Unique = true)]
        [DbType("nvarchar(20) NOT")]
        public string MRN
        {
            get { return this.mrn; }
            set { SetPropertyValue(nameof(this.MRN), ref this.mrn, value); }
        }

        string lastName;
        [DbType("nvarchar(30) NOT")]
        public string LastName
        {
            get { return this.lastName; }
            set { SetPropertyValue(nameof(this.LastName), ref this.lastName, value); }
        }

        string firstName;
        [DbType("nvarchar(30) NOT")]
        public string FirstName
        {
            get { return this.firstName; }
            set { SetPropertyValue(nameof(this.FirstName), ref this.firstName, value); }
        }
    }
}
