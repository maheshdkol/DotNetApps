using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCGridDemo.Models;

namespace MVCGridDemo.Repository
{
    public interface ISchemeRepository
    {
        //static int iTest = 0;

        // Test property in Interface
        int MyProperty { get; set; }

        //MyDBEntities myDBEntities = new MyDBEntities();
        IEnumerable<SchemeMaster> GetAll();
        SchemeMaster GetScheme(int SchemeId);
    }
}