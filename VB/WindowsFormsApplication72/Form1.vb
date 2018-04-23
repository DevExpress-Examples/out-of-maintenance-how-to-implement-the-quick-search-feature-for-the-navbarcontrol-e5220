Imports DevExpress.XtraNavBar
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace WindowsFormsApplication72
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
			SearchHelper.CreateSearchPanel(navBarControl, SearchCriteria.Contains)

			InitNavBar()
		End Sub

		Private Sub InitNavBar()
			Dim group As NavBarGroup
			Dim item As NavBarItem
			Dim count As Integer = 0
			For i As Integer = 0 To 9
				group = New NavBarGroup(String.Format("Group{0}", i))

				For j As Integer = 0 To 7
					item = New NavBarItem(String.Format("Item{0}", count))
					group.ItemLinks.Add(item)
					count += 1
				Next j
				group.Expanded = True
				navBarControl.Groups.Add(group)
			Next i
		End Sub
	End Class
End Namespace
