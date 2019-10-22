using System.Diagnostics;
using System;
using System.ComponentModel;

namespace Morysoft.MorySnip.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Form_AutoCapture m_Form_AutoCapture;

            public Form_AutoCapture Form_AutoCapture
            {
                [DebuggerHidden]
                get
                {
                    m_Form_AutoCapture = Create__Instance__(m_Form_AutoCapture);
                    return m_Form_AutoCapture;
                }
                [DebuggerHidden]
                set
                {
                    if (value == m_Form_AutoCapture)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__(ref m_Form_AutoCapture);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Form_Download m_Form_Download;

            public Form_Download Form_Download
            {
                [DebuggerHidden]
                get
                {
                    m_Form_Download = Create__Instance__(m_Form_Download);
                    return m_Form_Download;
                }
                [DebuggerHidden]
                set
                {
                    if (value == m_Form_Download)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__(ref m_Form_Download);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Form_Edit m_Form_Edit;

            public Form_Edit Form_Edit
            {
                [DebuggerHidden]
                get
                {
                    m_Form_Edit = Create__Instance__(m_Form_Edit);
                    return m_Form_Edit;
                }
                [DebuggerHidden]
                set
                {
                    if (value == m_Form_Edit)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__(ref m_Form_Edit);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Form_Save_Base m_Form_Save_Base;

            public Form_Save_Base Form_Save_Base
            {
                [DebuggerHidden]
                get
                {
                    m_Form_Save_Base = Create__Instance__(m_Form_Save_Base);
                    return m_Form_Save_Base;
                }
                [DebuggerHidden]
                set
                {
                    if (value == m_Form_Save_Base)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__(ref m_Form_Save_Base);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Form_Settings m_Form_Settings;

            public Form_Settings Form_Settings
            {
                [DebuggerHidden]
                get
                {
                    m_Form_Settings = Create__Instance__(m_Form_Settings);
                    return m_Form_Settings;
                }
                [DebuggerHidden]
                set
                {
                    if (value == m_Form_Settings)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__(ref m_Form_Settings);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Form_SnippingTool m_Form_SnippingTool;

            public Form_SnippingTool Form_SnippingTool
            {
                [DebuggerHidden]
                get
                {
                    m_Form_SnippingTool = Create__Instance__(m_Form_SnippingTool);
                    return m_Form_SnippingTool;
                }
                [DebuggerHidden]
                set
                {
                    if (value == m_Form_SnippingTool)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    this.Dispose__Instance__(ref m_Form_SnippingTool);
                }
            }
        }
    }
}
