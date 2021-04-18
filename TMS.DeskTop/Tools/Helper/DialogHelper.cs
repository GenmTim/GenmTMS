using Prism.Services.Dialogs;
using System.Threading.Tasks;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.Dialogs.Views;

namespace TMS.DeskTop.Tools.Helper
{
    public static class DialogHelper
    {
        public static Task<IDialogResult> ShowTextBoxDialog(IDialogHostService dialogHostService, string identifierName, string title, string positiveText, string negativeText, string inputHint = "")
        {
            var param = new DialogParameters();
            param.Add("title", title);
            param.Add("positive_text", positiveText);
            param.Add("negative_text", negativeText);
            param.Add("input_hint", inputHint);
            return dialogHostService.ShowDialog(nameof(TextBoxDialog), param, identifierName);
        }

        public static Task<IDialogResult> ShowQuestionDialog(IDialogHostService dialogHostService, string identifierName, string title, string positiveText, string negativeText, string question = "")
        {
            var param = new DialogParameters();
            param.Add("title", title);
            param.Add("positive_text", positiveText);
            param.Add("negative_text", negativeText);
            param.Add("question", question);
            return dialogHostService.ShowDialog(nameof(QuestionDialog), param, identifierName);
        }
    }
}
