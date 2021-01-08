using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MasterDetail.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Parent : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Parent(Session session)
            : base(session)
        {
        }

        
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string _parentName;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ParentName
        {
            get => _parentName;
            set => SetPropertyValue(nameof(ParentName), ref _parentName, value);
        }

        string _parentCode;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ParentCode
        {
            get => _parentCode;
            set => SetPropertyValue(nameof(ParentCode), ref _parentCode, value);
        }


        //HACK for more info on the aggregated attribute check this link: https://docs.devexpress.com/XPO/2048/examples/how-to-create-an-aggregated-object
        [Association("Parent-Childs"), DevExpress.Xpo.Aggregated]
        public XPCollection<Child> Childs
        {
            get
            {
                return GetCollection<Child>(nameof(Childs));
            }
        }
    }
}