using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

public class ListNode
{
    public int Val;
    public ListNode Next;
    public ListNode(int x=0, ListNode next=null) {
        Val = x; 
        Next = next;
    }

    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        ListNode dummy = new();
        ListNode current = dummy;



        while (l1 != null && l2 != null)
        {
            if (l1.Val < l2.Val)
            {
                current.Next = l1;
                l1 = l1.Next;
            }
            else
            {
                current.Next = l2;
                l2 = l2.Next;
            }
            current = current.Next;
        }

        if (l1 != null)
        {
            current.Next = l1;
        }
        else
        {
            current.Next = l2;
        }

        return dummy.Next;
    }

}


