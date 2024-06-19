using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.Shared.Extensions.DataExtension
{
    public static class DataExtensions
    {
        public static EntityEntry SetProperty(this EntityEntry entry, string propertyName, object value)
        {
            try
            {
                if (entry != null && entry.Properties.Any(x => x.Metadata.Name == propertyName))
                {
                    var prop = entry.Property(propertyName);

                    if (prop != null) prop.CurrentValue = value;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return entry;
        }
 

      

    }


}