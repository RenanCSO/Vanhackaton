# Vanhackaton
201903 - Vanhackaton - Online Business Systems

Idea - All about your finances in Telegram

Solution - Create a Bot Telegram which is able to do bank transactions
         - The MVP is mocked, because I do not have access to real Bank APIs (openbanking)

Running the project

  - The project uses .NET Core and Telegram Bot API
    * To run the project you will need:
      * Install Visual Studio Code or other IDE you prefered
      * Install .NET Core
      * Install Telegram.Bot because it's a dependency -> dotnet add package Telegram.Bot
      * Clone the project and run the Program.cs
    
  - The Bot link is: http://t.me/obs_renancso_bot, so after you run the project you are able to interact with the plataform using your own Telegram in your Smartphone
    * The first interaction needs to be with a message "CREATE" because the system will create a digital wallet for you
      * Example: CREATE USERNAME TOKEN
        * CREATE   - Transaction
        * USERNAME - Your user in a bank
        * TOKEN    - Your pass in a bank
  
  - The other interactions are:
    * BALANCE [USER] [TOKEN]
      * BALANCE - Transaction that you need to do
      * USER    - Your user name that you had created
      * TOKEN   - Token returned by the bot in your first interaction
    * ADD [USER] [TOKEN] [VALUE]
      * ADD     - Transaction that you need to do
      * USER    - Your user name that you had created
      * TOKEN   - Token returned by the bot in your first interaction
      * VALUE   - How much money you will deposit in your account
    * PAY [USER] [TOKEN] [VALUE]
      * PAY     - Transaction that you need to do
      * USER    - Your user name that you had created
      * TOKEN   - Token returned by the bot in your first interaction
      * VALUE   - How much money you will pay
    * TRANSFER [YOUR USER] [TOKEN] [VALUE] [ANOTHER USER]
      * TRANSFER - Transaction that you need to do
      * USER     - Your user name that you had created
      * TOKEN    - Token returned by the bot in your first interaction
      * VALUE    - How much money you will pay
    * EXCHANGE [CURRENCY_1] [CURRENCY_2]
      * EXCHANGE   - Transaction that you need to do
      * CURRENCY_1 - Your user name that you had created
      * CURRENCY_2 - Token returned by the bot in your first interaction
      
 If you have any doubts about the project, you can send me an e-mail and I will answer as soon as possible.
  * E-mail: renan.c.s.o@gmail.com
