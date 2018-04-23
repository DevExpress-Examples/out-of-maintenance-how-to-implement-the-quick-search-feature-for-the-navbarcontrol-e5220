Imports DevExpress.XtraEditors
Imports DevExpress.XtraNavBar
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace WindowsFormsApplication72
	Public Enum SearchCriteria
		Contains
		StartsWith
		Equals
	End Enum

	Public NotInheritable Class SearchHelper

		Private Sub New()
		End Sub

		Private Shared navBarControl As NavBarControl
		Private Shared textEdit As TextEdit
		Private Shared criteria As SearchCriteria

		Public Shared Sub CreateSearchPanel(ByVal _navBarControl As NavBarControl, ByVal _criteria As SearchCriteria)
			If _navBarControl IsNot Nothing Then
				navBarControl = _navBarControl
				criteria = _criteria
				textEdit = New TextEdit()
				Dim navBarGroup As New NavBarGroup()
				_navBarControl.Groups.Insert(0, navBarGroup)
				navBarGroup.GroupStyle = NavBarGroupStyle.ControlContainer
				navBarGroup.Caption = "Search"

				navBarGroup.ControlContainer.Controls.Add(textEdit)
				textEdit.Dock = System.Windows.Forms.DockStyle.Fill
				textEdit.Visible = True
				navBarGroup.GroupClientHeight = 26
				navBarGroup.Expanded = True
				_navBarControl.Groups.Add(navBarGroup)

				AddHandler _navBarControl.CustomDrawGroupCaption, AddressOf navBarControl_CustomDrawGroupCaption
				AddHandler textEdit.EditValueChanged, AddressOf textEdit_EditValueChanged
			End If
		End Sub

		Private Shared Sub navBarControl_CustomDrawGroupCaption(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventArgs)
			If e.Caption = "Search" Then
				Dim rect As Rectangle = e.RealBounds
				rect.Inflate(-10, -5)

				e.Graphics.DrawString(e.Caption, e.Appearance.Font, Brushes.Black, rect)
				e.Handled = True
			End If
		End Sub

		Private Shared Sub textEdit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			navBarControl.BeginUpdate()
			For Each group As NavBarGroup In navBarControl.Groups
				For Each link As NavBarItemLink In group.ItemLinks
					Select Case criteria
						Case SearchCriteria.Contains
							link.Visible = link.Caption.Contains(textEdit.Text)
						Case SearchCriteria.StartsWith
							 link.Visible = link.Caption.StartsWith(textEdit.Text)
						Case SearchCriteria.Equals
							link.Visible = link.Caption.Equals(textEdit.Text)
					End Select
					If group.VisibleItemLinks.Count = 0 Then
						group.Visible = False
					Else
						group.Visible = True
					End If
				Next link
			Next group
			navBarControl.EndUpdate()
		End Sub

	End Class
End Namespace
