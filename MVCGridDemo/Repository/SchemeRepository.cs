using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCGridDemo.Models;

namespace MVCGridDemo.Repository
{
    public class SchemeRepository : ISchemeRepository
    {
        MyDBEntities myDBEntities;

        public SchemeRepository()
        {
            myDBEntities = new MyDBEntities();
        }

        // Test property in Interface
        public int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<SchemeMaster> GetAll()
        {
            var SchemeList = (from scheme in myDBEntities.SchemeMasters select scheme).ToList();
            return SchemeList;
        }

        public SchemeMaster GetScheme(int SchemeId)
        {
            var SchemeList = (from scheme in myDBEntities.SchemeMasters select scheme).ToList();
            SchemeMaster schemeMaster = new SchemeMaster();
            schemeMaster = SchemeList.FirstOrDefault(Id => Id.SchemeID == SchemeId);
            return schemeMaster;
        }
    }
}