using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LinqInAction.Chapter06to08.Common.SampleHarness
{
    public class SampleItem
    {
        public int Chapter { get; set; }
        public int ListingNumber { get; set; }
        public string Description { get; set; }
        public MethodInfo Method { get; set; }
    }

    public class SampleClass
        : IEnumerable<SampleItem>
    {
        List<SampleItem> _MethodList;
        String _Title;
        StreamWriter _OutputStreamWriter;

        public SampleClass()
        {
            _OutputStreamWriter = new StreamWriter(new MemoryStream());

            Type ClassType = base.GetType();
            this._Title = ClassType.Name;

            var items = from MethodInfo _method in ClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                        from SampleAttribute _attrib in _method.GetCustomAttributes(false).OfType<SampleAttribute>()
                        select new SampleItem
                        {
                            Method = _method,
                            Description = _attrib.Description,
                            Chapter = _attrib.Chapter,
                            ListingNumber = _attrib.ListingNumber
                        };

            _MethodList = new List<SampleItem>();
            _MethodList.AddRange(items);
        }

        #region IEnumerable<SampleItem> Members

        public IEnumerator<SampleItem> GetEnumerator()
        {
            return _MethodList.GetEnumerator();
        }

        #endregion

        //#region IEnumerable Members

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return _MethodList.GetEnumerator();
        //}

        //#endregion

        public SampleItem this[int index]
        {
            get
            {
                return this._MethodList[index];
            }
        }

        public string Title
        {
            get { return _Title; }
        }

        public StreamWriter OutputStreamWriter
        {
            get { return _OutputStreamWriter; }
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _MethodList.GetEnumerator();
        }

        #endregion
    }
}