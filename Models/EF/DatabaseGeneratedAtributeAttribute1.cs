using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteBH.Models.EF
{
    internal class DatabaseGeneratedAtributeAttribute : Attribute
    {
        public DatabaseGeneratedAtributeAttribute(DatabaseGeneratedOption identity)
        {
            Identity = identity;
        }

        public DatabaseGeneratedOption Identity { get; }
    }
}