//*****************************************************************************
//** 909. Snakes and Ladders                                        leetcode **
//*****************************************************************************

int snakesAndLadders(int** board, int boardSize, int* boardColSize) {
    int n = boardSize;
    int total = n * n;
    int arr[10001];      
    char seen[10001] = {0}; 
    int queue[10001];      
    int front = 0, back = 0;

    int idx = 1;
    for (int i = n - 1, up = 1; i >= 0; i--, up ^= 1)
    {
        for (int j = 0; j < n; ++j)
        {
            int col = up ? j : (n - 1 - j);
            arr[idx++] = board[i][col];
        }
    }

    queue[back++] = 1;
    seen[1] = 1;
    int step = 0;

    while (front < back)
    {
        int size = back - front;
        ++step;

        for (int i = 0; i < size; i++)
        {
            int curr = queue[front++];

            for (int move = 1; move <= 6; move++)
            {
                int next = curr + move;
                if (next > total)
                    break;

                int dest = (arr[next] > 0) ? arr[next] : next;

                if (dest == total)
                    return step;

                if (!seen[dest])
                {
                    seen[dest] = 1;
                    queue[back++] = dest;
                }
            }
        }
    }

    return -1;
}