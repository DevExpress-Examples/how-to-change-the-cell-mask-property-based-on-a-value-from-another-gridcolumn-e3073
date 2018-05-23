Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports DevExpress.Xpf.Grid
Imports System.ComponentModel

Namespace _2583___CellMaskBinding
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Class MasksConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
			If value Is Nothing Then
				Return Nothing
			End If
			Return If(CType(value, Masks) = Masks.Currency, "c", "d")
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New NotImplementedException()
		End Function
	End Class

	Public Enum Masks
		Numeric
		Currency
	End Enum

	Public Class TestDataContainer

		Public ReadOnly Property Records() As List(Of TestData)
			Get
				Return New List(Of TestData) (New TestData() {New TestData(Masks.Currency, 10123), New TestData(Masks.Numeric, 10123), New TestData(Masks.Numeric, 91234)})
			End Get
		End Property

		Public ReadOnly Property MaskTypes() As List(Of Masks)
			Get
				Return New List(Of Masks)(New Masks() {Masks.Numeric, Masks.Currency})
			End Get
		End Property
	End Class

	Public Class TestData
		Implements INotifyPropertyChanged
		Private mask As Masks
		Public Sub New(ByVal mask As Masks, ByVal salary As Double)
			MaskType = mask
			Salary = salary
		End Sub
		Public Property MaskType() As Masks
			Get
				Return mask
			End Get
			Set(ByVal value As Masks)
				mask = value
				RaisePropertyChanged("MaskType")
			End Set
		End Property
		Private privateSalary As Double
		Public Property Salary() As Double
			Get
				Return privateSalary
			End Get
			Set(ByVal value As Double)
				privateSalary = value
			End Set
		End Property

		#Region "INotifyPropertyChanged members"
		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Private Sub RaisePropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
		#End Region
	End Class
End Namespace
