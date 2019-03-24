using System;
using System.Collections.Generic;

namespace Vanhackaton
{
    class Bank
    {
        private Dictionary<string, DigitalWallet> digitalWallets = new Dictionary<string, DigitalWallet>();

        public void createDigitalWallet(long walletId, string username, string userAccessToken) {
            DigitalWallet wallet = new DigitalWallet(walletId, username, userAccessToken);

            digitalWallets.Add(wallet.getUsername(), wallet);
        }

        public DigitalWallet getWallet(string walletUsername, string token) {

            DigitalWallet wallet;
            if(digitalWallets.TryGetValue(walletUsername, out wallet)) {
                if(wallet.getUserAccessToken().Equals(token)){
                    return wallet;
                }
            }

            return null;
        }

        public DigitalWallet getWallet(string walletUsername) {

            DigitalWallet wallet;
            if(digitalWallets.TryGetValue(walletUsername, out wallet)) {
                return wallet;            
            }

            return null;
        }
    }
}