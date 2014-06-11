
class ListStackQueueDemo
{

    public static void main( String [ ] args )
    {
        //
        // Generic list based Stacks
        //
        ListStack<String> s1 = new ListStack<String>();

        s1.push("AAA");
        s1.push("BBB");

        System.out.println(s1.top());
        s1.pop();
        System.out.println(s1.top());
        s1.pop();

        ListStack<Double> s2 = new ListStack<Double>();

        s2.push(111.111);
        s2.push(222.222);

        System.out.println(s2.top());
        s2.pop();
        System.out.println(s2.top());
        s2.pop();

        if (s1.isEmpty() && s2.isEmpty())
           System.out.println("\n\nStacks s1 and s2 are empty");

        System.out.println("\n\n");

        //
        // Generic list based Queues
        //

        ListQueue<String> q1 = new ListQueue<String>();

        q1.enqueue("CCC");
        q1.enqueue("DDD");

        System.out.println(q1.dequeue());
        System.out.println(q1.dequeue());


        ListQueue<Double> q2 = new ListQueue<Double>();

        q2.enqueue(333.333);
        q2.enqueue(444.444);

        System.out.println(q2.dequeue());
        System.out.println(q2.dequeue());

        if (q1.isEmpty() && q2.isEmpty())
           System.out.println("\n\nQueues q1 and a2 are empty\n\n");
    }
}
