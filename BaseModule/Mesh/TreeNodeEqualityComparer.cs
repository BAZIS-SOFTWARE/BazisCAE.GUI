using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.Mesh
{
    public class TreeNodeEqualityComparer : IEqualityComparer<TreeNode>
    {
        public bool Equals(TreeNode x, TreeNode y)
        {
            return x.Text == y.Text;
        }

        public int GetHashCode(TreeNode obj)
        {
            return obj.Text.GetHashCode();
        }
    }
}
