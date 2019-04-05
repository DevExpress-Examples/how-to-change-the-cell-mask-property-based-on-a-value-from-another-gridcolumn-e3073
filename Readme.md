<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/2583 - CellMaskBinding/MainPage.xaml) (VB: [MainPage.xaml](./VB/2583 - CellMaskBinding/MainPage.xaml))
* [MainPage.xaml.cs](./CS/2583 - CellMaskBinding/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/2583 - CellMaskBinding/MainPage.xaml.vb))
<!-- default file list end -->
# How to change the cell Mask property based on a value from another GridColumn


<p>Implement a CellTemplate for a grid column that you want to change the Mask property for. In this template, define a TextEdit and set its x:Name property to "PART_Editor". This editor will be used by the GridControl for displaying and editing values in this column. The last step is to bind this TextEdit's Mask property to a necessary value from another column and define an appropriate convertor for this binding.<br />
</p>

<br/>


