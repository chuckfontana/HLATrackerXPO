using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLATrackerXPO.Models
{
    public class UnosId:XPObject
    {
        public UnosId(Session session) : base(session) { }

        Patient patient;
        public Patient Patient
        {
            get { return this.patient; }
            set { SetPropertyValue(nameof(this.Patient), ref this.patient, value); }
        }

        string unosRegistrationId;
        [Indexed(Unique = true)]
        [DbType("varchar(20) NOT")]
        public string UnosRegistrationId
        {
            get { return this.unosRegistrationId; }
            set { SetPropertyValue(nameof(this.UnosRegistrationId), ref this.unosRegistrationId, value); }
        }

        string organ;
        [Indexed(Unique = true)]
        [DbType("char(2) NOT")]
        public string Organ
        {
            get { return this.organ; }
            set { SetPropertyValue(nameof(this.Organ), ref this.organ, value); }
        }
    }
}
