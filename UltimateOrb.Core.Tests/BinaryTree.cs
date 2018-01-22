﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Core.Tests {

    public static partial class BinaryTreeModule {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static string ToString<T>(this BinaryTree<T>.Tree tree) {
            if (null != tree) {
                var sb = new System.Text.StringBuilder();
                sb.Append('(');
                sb.Append('{');
                tree.Value.root.ToString(sb);
                sb.Append(')');
                sb.Append('}');
                return sb.ToString();
            }
            // return "null";
            return "";
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static string ToString<T>(in this BinaryTree<T>.TreeStruct tree) {
            var sb = new System.Text.StringBuilder();
            sb.Append('{');
            tree.root.ToString(sb);
            sb.Append('}');
            return sb.ToString();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void ToString<T>(this BinaryTree<T>.Node node, System.Text.StringBuilder sb) {
            if (null != node) {
                sb.Append('(');
                sb.Append(node.Value.value.ToString());
                sb.Append('[');
                node.Value.left_child.ToString(sb);
                sb.Append(',');
                node.Value.right_child.ToString(sb);
                sb.Append(']');
                sb.Append(')');
                return;
            }
            {
                // sb.Append("null");
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void ToString<T>(in this BinaryTree<T>.NodeStruct node, System.Text.StringBuilder sb) {
            sb.Append(node.value.ToString());
            sb.Append('[');
            node.left_child.ToString(sb);
            sb.Append(',');
            node.right_child.ToString(sb);
            sb.Append(']');
            sb.Append(')');
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ref BinaryTree<T>.TreeStruct Create<T>(in T root_item) {
            var t = new BinaryTree<T>.Tree(root_item);
            return ref t.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ref BinaryTree<T>.NodeStruct AddSorted<T, TComparer>(ref this BinaryTree<T>.TreeStruct @this, in T item, in TComparer comparer) where TComparer : IComparer<T> {
            return ref AddSorted(ref @this.root, item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ref BinaryTree<T>.NodeStruct AddSorted<T, TComparer>(this BinaryTree<T>.Tree @this, in T item, in TComparer comparer) where TComparer : IComparer<T> {
            return ref AddSorted(ref @this.Value.root, item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ref BinaryTree<T>.NodeStruct AddSorted<T, TComparer>(ref this BinaryTree<T>.NodeStruct @this, in T item, in TComparer comparer) where TComparer : IComparer<T> {
            var t = comparer.Compare(@this.value, item);
            BinaryTree<T>.Node node;
            if (t > 0) {
                var child = @this.left_child;
                if (null != child) {
                    node = child;
                } else {
                    var b = new BinaryTree<T>.Node(item, @this.tree, null, null);
                    @this.left_child = b;
                    return ref b.Value;
                }
            } else {
                var child = @this.right_child;
                if (null != child) {
                    node = child;
                } else {
                    var b = new BinaryTree<T>.Node(item, @this.tree, null, null);
                    @this.right_child = b;
                    return ref b.Value;
                }
            }
            return ref node.AddSorted(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ref BinaryTree<T>.NodeStruct AddSorted<T, TComparer>(this BinaryTree<T>.Node @this, in T item, in TComparer comparer) where TComparer : IComparer<T> {
            for (var node = @this; ;) {
                var t = comparer.Compare(node.Value.value, item);
                if (t > 0) {
                    var ch = node.Value.left_child;
                    if (null != ch) {
                        node = ch;
                        continue;
                    }
                    {
                        var b = new BinaryTree<T>.Node(item, node.Value.tree, null, null);
                        node.Value.left_child = b;
                        return ref b.Value;
                    }
                } else {
                    var ch = node.Value.right_child;
                    if (null != ch) {
                        node = ch;
                        continue;
                    }
                    {
                        var b = new BinaryTree<T>.Node(item, node.Value.tree, null, null);
                        node.Value.right_child = b;
                        return ref b.Value;
                    }
                }
            }
        }
    }

    public static partial class BinaryTree<T> {

        public partial struct TreeStruct {

            internal NodeStruct root;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal TreeStruct(T value, Tree tree, Node right_child, Node left_child) {
                this.root = new NodeStruct(value, tree, right_child, left_child);
            }
        }

        public partial class Tree : StrongBoxBase<TreeStruct> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Tree(T value) {
                this.Value = new TreeStruct(value, this, null, null);
            }

            internal protected new ref TreeStruct Value {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => ref base.Value;
            }
        }

        public partial class Node : StrongBoxBase<NodeStruct> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal protected Node(T value, Tree tree, Node right_child, Node left_child) : base(new NodeStruct(value, tree, right_child, left_child)) {
            }

            internal protected new ref NodeStruct Value {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => ref base.Value;
            }
        }

        public partial struct NodeStruct {

            internal T value;

            internal Node left_child;

            internal Node right_child;

            internal readonly Tree tree;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal NodeStruct(T item, Tree tree, Node right_child, Node left_child) {
                this.value = item;
                this.tree = tree;
                this.right_child = right_child;
                this.left_child = left_child;
            }
        }
    }
}