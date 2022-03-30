using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Linq;

namespace LinqInAction.Chapter06to08.Common
{
  public static class Helpers
  {
    public static String GetChangeText(this System.Data.Linq.DataContext context)
    {
      MethodInfo mi = typeof(DataContext).GetMethod("GetChangeText", BindingFlags.NonPublic | BindingFlags.Instance);
      return mi.Invoke(context, null).ToString();
    }

    public static String GetTableName(this DataContext context, object obj)
    {
      return context.Mapping.GetTable(obj.GetType()).TableName;
    }

    public static DataContext GetDataContext(System.ComponentModel.INotifyPropertyChanging obj)
    {
      // Of course, this isn't robust against entities from outside of LINQ to SQL,
      // nor against entities that may have multiple listeners to PropertyChanging

      var type = obj.GetType();

      // get the invocation list for PropertyChanging
      var eventMember = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
          .Where(fi => fi.Name == "PropertyChanging")
          .Single()
          .GetValue(obj);

      // get a single item, or null
      var invocationItem = ((Delegate)eventMember).GetInvocationList().SingleOrDefault();

      if (invocationItem == null)
        return null;

      // the target of the invocation is the change tracker
      var changeTracker = invocationItem.Target;

      // .. which has a services references
      var services = changeTracker.GetType().GetField("services", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(changeTracker);

      // .. which has a reference to the data context
      var context = services.GetType().GetProperty("Context", BindingFlags.Public | BindingFlags.Instance).GetValue(services, null);

      return context as DataContext;
    }
  }
}