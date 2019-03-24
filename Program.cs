using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Vanhackaton
{
    class Program
    {
        static ITelegramBotClient botClient;
        static Bank bank;

        static string responder(long chatId, string message) {
            
            string[] transactionParameters = message.Split(" ");

            if(transactionParameters.Length < 3){
                return "Sorry, I do not undestand! Could you repat, please?";
            }

            string transaction = transactionParameters[0].ToUpper();
            string username = transactionParameters[1];
            string token = transactionParameters[2];

            if(transaction.Equals("CREATE")) {
                Console.WriteLine("Creating an Digital Wallet");
                bank.createDigitalWallet(chatId, transactionParameters[1], transactionParameters[2]);
                return "Digital Wallet was created";
            }

            else if(transaction.Equals("EXCHANGE")) {
                return "Sorry, this functionality was not implemented yet";
            }

            else {
                DigitalWallet clientWallet = bank.getWallet(username, token);
                if (clientWallet == null) {
                    return "Sorry, your wallet is not active";
                }

                if(transaction.Equals("BALANCE")) {
                    return "Your balance is: " + clientWallet.getWalletBalance().ToString("C2", CultureInfo.CurrentCulture);
                }

                int value = Convert.ToInt32(transactionParameters[3]);
                DigitalWalletTransaction walletTransaction = new DigitalWalletTransaction();
                if(transaction.Equals("ADD")) {
                    return walletTransaction.addMoney(clientWallet, value);
                }

                if(transaction.Equals("PAY")) {
                    return  walletTransaction.payMoney(clientWallet, value);
                }

                if(transaction.Equals("TRANSFER")) {
                    DigitalWallet clientWalletReceive = bank.getWallet(transactionParameters[4]);
                    return walletTransaction.transferMoney(clientWallet, value, clientWalletReceive);
                }
            }

            return "Sorry, I do not undestand! Could you repat, please?";
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e) {
            if (e.Message.Text != null)
            {
                
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text:   responder(e.Message.Chat.Id, e.Message.Text)
                );
            }
        }

        static void Main(string[] args)
        {
            bank = new Bank();

            botClient = new TelegramBotClient("803527561:AAH3nfpWqkGOlZeaWkGRe2oJBKV3CKorZOU");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
                $"Running! I am user {me.Id} and my name is {me.FirstName}."
            );

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }
    }
}
