using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication72
{
    public enum SearchCriteria
    {
        Contains,
        StartsWith,
        Equals
    }

    public static class SearchHelper
    {
        static NavBarControl navBarControl;
        static TextEdit textEdit;
        static SearchCriteria criteria;

        public static void CreateSearchPanel(NavBarControl _navBarControl, SearchCriteria _criteria)
        {
            if (_navBarControl != null)
            {
                navBarControl = _navBarControl;
                criteria = _criteria;
                textEdit = new TextEdit();
                NavBarGroup navBarGroup = new NavBarGroup();
                _navBarControl.Groups.Insert(0, navBarGroup);
                navBarGroup.GroupStyle = NavBarGroupStyle.ControlContainer;
                navBarGroup.Caption = "Search";
                
                navBarGroup.ControlContainer.Controls.Add(textEdit);
                textEdit.Dock = System.Windows.Forms.DockStyle.Fill;
                textEdit.Visible = true;
                navBarGroup.GroupClientHeight = 26;
                navBarGroup.Expanded = true;
                _navBarControl.Groups.Add(navBarGroup);

                _navBarControl.CustomDrawGroupCaption += navBarControl_CustomDrawGroupCaption;
                textEdit.EditValueChanged += textEdit_EditValueChanged;
            }
        }

        static void navBarControl_CustomDrawGroupCaption(object sender, DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventArgs e)
        {
            if (e.Caption == "Search")
            {
                Rectangle rect = e.RealBounds;
                rect.Inflate(-10, -5);

                e.Graphics.DrawString(e.Caption, e.Appearance.Font, Brushes.Black, rect);
                e.Handled = true;
            }
        }

        static void textEdit_EditValueChanged(object sender, EventArgs e)
        {
            navBarControl.BeginUpdate();
            foreach (NavBarGroup group in navBarControl.Groups)
            {
                foreach (NavBarItemLink link in group.ItemLinks)
                {
                    switch (criteria){
                        case SearchCriteria.Contains:
                            link.Visible = link.Caption.Contains(textEdit.Text);
                            break;
                        case SearchCriteria.StartsWith:
                             link.Visible = link.Caption.StartsWith(textEdit.Text);
                            break;
                        case SearchCriteria.Equals:
                            link.Visible = link.Caption.Equals(textEdit.Text);
                            break;
                    }
                    if (group.VisibleItemLinks.Count == 0)
                        group.Visible = false;
                    else
                        group.Visible = true;
                }
            }
            navBarControl.EndUpdate();
        }

    }
}
