using Microsoft.UI.Xaml;
using Microsoft.UI.Text;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace POCRichEditBox_NewLineFontSetIssue_WinUI3
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();
		}

		private void Button_Click_AddSample(object sender, RoutedEventArgs e)
		{
			var sampleText = "\nThis is sample text, WITH a newline at the beginning, and using the Ravie font family.";
			MyRichEditBox_1.Document.SetText(TextSetOptions.None, sampleText);

			MyRichEditBox_1.Focus(FocusState.Keyboard);
			var textSelection = MyRichEditBox_1.Document.Selection;
			textSelection.SetRange(0, TextConstants.MaxUnitCount);
			textSelection.CharacterFormat.Name = "Ravie";
			textSelection.CharacterFormat.Size = 18;

			sampleText = "This is sample text, WITHOUT a newline at the beginning, and using the Ravie font family.";
			MyRichEditBox_1_1.Document.SetText(TextSetOptions.None, sampleText);

			MyRichEditBox_1_1.Focus(FocusState.Keyboard);
			textSelection = MyRichEditBox_1_1.Document.Selection;
			textSelection.SetRange(0, TextConstants.MaxUnitCount);
			textSelection.CharacterFormat.Name = "Ravie";
			textSelection.CharacterFormat.Size = 18;
		}

		private void Button_Click_CopyPaste(object sender, RoutedEventArgs e)
		{
			MyRichEditBox_1.Document.GetText(TextGetOptions.FormatRtf, out var copyTextRtf_1);
			//MyRichEditBox_2.Document.SetText(TextSetOptions.FormatRtf | TextSetOptions.ApplyRtfDocumentDefaults, copyTextRtf_1);
			MyRichEditBox_2.Document.SetText(TextSetOptions.FormatRtf, copyTextRtf_1);

			MyRichEditBox_1_1.Document.GetText(TextGetOptions.FormatRtf, out var copyTextRtf_2);
			//MyRichEditBox_2_1.Document.SetText(TextSetOptions.FormatRtf | TextSetOptions.ApplyRtfDocumentDefaults, copyTextRtf_2);
			MyRichEditBox_2_1.Document.SetText(TextSetOptions.FormatRtf, copyTextRtf_2);
		}
	}
}
