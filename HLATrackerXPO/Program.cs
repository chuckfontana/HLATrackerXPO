using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using HLATrackerXPO.Models;
using System;
using System.Configuration;
using System.Linq;

namespace HLATrackerXPO
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["HLATracker"].ConnectionString;
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);

            AddUnosId();

            Console.WriteLine(GetOrgansPatientIsListedFor().First());
            Console.WriteLine(GetOrgansPatientIsListedFor().Last());

            Console.ReadLine();
        }

        static string[] GetOrgansPatientIsListedFor()
        {
            using(var uow = new UnitOfWork())
            {
                return new XPQuery<UnosId>(uow).Where(u => u.Patient.Oid == 1).Select(u => u.Organ).ToArray<string>();
            }
        }

        static void AddPatient()
        {
            using (var uow = new UnitOfWork())
            {
                var patient = new Patient(uow);
                patient.LastName = "Sample";
                patient.FirstName = "First";
                patient.MRN = "1234567";

                try
                {
                    uow.CommitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Patient Added!");
        }


        static void AddUnosId()
        {
            using (var uow = new UnitOfWork())
            {
                var unosId = new UnosId(uow);
                unosId.UnosRegistrationId = "987654321";
                unosId.Patient = uow.GetObjectByKey<Patient>(1);
                unosId.Organ = UnosOrganType.Liver;

                try
                {
                    uow.CommitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Unos Id Added!");
        }
    }
}

