using System;
using System.Collections.Generic;

namespace ProyectoSeguridad.Models.WebCategorization
{
    public class DomainCategorizationResponse
    {
        public As As { get; set; }
        public string DomainName { get; set; }
        public List<Category> Categories { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool WebsiteResponded { get; set; }
    }

    public class As
    {
        public int Asn { get; set; }
        public string Domain { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
        public string Type { get; set; }
    }

    public class Category
    {
        public double Confidence { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
