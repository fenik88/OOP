using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace bob_paint.classes.lists
{
    internal class UndoRedoShapes
    {
        public List<BaseShape> shapes { get; set; } = new List<BaseShape>();
        private List<BaseShape> redo = new List<BaseShape>();




        public  bool CanUndo { get { return shapes.Count > 0; } }
        public  bool CanRedo { get { return redo.Count > 0; } }


        public void AddShape(BaseShape shape)
        {
            redo.Clear();
            shapes.Add(shape);
        }


        public void Clear()
        {
            redo= shapes;
            shapes.Clear();  
        }
       
        public void Undo()
        {
            if (!CanUndo) return;
            redo.Add(shapes[shapes.Count-1]);
            shapes.RemoveAt(shapes.Count - 1); 
        }
       
        public void Redo()
        {
            if (!CanRedo) return;
            shapes.Add(redo[redo.Count - 1]);
            redo.RemoveAt(redo.Count - 1);
        }

        public  void ClearHistory()
        {
            redo.Clear();
        }

      
    }
}
