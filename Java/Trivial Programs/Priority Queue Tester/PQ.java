public class PQ
	{
		public PQ(int maxN)
		{
			pq = new String[maxN+1];
			N=0;
		}
		
		private String[] pq;
		private int N;
		
		public String peek ()
		{
			return (pq[0]);
		}
		

		private boolean less(int i, int j)
		{
			if(pq[i]!=null && pq[j]!=null)
				if (pq[i].compareTo(pq[j])>0)
					return(true);
			return (false);
		}
		
		private void exch(int i, int j)
		{
			String t= pq[i];
			pq[i] = pq[j];
			pq[j] = t;
		}
		
		private void swim(int k)
		{
			while(k>1 && less(k/2, k))
			{
				exch(k, k/2);
				k=k/2;
			}
		}
		
		private void sink(int k, int N)
		{
			while (2*k <= N)
			{
				int j = 2*k;
				if (j<N && less(j, j+1))
					j++;
				if (!less(k, j))
					break;
				exch(k, j);
				k=j;
			}
		}
		
		
		public boolean empty()
		{
			return(N==0);
		}
		
		public void insert(String v)
		{
			pq[++N] = v; 
			swim(N);
		}
		
		public String getmax()
		{
			exch(1, N);
			sink(1, N-1);
			return (pq[N--]);
		}

	}

