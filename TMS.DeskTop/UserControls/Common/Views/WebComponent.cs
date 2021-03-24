using CefSharp.Wpf;
using CefSharp;
using System.Windows;
using System.Windows.Interop;

namespace TMS.DeskTop.UserControls.Common.Views
{
	class MenuHandler : CefSharp.IContextMenuHandler
	{
		public void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
		{
			model.Clear();
		}

		public bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
		{
			return false;
		}

		public void OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
		{

		}

		public bool RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
		{
			return false;
		}
	}

	public class Web : ChromiumWebBrowser
	{
		public Web()
		{

			FrameLoadEnd += Web_FrameLoadEnd;
			MenuHandler = new MenuHandler();
		}

		private void Web_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
		{
			if (e.Frame.IsMain)
			{
				e.Browser.MainFrame.ExecuteJavaScriptAsync("document.body.style.overflow = 'hidden'");
			}
		}

		public Web(string initialAddress) : base(initialAddress)
		{
		}

		public Web(HwndSource parentWindowHwndSource, string initialAddress, Size size) : base(parentWindowHwndSource, initialAddress, size)
		{
		}
	}
}
