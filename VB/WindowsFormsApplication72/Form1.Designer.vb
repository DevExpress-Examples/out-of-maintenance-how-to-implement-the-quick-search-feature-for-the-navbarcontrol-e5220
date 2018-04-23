Namespace WindowsFormsApplication72
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.navBarControl = New DevExpress.XtraNavBar.NavBarControl()
			DirectCast(Me.navBarControl, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' navBarControl1
			' 
			Me.navBarControl.ActiveGroup = Nothing
			Me.navBarControl.Dock = System.Windows.Forms.DockStyle.Left
			Me.navBarControl.Location = New System.Drawing.Point(0, 0)
			Me.navBarControl.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
			Me.navBarControl.Name = "navBarControl1"
			Me.navBarControl.OptionsNavPane.ExpandedWidth = 161
			Me.navBarControl.Size = New System.Drawing.Size(161, 341)
			Me.navBarControl.TabIndex = 0
			Me.navBarControl.Text = "navBarControl1"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(330, 341)
			Me.Controls.Add(Me.navBarControl)
			Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
			Me.Name = "Form1"
			Me.Text = "Form"
			DirectCast(Me.navBarControl, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private navBarControl As DevExpress.XtraNavBar.NavBarControl
	End Class
End Namespace

