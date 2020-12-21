using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIO.DAO
{
    public enum Results
    {
        GeneralError = -1,
        Ok,
        RMInvalidLogin,
        RMNoPermission,
        RMInvalidLicence,
        SqlDataError,
        ConfigurationError,
        NotImplemented,
        InvalideParameter,
        NotAvailable
    }
}
