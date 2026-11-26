using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsZongHeLianXi
{
    /// <summary>
    /// 练习用空窗体
    /// 当前没有任何业务逻辑，只有设计器生成的 InitializeComponent，
    /// 保留它是为了让本项目单独编译运行时也有一个可显示的窗口。
    /// 若要在此练习，按"字段 → 构造函数 → 控件事件 → 业务方法"的顺序加 region 即可。
    /// </summary>
    public partial class Form1 : Form
    {
        #region 构造函数
        /// <summary>
        /// 无参构造函数：由设计器与 Program.Main 调用
        /// InitializeComponent 里是控件创建、布局与事件订阅的全部代码（见 Form1.Designer.cs）
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        #endregion
    }
}
