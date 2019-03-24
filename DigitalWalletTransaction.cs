using System;
using System.Globalization;

namespace Vanhackaton
{
    class DigitalWalletTransaction
    {
        private bool commonValidation(DigitalWallet digitalWallet, int amount) {
		
            if (amount <= 0) {
                return false;
            }
            
            if (digitalWallet.getUserAccessToken() == null) {
                return false;
            }

            return true;
        }
	
        public string addMoney(DigitalWallet digitalWallet, int amount) {
            
            if (!this.commonValidation(digitalWallet, amount)) {
                return "We can not do this transaction";
            }
            
            digitalWallet.setBalance(digitalWallet.getWalletBalance() + amount);

            return returnBalance(digitalWallet);
        }

        public string payMoney(DigitalWallet digitalWallet, int amount) {
                    
            if (!this.commonValidation(digitalWallet, amount)) {
                return "We can not do this transaction";
            }
            
            // Final balance after possible transaction
            int finalBalance = 0;
            finalBalance = digitalWallet.getWalletBalance() - amount;
            
            if (finalBalance < 0) {
                return "Insufficient balance";
            }
            else {
                digitalWallet.setBalance(finalBalance);	
            }

            return returnBalance(digitalWallet);
        }
    
        public string transferMoney(DigitalWallet digitalWalletSend, int amount, DigitalWallet digitalWalletReceive) {
            if (!this.commonValidation(digitalWalletSend, amount)) {
                return "We can not do this transaction";
            }

            payMoney(digitalWalletSend, amount);
            addMoney(digitalWalletReceive, amount);

            return returnBalance(digitalWalletSend);
        }

        private string returnBalance(DigitalWallet digitalWallet) {
            return "Your balance is: " + digitalWallet.getWalletBalance().ToString("C2", CultureInfo.CurrentCulture); 
        }
    }
}