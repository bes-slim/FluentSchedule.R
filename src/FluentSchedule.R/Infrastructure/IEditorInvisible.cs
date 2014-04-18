using System;
using System.ComponentModel;

namespace FluentSchedule.R.Infrastructure
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEditorInvisible
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();
    }
}