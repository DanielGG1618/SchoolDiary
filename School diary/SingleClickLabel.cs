using System;
using System.Security.Permissions;
using System.Windows.Forms;

[System.ComponentModel.DesignerCategory("Code")]
class SingleClickLabel : Label
{
    private string _clipboardSave;

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);

        _clipboardSave = Clipboard.GetText();
    }

    protected override void OnDoubleClick(EventArgs e)
    {
        base.OnDoubleClick(e);

        if (!string.IsNullOrEmpty(_clipboardSave))
            Clipboard.SetText(_clipboardSave);
        else
            Clipboard.Clear();
    }
}