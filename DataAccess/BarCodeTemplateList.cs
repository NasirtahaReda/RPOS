using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
 public   class BarCodeTemplateList: IList<BarCodeTemplate>
    {
        #region ILIST
        private readonly IList<BarCodeTemplate> _list = new List<BarCodeTemplate>();

        public int IndexOf(BarCodeTemplate item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, BarCodeTemplate item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public BarCodeTemplate this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        public void Add(BarCodeTemplate item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(BarCodeTemplate item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(BarCodeTemplate[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return _list.IsReadOnly; }
        }

        public bool Remove(BarCodeTemplate item)
        {
            return _list.Remove(item);
        }


        public IEnumerator<BarCodeTemplate> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        } 
        #endregion
    }
}
