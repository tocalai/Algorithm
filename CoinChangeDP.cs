    /// <summary>
    /// Using dymanic programming to calculate the exchange of the coins
    /// </summary>
    public class CoinChangeDP
    {
        /// <summary>
        /// Amount of dollar for exchange
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// The unit of coin 
        /// </summary>
        public int[] Coins { get; set; }

        public CoinChange(int amount, int[] coins)
        {
            this.Amount = amount;
            this.Coins = coins;
        }

        public long MakeCoinChangeDP()
        {
            // sort coins array
            var sortedCoins = Coins.OrderBy(i => i).ToArray();
            
            // i: exchange begin from coins[0], coins[0] + cions[1], .... to coins[0] + ... + coins[Length - 1]
            // j: amount start from 1 dollar to n dollars
            long[,] lookup = new long[Coins.Length + 1, Amount + 1];

            // iter to fill up the value of lookup[i, j]: that means how many solution that to exchange j via the coins[0] to coins[i]
            for (int i = 1; i < lookup.GetLength(0); i++)
            {
                for(int j = 1; j < lookup.GetLength(1); j++)
                {
                    if (j >= sortedCoins[i - 1])
                    {
                        var lookBackJ = j - sortedCoins[i - 1];
                        // lookBackJ equal 0 that indicate we got exactly using 1 coins[i] to exchange j
                        var lookBackVal = lookBackJ == 0 ? 1 : lookup[i, lookBackJ]; 
                        lookup[i, j] = lookup[i - 1, j] + lookBackVal;
                    }
                    else
                    {
                        lookup[i, j] = lookup[i - 1, j];
                    }

                   
                }
            }

            
            return lookup[Coins.Length, Amount];
        }
   }
