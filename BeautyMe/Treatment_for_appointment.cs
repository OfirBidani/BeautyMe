//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeautyMe
{
    using System;
    using System.Collections.Generic;
    
    public partial class Treatment_for_appointment
    {
        public string Type_treatment_Number { get; set; }
        public string Number_appointment { get; set; }
    
        public virtual Appointment Appointment { get; set; }
        public virtual Type_Treatment Type_Treatment { get; set; }
    }
}
