using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bob_paint.classes.baseClasses
{
    internal abstract class baseUndoRedo
    {
        public abstract void Undo();
        public abstract void Redo();
    }
}
