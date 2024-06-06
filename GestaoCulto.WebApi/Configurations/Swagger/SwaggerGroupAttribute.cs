using System;

namespace GestaoCulto.WebApi.Configurations.Swagger
{
    public class SwaggerGroupAttribute : Attribute
    {
        public string GroupName { get; set; }
        public SwaggerGroupAttribute(string groupName)
        {
            GroupName = groupName;
        }
    }
}
