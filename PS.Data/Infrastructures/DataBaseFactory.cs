using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructures
{
    public class DataBaseFactory:Disposable,IDataBaseFactory
    {
        private PSContext datacontext;
        public PSContext DataContext
        {
            get { return datacontext; }
        }
        public DataBaseFactory()
        {
            datacontext = new PSContext();
        }
        protected override void DisposeCore()
        {
            datacontext.Dispose();
        }
    }
}
