using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication72
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SearchHelper.CreateSearchPanel(navBarControl, SearchCriteria.Contains);

            InitNavBar();
        }

        private void InitNavBar()
        {
            NavBarGroup group;
            NavBarItem item;
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                group = new NavBarGroup(string.Format("Group{0}", i));

                for (int j = 0; j < 8; j++)
                {
                    item = new NavBarItem(string.Format("Item{0}", count));
                    group.ItemLinks.Add(item);
                    count++;
                }
                group.Expanded = true;
                navBarControl.Groups.Add(group);
            }
        }
    }
}
