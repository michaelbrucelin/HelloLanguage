using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqInAction.Chapter06to08.Common
{
  public partial class Subject
  {
    public Guid ObjectId = Guid.NewGuid();

    public static void UpdateSubject(Subject changingSubject)
    {
      LinqBooksDataContext context = new LinqBooksDataContext();

      Subject existingSubject = context.Subjects.Where(subject => subject.SubjectId == changingSubject.SubjectId).FirstOrDefault();
      existingSubject.Name = changingSubject.Name;
      existingSubject.Description = changingSubject.Description;
      context.SubmitChanges();
    }
  }
}