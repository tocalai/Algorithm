public class CoinChange
{
        // exchange's pattern
        HashSet<string> solutions = new HashSet<string>();
        int[] tracks;

        /// <summary>
        /// Amount of dollar for exchange
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// The unit of coins, ex: 1, 5, 10
        /// </summary>
        public int[] Coins { get; set; }

        public CoinChange(int amount, int[] coins)
        {
            this.Amount = amount;
            this.Coins = coins;
            tracks = new int[this.Amount];
        }


        public void MakeCoinChange(int round)
        {
            var total = tracks.Sum();
            if (total >= this.Amount || round == this.Amount)
            {
                if (total == this.Amount)
                {
                    var sortedTracks = tracks.Where(x => x > 0).OrderBy(i => i);
                    var term = string.Join("", sortedTracks);
                    solutions.Add(term);
                }
                return;
            }

            foreach(var coin in Coins)
            {
                tracks[round] = coin;
                MakeCoinChange(round + 1);
                tracks[round] = 0;
            }
        }
    }
