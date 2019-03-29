﻿
using Magva.Domain.Shared.Entities;

namespace Magva.Domain.Entities
{
    public class Address : Entity
    {
  
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipeCode { get; set; }

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }
    }
}
