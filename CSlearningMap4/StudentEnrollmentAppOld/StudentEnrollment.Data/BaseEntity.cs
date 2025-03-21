﻿using System.Reflection.Metadata;

namespace StudentEnrollment.Data
{
    public abstract class BaseEntity 
    {

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
