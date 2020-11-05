using Sims3.SimIFace;
using Sims3.UI;
using System;
namespace NiecMod.Nra
{
    public class NCopyableTextDialog
    {
        private const int kUseDefaultMax = int.MaxValue;

        public class UICopyableTextDialog : ModalDialog
        {
            private enum ControlID : uint
            {
                kCancelButtonID = 4u,
                kInputAreaBG = 7u,
                kInputTextBGID = 6u,
                kInputTextEditID = 2u,
                kOKButtonID = 3u,
                kPromptTextID = 1u,
                kTitleTextID = 5u
            }


            private const string kMultiLayoutName = "MultiLineStringInputDialog";

            

            private const int kWinExportID = 4096;

            private Button mCancelButton;

            private Button mOkButton;

            private void OnTextEditFirstMouseDown(WindowBase sender, UIMouseEventArgs eventArgs)
            {
                TextEdit textEdit = sender as TextEdit;
                if (textEdit != null)
                {
                    textEdit.Enabled = true;
                    textEdit.TextStyle = 103722243u;
                    if (eventArgs != null)
                    {
                        textEdit.TextChange -= OnTextChange;
                        textEdit.Caption = "";
                        UIManager.SetFocus(InputContext.kICKeyboard, textEdit);
                        textEdit.MouseDown -= OnTextEditFirstMouseDown;
                    }
                }
            }
            public string Org = "";
            public string Result = "";
            public override bool OnEnd(uint endID)
            {
                if (endID == 3)
                {
                    TextEdit textEdit = mModalDialogWindow.GetChildByID(2u, true) as TextEdit;
                    if (textEdit != null && textEdit.Enabled)
                    {
                        Result = textEdit.Caption;
                    }
                }
                else if (endID == 2) {
                    TextEdit textEdit = mModalDialogWindow.GetChildByID(2u, true) as TextEdit;
                    if (textEdit != null && textEdit.Enabled)
                    {
                        Result = Org;
                    }
                }
                return true;
            }

            private void OnTextChange(WindowBase sender, UITextChangeEventArgs eventArgs)
            {
                TextEdit textEdit = sender as TextEdit;
                if (textEdit != null)
                {
                    textEdit.TextStyle = 103722243u;
                    textEdit.MouseDown -= OnTextEditFirstMouseDown;
                    textEdit.TextChange -= OnTextChange;
                }
            }

            private void OnTick(WindowBase sender, UIEventArgs eventArgs)
            {
                TextEdit textEdit = mModalDialogWindow.GetChildByID(2u, true) as TextEdit;
                if (textEdit != null)
                {
                    uint length = (uint)textEdit.Caption.Length;
                    textEdit.AnchorIndex = 0;
                    textEdit.CursorIndex = length;
                    UIManager.SetFocus(InputContext.kICKeyboard, textEdit);
                    textEdit.HideCaret = false;
                }
                mModalDialogWindow.Tick -= OnTick;
            }

            private void OnButtonClick(WindowBase sender, UIButtonClickEventArgs eventArgs)
            {
                eventArgs.Handled = true;
                EndDialog(sender.ID);
            }

            private void OnCloseButtonClick(WindowBase sender, UIDialogFinishedEventArgs eventArgs)
            {
                eventArgs.Handled = true;
                EndDialog(4);
            }

            public UICopyableTextDialog(string titleText, string promptText, string defaultEntryText, int maxLength, Vector2 position, PauseMode pauseMode)
                : base(kMultiLayoutName, kWinExportID, true, pauseMode, null)
            {
                if (mModalDialogWindow == null)
                {
                    niec_std.assert("mModalDialogWindow == null");
                    return;
                }

                float numHeight = 0f;
                Rect area = mModalDialogWindow.Area;

                Text text5ID = mModalDialogWindow.GetChildByID(5, true) as Text;
                if (text5ID != null)
                {
                    numHeight = text5ID.Area.Height;

                    text5ID.Caption = titleText;
                    text5ID.AutoSize(true);

                    if (text5ID.Area.Height > numHeight)
                    {
                        WindowBase childByID = mModalDialogWindow.GetChildByID(7, true);
                        if (childByID != null)
                        {
                            childByID.Area = new Rect(new Vector2(childByID.Area.TopLeft.x, childByID.Area.TopLeft.y + (text5ID.Area.Height - numHeight)), childByID.Area.BottomRight);
                        }

                        area.Height += text5ID.Area.Height - numHeight;
                        mModalDialogWindow.Area = area;
                    }
                }

                Text text1ID = mModalDialogWindow.GetChildByID(1, true) as Text;
                if (text1ID != null)
                {
                    numHeight = text1ID.Area.Height;

                    text1ID.Caption = promptText;
                    text1ID.AutoSize(true);

                    if (text1ID.Area.Height > numHeight)
                    {
                        area = mModalDialogWindow.Area;
                        area.Height += text1ID.Area.Height - numHeight;

                        mModalDialogWindow.Area = area;
                    }
                    else
                    {
                        text1ID.Area = new Rect(text1ID.Area.TopLeft, new Vector2(text1ID.Area.BottomRight.x, text1ID.Area.TopLeft.y + numHeight));
                    }
                }

                TextEdit textEdit = mModalDialogWindow.GetChildByID(2, true) as TextEdit;
                if (maxLength > 0)
                {
                    textEdit.MaxTextLength = (uint)maxLength;
                }

                if (textEdit != null)
                {
                    if (defaultEntryText != "")
                    {
                        Org = defaultEntryText;
                        textEdit.Caption = defaultEntryText;
                        textEdit.AnchorIndex = 0u;
                        OnTextEditFirstMouseDown(textEdit, null);
                    }
                    else
                    {
                        textEdit.MouseDown += OnTextEditFirstMouseDown;
                        textEdit.TextChange += OnTextChange;
                    }
                }
                if (position.x < 0f && position.y < 0f)
                {
                    mModalDialogWindow.CenterInParent();
                }
                else
                {
                    float numXX = area.BottomRight.x - area.TopLeft.x;
                    float numYY = area.BottomRight.y - area.TopLeft.y;

                    float x = position.x;
                    float y = position.y;

                    area.Set(x, y, x + numXX, y + numYY);
                    mModalDialogWindow.Area = area;
                }

                mOkButton = (mModalDialogWindow.GetChildByID(3, false) as Button);

                //ILocalizationModel localizationModel = Responder.Instance.LocalizationModel;
                if (mOkButton != null)
                {
                    mOkButton.Click += OnButtonClick;
                }

                mCancelButton = (mModalDialogWindow.GetChildByID(4, false) as Button);
                if (mCancelButton != null)
                {
                    mCancelButton.Click += OnButtonClick;
                }

                mModalDialogWindow.CloseButtonPressed += OnCloseButtonClick;

                base.CancelID = 4;

                mModalDialogWindow.Tick += OnTick;

                base.OkayID = 3;
                base.SelectedID = 2;
            }

            public static string Show(string titleText, string promptText, string defaultEntryText)
            {
                return Show(titleText, promptText, defaultEntryText, kUseDefaultMax, new Vector2(-1f, -1f), PauseMode.PauseSimulator, false);
            }

            public static string Show(string titleText, string promptText, string defaultEntryText, PauseMode pauseMode)
            {
                return Show(titleText, promptText, defaultEntryText, kUseDefaultMax, new Vector2(-1f, -1f), pauseMode, false);
            }

            public static string Show(string titleText, string promptText, string defaultEntryText, int maxLength)
            {
                return Show(titleText, promptText, defaultEntryText, maxLength, new Vector2(-1f, -1f), PauseMode.PauseSimulator);
            }

            public static string Show(string titleText, string promptText, string defaultEntryText, int maxLength, Vector2 position, PauseMode pauseMode)
            {
                return Show(titleText, promptText, defaultEntryText, maxLength, position, pauseMode, false);
            }

            public static string Show(string titleText, string promptText, string defaultEntryText, int maxLength, Vector2 position, PauseMode pauseMode, bool forceShowDialog)
            {
                if (ModalDialog.EnableModalDialogs || forceShowDialog)
                {
                    UICopyableTextDialog uICopyableTextDialog = new UICopyableTextDialog(titleText, promptText, defaultEntryText, maxLength, position, pauseMode);
                    uICopyableTextDialog.StartModal();
                    return uICopyableTextDialog.Result;
                }
                return "";
            }
        }

        private string _itenTitle;
        private string _Text;

        public string Text
        {
            get
            {
                if (_Text == null) return "_Text is null";
                return _Text.Replace("\n", System.Environment.NewLineInternal); // unprotected mono mscorlib 
            }
            set
            {
                _Text = value;
            }
        }

        public NCopyableTextDialog()
            : this("")
        {
        }

        public NCopyableTextDialog(string text)
        {
            Text = text;
        }

        public void ShowDialog()
        {
            ShowDialog("");
        }

        public string ShowDialog(string title)
        {
            //if (Simulator.CheckYieldingContext(false))
            //{
            //    return UICopyableTextDialog.Show(title, "", Text, kUseDefaultMax, Vector2.Origin, ModalDialog.PauseMode.NoPause);
            //}
            //else
            //{
            //    return UICopyableTextDialog.Show(title, "", Text, kUseDefaultMax, Vector2.Origin, ModalDialog.PauseMode.PauseSimulator);
            //}
            return UICopyableTextDialog.Show(title, "", Text, kUseDefaultMax, Vector2.Origin, ModalDialog.PauseMode.PauseSimulator);
        }

        public string ShowS()
        {
            return Show("");
        }

        public void Show()
        {
            Show("");
        }

        public string Show(string title)
        {
            Simulator.CheckYieldingContext(true);
            return UICopyableTextDialog.Show(title, "", Text, kUseDefaultMax, Vector2.Origin, ModalDialog.PauseMode.PauseSimulator);
        }


        public void SafeShow(string title)
        {
            if (Simulator.CheckYieldingContext(false))
            {
                UICopyableTextDialog.Show(title ?? "", "", Text, kUseDefaultMax, Vector2.Origin, ModalDialog.PauseMode.PauseSimulator);
            }
            else
            {
                _itenTitle = title ?? "";
                Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate { UICopyableTextDialog.Show(_itenTitle, "", Text, kUseDefaultMax, Vector2.Origin, ModalDialog.PauseMode.PauseSimulator); });
            }
           
        }
    }
}