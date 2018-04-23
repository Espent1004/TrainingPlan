using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;

namespace DAL
{
    public class DbInit : CreateDatabaseIfNotExists<TpContext>
    {
    }
}
