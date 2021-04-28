using System.Collections.ObjectModel;

namespace Bibliotecar.TagsTitle
{
    public abstract class Node
    {
        string _name;
        private string _findCondition; 

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string FindCondition
        {
            get { return _findCondition; }
            set { _findCondition = value; }
        }
    }

    public class TreeNode : Node
    {
        ObservableCollection<Node> _childNodes;

        public ObservableCollection<Node> ChildNodes
        {
            get { return _childNodes; }
            set { _childNodes = value; }
        }

        public TreeNode(string name, string findCondition)
        {
            Name = name;
            FindCondition = findCondition;
            ChildNodes = new ObservableCollection<Node>();
        }
    }

    public class TreeNodeList : ObservableCollection<Node>
    {
        private readonly ListTitle _listTitleTags;
        public TreeNodeList()
        {
            TreeNode tn;

            _listTitleTags = new ListTitle();

            for (int headNode = 0; headNode < _listTitleTags.HeaderNode.Length; headNode++)
            {
                Add(tn = new TreeNode(_listTitleTags.HeaderNode[headNode], null));
                if (null != _listTitleTags.ListNodes[headNode])
                {
                    for (int childNode = 0; childNode < _listTitleTags.ListNodes[headNode].Length; childNode++)
                        tn.ChildNodes.Add(new TreeNode(_listTitleTags.ListNodes[headNode][childNode], 
                            _listTitleTags.ListTitleNodes[headNode][childNode]));
                }
            }
        }
    }
}