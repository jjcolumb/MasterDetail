using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace MasterDetail.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Child : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Child(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string _childName;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ChildName
        {
            get => _childName;
            set => SetPropertyValue(nameof(ChildName), ref _childName, value);
        }

        string _childCode;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ChildCode
        {
            get => _childCode;
            set => SetPropertyValue(nameof(ChildCode), ref _childCode, value);
        }

        Parent _parent;
        [Association("Parent-Childs")]
        public Parent Parent
        {
            get => _parent;
            set => SetPropertyValue(nameof(Parent), ref _parent, value);
        }

    }
}