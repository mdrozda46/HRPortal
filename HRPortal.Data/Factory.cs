using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Data
{
    public static class Factory
    {
        public static IResumeRepository CreateContactRepository()
        {
            switch (ConfigurationManager.AppSettings["mode"].ToLower())
            {
                case "test":
                    return new MockResumeRepository();
                case "prod":
                    return new ResumeRepository();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
