using Hospital.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hospital.Model.Refferals
{
    [JsonDerivedType(typeof(Refferal), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(DoctorRefferal), typeDiscriminator: "doctor")]
    [JsonDerivedType(typeof(SpecializationRefferal), typeDiscriminator: "specialization")]
    [JsonDerivedType(typeof(HospitalTreatmentRefferal), typeDiscriminator: "hospital")]
    public class Refferal
    {
        public int Id { get; set; }
        private int _patientId;

        public int PatientId
        {
            get => _patientId;
            set
            {
                if (value != _patientId)
                {
                    _patientId = value;
                }
            }
        }

        public Refferal() { }

        public Refferal(int patientId)
        {
            
            PatientId = patientId;
        }
    }
}
