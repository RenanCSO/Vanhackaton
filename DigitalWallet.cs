using System;

namespace Vanhackaton
{
    class DigitalWallet
    {
        private long walletId;
        private string username;
        private string userAccessToken;
        private int walletBalance;
        
        public DigitalWallet(long walletId, string userName, string userAccessToken) {
            this.walletId = walletId;
            this.username = userName;
            this.userAccessToken = userAccessToken;

            // Generate a random balance for the wallet
            Random random = new Random();
            this.walletBalance = random.Next(100000); 
        }
        
        public long getWalletId() {
            return walletId;
        }

        public string getUsername() {
            return username;
        }

        public string getUserAccessToken() {
            return userAccessToken;
        }
        
        public int getWalletBalance() {
            return walletBalance;
        }

        public void setBalance(int walletBalance) {
            this.walletBalance = walletBalance;
        }
    }
}