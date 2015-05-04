using System;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

namespace Noname.TrippingSigul.ts.core
{
    internal class AutobuildIntellisenseController : IIntellisenseController
    {
        readonly ITextView _textView;
        readonly ITextDocument _textDocument;
        readonly AutobuildIntellisenseControllerProvider _provider;

        public AutobuildIntellisenseController(
            ITextView textView,
            ITextDocument textDocument,
            AutobuildIntellisenseControllerProvider provider)
        {
            this._textView = textView;
            this._textDocument = textDocument;
            this._provider = provider;

            textDocument.DirtyStateChanged += OnDocumentDirtyStateChanged;
        }

        void OnDocumentDirtyStateChanged(object sender, EventArgs e)
        {
            if (!_textDocument.IsDirty)
            {
                ExecuteBuildAction();
            }
        }

        void ExecuteBuildAction()
        {
            this._provider.GetDte().ExecuteCommand("Build.BuildSelection");
        }

        public void ConnectSubjectBuffer(ITextBuffer subjectBuffer)
        {
            //Do nothing
        }

        public void DisconnectSubjectBuffer(ITextBuffer subjectBuffer)
        {
            //Do nothing
        }

        public void Detach(ITextView detacedTextView)
        {
            if (_textView == detacedTextView)
            {
                _textDocument.DirtyStateChanged -= OnDocumentDirtyStateChanged;
            }
        }
    }
}
