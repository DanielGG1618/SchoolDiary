using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_diary
{
    public partial class AllTasks : UserControl
    {
        private List<LessonView> _lessonViews = new List<LessonView>();

        public AllTasks()
        {
            InitializeComponent();
        }

        public void Reload(object sender, EventArgs e)
        {
            ClearLessonViews();
            InitializeLessons();
            Visualize(_lessonViews);
        }

        private void CopyButtonButtonClick(object sender, EventArgs e)
        {
            _copyButton.Visible = _copyButtonButton.Checked;
        }

        private void RefreshButtonButtonClick(object sender, EventArgs e)
        {
            _refreshButton.Visible = _refreshButtonButton.Checked;
        }

        private void InitializeLessons()
        {
            Lesson[] current = SQL.GetAllTasks();

            for (int i = 0; i < current.Length; i++)
                _lessonViews.Add(new LessonView(current[i], current[i].Date, i)); 
            
        }

        private void Visualize(List<LessonView> lessonViews)
        {
            for (int i = 0; i < lessonViews.Count; i++)
            {
                LessonView lesson = _lessonViews[i];
                lesson.Dock = DockStyle.Top;
                _lessonsPanel.Controls.Add(lesson);
                lesson.BringToFront();
            }
        }

        private void ClearLessonViews()
        {
            foreach (var lesson in _lessonViews)
                _lessonsPanel.Controls.Remove(lesson);

            _lessonViews.Clear();
        }

        private void СopyButtonClick(object sender, EventArgs e)
        {
            _copyButton.Visible = false;

            Clipboard.SetImage(Utils.GetControlScreenshot(this));

            _copyButton.Visible = true;
        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            for (int i = 0; i < _lessonViews.Count; i++)
            {
                LessonView lesson = _lessonViews[i];
                if (lesson.GetDone())
                {
                    _lessonViews.Remove(lesson);
                    _lessonsPanel.Controls.Remove(lesson);
                    i--;
                }
            }
        }

        private void CheckAllButtonClick(object sender, EventArgs e)
        {
            foreach (var lesson in _lessonViews)
                lesson.Check();
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (Width > 460)
                _checkAllButton.Show();
            else
                _checkAllButton.Hide();
        }
    }
}
