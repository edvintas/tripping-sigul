using System.Collections.Generic;
using System.ComponentModel.Composition;
using EnvDTE;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace Noname.TrippingSigul.ts.core
{
    [Export(typeof(IIntellisenseControllerProvider))]
    [Name("Sigul Intellisense Controller")]
    [ContentType("text")]
    internal class AutobuildIntellisenseControllerProvider : IIntellisenseControllerProvider
    {
        [Import]
        internal ITextDocumentFactoryService TextDocumentFactoryService;

        [Import]
        internal SVsServiceProvider ServiceProvider;

        private DTE _dte;

        public IIntellisenseController TryCreateIntellisenseController(ITextView textView, IList<ITextBuffer> subjectBuffers)
        {
            ITextDocument textDocument;
            if (!TextDocumentFactoryService.TryGetTextDocument(textView.TextDataModel.DocumentBuffer, out textDocument))
            {
                return null;
            }

            if (!textView.Roles.Contains(PredefinedTextViewRoles.Document))
            {
                return null;
            }

            return new AutobuildIntellisenseController(textView, textDocument, this);
        }

        public DTE GetDte()
        {
            if (_dte == null)
            {
                _dte = ServiceProvider.GetService(typeof(DTE)) as DTE;
            }
            return _dte;
        }
    }
}
